using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Model
{
    public class sysUserInfo
    {
        [Key]
        public int uID { get; set; }
        public string uLoginName { get; set; }
        public string uLoginPWD { get; set; }
        public string uRealName { get; set; }
        public int uStatus { get; set; }
        public string uRemark { get; set; }
        public DateTime uCreateTime { get; set; }
        public DateTime uUpdateTime { get; set; }

    }
}
