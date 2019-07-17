using LogService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace DataBaseAccesser
{
    public class DataBaseManager
    {
        private static ExchangeBookDB _db;
        private ILogService _logservice;

        public DataBaseManager()
        {
            _db = new ExchangeBookDB();
            _logservice = IOCContainer.GetFromFac<ILogService>();
        }

        /// <summary>
        /// 通过用户名 密码判断用户是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public bool Exist(String name, String pwd)
        {

            bool exist = _db.Exists<LoginUser>("where name=@0 and pwd=@1", name, pwd);
            if (!exist)
                return false;

            return true;
        }

        /// <summary>
        /// 通过用户名 密码  获取具体用户
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public LoginUser GetUser(String name, String pwd)
        {
            try
            {
                LoginUser user = _db.Query<LoginUser>("where name=@0 and pwd=@1", name, pwd).FirstOrDefault();
                return user;
            }
            catch (Exception e)
            {
                _logservice.Error(e.Message);
                return null;
            }

          
        }

        /// <summary>
        /// 返回指定类型,指定页的书籍列表
        /// </summary>
        /// <param name="family"> 类型 </param>
        /// <returns></returns>
        public IEnumerable<book_info> GetBookList(int currentPage, int count, String family, out int total)
        {
            total = 0;
            try
            {
               
                PetaPoco.Page<book_info> result = null;
                total = _db.Query<int>("SELECT COUNT(*) FROM book_info").First();

                if (String.IsNullOrEmpty(family))
                {
                    result = _db.Page<book_info>(currentPage, count, "SELECT * FROM book_info ORDER BY book_name");

                }
                else
                {
                    result = _db.Page<book_info>(currentPage, count, "SELECT * FROM book_info WHERE family=@0 ORDER BY book_name", family);
                }

                _logservice.Info($"{DateTime.Now.ToShortDateString()}查询数据-页码：{currentPage}-每页条数{count}-书籍类型-{family}");

                return result.Items;
            }
            catch (Exception e)
            {
                _logservice.Error(e.Message);
                return null;
            }
        }

    }
}
