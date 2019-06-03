using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAccesser
{
    public class DataBaseManager
    {
        private static ExchangeBookDB _db;

        public DataBaseManager()
        {
            _db = new ExchangeBookDB("ExchangeBook");
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
            LoginUser user = _db.Query<LoginUser>("where name=@0 and pwd=@1", name, pwd).FirstOrDefault();
            return user;
        }

    }
}
