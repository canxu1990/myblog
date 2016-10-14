using MyBlog.IServices;
using MyBlog.Model;
using MyBlog.Services;
using MyBlog.WebCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;

namespace MyBlog.WebUI.Controllers
{
    
    public class HomeController : BaseController
    {
        IsysUserInfoServices userinfoservice;
        IBlogArticleServices blogArticleServive;
        IAdvertisementServices advertisementServices;
        public HomeController(IsysUserInfoServices userinfos, IBlogArticleServices blogArticleServive, IAdvertisementServices advertisementServices)
        {
            this.userinfoservice = userinfos;
            this.blogArticleServive = blogArticleServive;
            this.advertisementServices = advertisementServices;
        }
       
        public ActionResult Index(int pageIndex=1)
        {
            //获取控制器名称
            ViewBag.controllername = RouteData.Values["controller"].ToString().ToLower();
            int pageSize = 6;
            //获取发布博文信息
            var blogArticleList = blogArticleServive.QueryWhere(p => true).OrderByDescending(p => p.bCreateTime).ToPagedList(pageIndex, pageSize);
            foreach (var item in blogArticleList)
            {
                if (!string.IsNullOrWhiteSpace(item.bcontent))
                {
                    item.bcontent = Server.HtmlDecode(item.bcontent);
                    if (item.bcontent.Length > 100)
                    {
                        item.bcontent = item.bcontent.Substring(0, 200);
                    }
                }
            }
            //获取轮播广告新
            ViewBag.adList = advertisementServices.QueryOrderBy(a => true, a => a.Createdate, false).ToPagedList(1, 3);
            //发布时间排序
            ViewBag.blogtimelist = blogArticleServive.QueryOrderBy(p => true, p => p.bCreateTime, false);
            //评论排序
            ViewBag.blogtrafficlist = blogArticleServive.QueryOrderBy(p => true, p => p.btraffic, false);
            //留言排序
            //string sql = @"select a.* b.btitle  from(select blogId,count(1) as counts from Guestbook group by blogId) as a inner join BlogArticle as b on b.bID=a.blogId order by counts desc";

            return View(blogArticleList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}