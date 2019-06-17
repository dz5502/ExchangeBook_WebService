using DataBaseAccesser;
using DTO;
using LogService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;
using Newtonsoft.Json;
using System.IO;

namespace ExchangeBook
{
    public class ExchangeBookProxy
    {

        private ExchangeBookProxy()
        {
            IOCContainer.InitAutofac();
            _DataBaseManager = new DataBaseManager();
            _logservice = IOCContainer.GetFromFac<ILogService>();
        }
        private static readonly ExchangeBookProxy instance = new ExchangeBookProxy();
        private static DataBaseManager _DataBaseManager;
        public static ExchangeBookProxy GetInstance()
        {
            return instance;
        }


        private ILogService _logservice;

        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public String Login(String name, String pwd)
        {
            LoginResult result = new LoginResult();
            LoginUser user = _DataBaseManager.GetUser(name, pwd);
            if (user == null)
            {
                _logservice.Info($"用户【{name}】不存在");
                return null;

            }
            result.result = true;
            result.IsManager = user.isManager;
            _logservice.Info($"用户【{name}】登录成功");
            //返回结果JSon字符串
            return JsonConvert.SerializeObject(result);
        }


        /// <summary>
        /// Gird数据测试
        /// </summary>
        /// <returns></returns>
        public String GridData()
        {
            String re = null;
            BookDetailData data = new BookDetailData();
            String path = @"G:\Work\Resources\backgroud.bmp";
            FileStream image = new FileStream(path, FileMode.Open);
            BinaryReader reader = new BinaryReader(image);

            re = Convert.ToBase64String(reader.ReadBytes((int)image.Length));


            data.Image = re;
            data.Author = "5502";
            data.Description = "12345678900000";
            data.UserName = "十二"; ;
            data.Level = 9;

            image.Close();
            return JsonConvert.SerializeObject(data) ;
        }
    }
}
