using AutoMapper;
using MyBlog.IServices;
using MyBlog.Model.Entity;
using MyBlog.Model.model;
using MyBlog.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Services
{
    public partial class BlogArticleServices:BaseServices<BlogArticle>, IBlogArticleServices
    {
        IBlogArticleRepository iblog;
        public BlogArticleServices(IBlogArticleRepository iblog)
        {
            this.iblog = iblog;
            base.baseDal = baseDal;
        }
        public BlogViewModels getBlogDetails(int id)
        {
            BlogArticle blogArticle = iblog.QueryWhere(p => p.bID == id).FirstOrDefault();
            BlogArticle preBlog = iblog.QueryWhere(p => p.bID == id - 1).FirstOrDefault();
            BlogArticle nextBolg = iblog.QueryWhere(p => p.bID == id + 1).FirstOrDefault();
            blogArticle.btraffic++;
            iblog.Edit(blogArticle, new string[] { "btraffic" });
            iblog.SaveChanges();
            //AutoMapper自动映射
            Mapper.Initialize(p => p.CreateMap<BlogArticle, BlogViewModels>());
            BlogViewModels models = Mapper.Map<BlogArticle, BlogViewModels>(blogArticle);
            if (nextBolg != null)
            {
                models.next = nextBolg.btitle;
                models.nextID = nextBolg.bID;
            }
            if (preBlog != null)
            {
                models.previous = preBlog.btitle;
                models.previousID = preBlog.bID;
            }
            models.digest = blogArticle.bcontent.Length > 100 ? blogArticle.bcontent.Substring(0, 100) : blogArticle.bcontent;
            return models;
        }
    }
}
