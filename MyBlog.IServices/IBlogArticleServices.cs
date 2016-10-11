using MyBlog.Model.Entity;
using MyBlog.Model.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.IServices
{
    public interface IBlogArticleServices:IBaseServices<BlogArticle>
    {
        BlogViewModels getBlogDetails(int id);
    }
}
