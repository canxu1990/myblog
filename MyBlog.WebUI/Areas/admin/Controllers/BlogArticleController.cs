using MyBlog.Model.Entity;
using MyBlog.IServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.WebUI.Areas.admin.Controllers
{
    public class BlogArticleController : Controller
    {
        IBlogArticleServices iblog;
        public BlogArticleController(IBlogArticleServices iblog)
        {
            this.iblog = iblog;
        }
        // GET: admin/Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        /// <summary>
        /// 图片上传
        /// </summary>
        /// <returns></returns>
        public ActionResult UpLoad()
        {
            //文件保存目录
            string savePath = "/upload/";

            //定义允许上传的文件扩展名
            Hashtable extTable = new Hashtable();
            extTable.Add("image", "gif,jpg,jpeg,png,bmp");
            extTable.Add("flash", "swf,flv");
            extTable.Add("media", "swf,flv,mp3,wav,wma,wmv,mid,avi,mpg,asf,rm,rmvb");
            extTable.Add("file", "doc,docx,xls,xlsx,ppt,htm,html,txt,zip,rar,gz,bz2");

            //最大文件大小
            int maxSize = 1000000;

            HttpPostedFileBase imgFile = Request.Files["imgFile"];

            if (imgFile == null)
            {
                return Content("error|请选择文件。");
            }
            string dirPath = Server.MapPath(savePath);

            if (!Directory.Exists(dirPath))
            {
                return Content("error|上传目录不存在。");
            }
            string dirName = Request.QueryString["dir"];
            if (string.IsNullOrWhiteSpace(dirName))
            {
                dirName = "image";
            }
            if (!extTable.ContainsKey(dirName))
            {
                return Content("error|目录名不正确。");
            }
            string fileName = imgFile.FileName;
            string fileExt = Path.GetExtension(fileName).ToLower();
            if (imgFile.InputStream == null || imgFile.InputStream.Length > maxSize)
            {
                return Content("error|上传文件大小超过限制。");
            }
            if (string.IsNullOrWhiteSpace(fileExt) || Array.IndexOf(((string)extTable[dirName]).Split(','), fileExt.Substring(1).ToLower()) == -1)
            {
                return Content("error|上传文件扩展名是不允许的扩展名。\n只允许" + ((String)extTable[dirName]) + "格式。");
            }

            //创建文件夹
            dirPath += dirName + '/';
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            string ymd = DateTime.Now.ToString("yyyyMMdd", DateTimeFormatInfo.InvariantInfo);
            dirPath += ymd + "/";
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            string newFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + fileExt;
            string filePath = dirPath + newFileName;
            imgFile.SaveAs(filePath);
            string fileUrl = savePath + "image/" + ymd + "/" + newFileName;
            return Content(fileUrl);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(BlogArticle blogArticle)
        {
            blogArticle.bCreateTime = DateTime.Now;
            blogArticle.bsubmitter = "admin";
            blogArticle.bUpdateTime = DateTime.Now;
            blogArticle.bRemark = string.Empty;
            iblog.Add(blogArticle);
            iblog.SaverChanges();
            return Content("ok:添加成功!");
        }
    }
}