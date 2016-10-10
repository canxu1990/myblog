using MyBlog.WebCore.Filters;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.WebUI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //将自己定义的异常过滤器注册为全局过滤器。（全局过滤器是可以注册多个的）  
            filters.Add(new ExpFilter());
        }
    }
}
