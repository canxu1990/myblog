using MyBlog.Common.Log;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MyBlog.WebCore.Filters
{
    public class ExpFilter: HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            Exception exp = filterContext.Exception;
            //获取ex的第一级内部异常
            Exception innerExp = exp.InnerException == null ? exp : exp.InnerException;
            //循环获取内部异常知道获取到详细异常为止
            while (innerExp.InnerException != null)
            {
                innerExp = innerExp.InnerException;
            }
            Nloglogger nlog = new Nloglogger();
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                nlog.Error(innerExp.Message);
                JsonConvert.SerializeObject(new { status = 1, msg = "请求发生错误，请联系管理员" });
            }
            else
            {
                nlog.Error("error", exp);
                ViewResult vireResult = new ViewResult();
                vireResult.ViewName= "/Views/Shared/Error.cshtml";
                filterContext.Result = vireResult;
            }
            //告诉MVC框架异常被处理
            filterContext.ExceptionHandled = true;
            base.OnException(filterContext);
        }
    }
}
