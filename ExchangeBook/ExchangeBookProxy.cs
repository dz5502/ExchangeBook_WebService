using LogService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace ExchangeBook
{
    public class ExchangeBookProxy
    {

        private ExchangeBookProxy() { }
        private static readonly ExchangeBookProxy instance = new ExchangeBookProxy();
        public static ExchangeBookProxy GetInstance()
        {
            return instance;
        }


        ILogService _logservice;


        public void Test()
        {
            IOCContainer.InitAutofac();
            _logservice = IOCContainer.GetFromFac<ILogService>();

            _logservice.Info("1234");
            _logservice.Error("12345");
            _logservice.Warn("12346");
            _logservice.Fatal("12347");

        }




    }
}
