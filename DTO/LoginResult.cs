using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoginResult
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool result { get; set; }
        /// <summary>
        /// 是否为管理员
        /// </summary>
        public bool IsManager { get; set; }

    }
}
