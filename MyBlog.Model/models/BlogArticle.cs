using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Model.Entity
{
    public class BlogArticle
    {
        /// <summary>
        ///主键
        /// </summary>
        [Key]
        public int bID { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [MaxLength(60)]
        public string bsubmitter { get; set; }

        /// <summary>
        /// 博客标题
        /// </summary>
        [MaxLength(256)]
        public string btitle { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        public string bcategory { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string bcontent { get; set; }

        /// <summary>
        /// 访问量
        /// </summary>
        public int btraffic { get; set; }

        /// <summary>
        /// 评论数量
        /// </summary>
        public int bcommentNum { get; set; }

        /// <summary> 
        /// 修改时间
        /// </summary>
        public DateTime bUpdateTime { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public System.DateTime bCreateTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string bRemark { get; set; }
    }
}
