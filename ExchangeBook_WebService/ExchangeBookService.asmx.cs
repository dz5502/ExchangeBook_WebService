using ExchangeBook;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ExchangeBook_WebService
{
    /// <summary>
    /// ExchangeBookService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class ExchangeBookService : System.Web.Services.WebService
    {
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod(Description ="登录验证")]
        public String Login(String name, String pwd)
        {
            ExchangeBookProxy instance =  ExchangeBookProxy.GetInstance();
            String result = instance.Login(name, pwd);
            return result;
        }


        [WebMethod(Description = "Gird数据测试")]
        public String GridData(int currentPage, int count, String family = null)
        {
            ExchangeBookProxy instance = ExchangeBookProxy.GetInstance();
            return instance.GridData(currentPage, count, family);
        }
    }
}
