using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAccesser
{
    public class DataBaseManager
    {
        private  static ExchangeBookDB _db;

        public DataBaseManager()
        {
            _db = new ExchangeBookDB();
        }

        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public bool Login(String name, String pwd)
        {

            bool exist = _db.Exists<LoginUser>("where name=@0 and pwd=@1", name, pwd);
            if (!exist)
                return false;

            return true;
        }

    }
}
