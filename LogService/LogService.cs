using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace LogService
{
    class LogService : ILogService
    {

        Logger _logservice;

        public LogService()
        {
            _logservice = LogManager.GetLogger("log");
        }


        public void Debug(string log)
        {
            _logservice.Debug(log);
        }

        public void Error(string log)
        {
            _logservice.Error(log);
            
        }

        public void Error(string log, Exception exception)
        {
            _logservice.Error(exception, log);
        }

        public void Fatal(string log)
        {
            _logservice.Fatal(log);
        }

        public void Fatal(string log, Exception exception)
        {
            _logservice.Fatal(exception, log);
        }

        public void Info(String log)
        {
            _logservice.Info(log);

        }

        public void Warn(string log)
        {
            _logservice.Warn(log);
        }
    }
}
