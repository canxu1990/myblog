using MyBlog.IServices;
using MyBlog.Model;
using MyBlog.Services;
using MyBlog.WebCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.WebUI.Controllers
{
    
    public class HomeController : BaseController
    {
        IsysUserInfoServices userinfoservice;
        public HomeController(IsysUserInfoServices userinfos)
        {
            this.userinfoservice = userinfos;
        }
        public ActionResult Index()
        {
            //try
            //{
                //for (int i = 0; i < 10; i++)
                //{
                //    userinfoservice.Add(new sysUserInfo()
                //    {
                //        uLoginName = "admin" + i,
                //        uLoginPWD = "123456",
                //        uRealName = "超级管理员" + i,
                //        uCreateTime = DateTime.Now,
                //        uUpdateTime = DateTime.Now,
                //        uRemark = "测试添加功能"

                //    });
                //}
                //userinfoservice.SaverChanges();
                //userinfoservice.QueryWhere(p => p.uID == 1);
                //int i = 1;
                //int b = 0;
                //int c;
                //c = i / b;

                return View();
                //return Content(userinfoservice.QueryWhere(p => p.uID == 1).FirstOrDefault().uLoginName);
            //}
            //catch (Exception ex)
            //{

              //  return Content("错误提示：" + ex.Message); ;
            //}
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