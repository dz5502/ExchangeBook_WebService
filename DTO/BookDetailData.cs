using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BookDetailData
    {
        /// <summary>
        /// 图片
        /// </summary>
        public String Image { set; get; }
        /// <summary>
        /// 作者
        /// </summary>
        public String Author { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public String Description { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public String UserName { get; set; }
        /// <summary>
        /// 信用等级
        /// </summary>
        public int Level { get; set; }

    }
}
