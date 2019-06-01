using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogService
{
    public interface ILogService
    {
        /// <summary>
        /// 调试信息
        /// </summary>
        /// <param name="log"></param>
        void Debug(String log);
        /// <summary>
        /// 错误信息
        /// </summary>
        /// <param name="log"></param>
        void Error(String log);
        void Error(String log, Exception exception);
        /// <summary>
        /// 致命错误
        /// </summary>
        /// <param name="log"></param>
        void Fatal(String log);
        void Fatal(String log, Exception exception);
        /// <summary>
        /// 普通信息
        /// </summary>
        /// <param name="log"></param>
        void Info(String log);
        /// <summary>
        /// 告警信息
        /// </summary>
        /// <param name="log"></param>
        void Warn(String log);
    }
}
