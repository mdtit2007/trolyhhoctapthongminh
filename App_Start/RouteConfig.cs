using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ungdunghocthongminh
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
            name: "Exam",
            url: "thi-thu",
            defaults: new { controller = "Exam", action = "Index", id = UrlParameter.Optional },
            namespaces: new[] { "ungdunghocthongminh.Controllers" }
        );
            routes.MapRoute(
             name: "deatilExam",
             url: "kiem-tra/{alias}-k{id}",
             defaults: new { controller = "Exam", action = "Detail", alias = UrlParameter.Optional },
              namespaces: new[] { "UngDungHocThongMinh.Controllers" }
         );
            routes.MapRoute(
       name: "DetailAdvise",
       url: "{alias}-o{id}",
       defaults: new { controller = "Advise", action = "Detail", alias = UrlParameter.Optional },
        namespaces: new[] { "ungdunghocthongminh.Controllers" }
   );
            routes.MapRoute(
               name: "deatilDocument",
               url: "chi-tiet/{alias}-p{id}",
               defaults: new { controller = "Document", action = "Detail", alias = UrlParameter.Optional },
                namespaces: new[] { "UngDungHocThongMinh.Controllers" }
           );
            routes.MapRoute(
              name: "CategoryDocument2",
              url: "danh-muc-thi-thu/{alias}-{id}",
              defaults: new { controller = "Exam", action = "ExamCategory", id = UrlParameter.Optional },
               namespaces: new[] { "ungdunghocthongminh.Controllers" }
          );
            routes.MapRoute(
              name: "CategoryDocument",
              url: "danh-muc-tai-lieu/{alias}-{id}",
              defaults: new { controller = "Document", action = "DocumentCategory", id = UrlParameter.Optional },
               namespaces: new[] { "ungdunghocthongminh.Controllers" }
          );
           
            routes.MapRoute(
            name: "ChatGPT",
            url: "chat-gpt",
            defaults: new { controller = "ChatGPT", action = "RedirectToChatGPT", id = UrlParameter.Optional },
            namespaces: new[] { "ungdunghocthongminh.Controllers" }
        );
            routes.MapRoute(
              name: "Document",
              url: "tai-lieu",
              defaults: new { controller = "Document", action = "Index", id = UrlParameter.Optional },
              namespaces: new[] { "ungdunghocthongminh.Controllers" }
          );
            routes.MapRoute(
            name: "DetailDigitalConversion",
            url: "{alias}-n{id}",
            defaults: new { controller = "DigitalConversion", action = "Detail", alias = UrlParameter.Optional },
             namespaces: new[] { "ungdunghocthongminh.Controllers" }
        );
            routes.MapRoute(
              name: "DigitalConversion",
              url: "chuyen-doi-so",
              defaults: new { controller = "DigitalConversion", action = "Index", id = UrlParameter.Optional },
              namespaces: new[] { "ungdunghocthongminh.Controllers" }
          );
            routes.MapRoute(
               name: "Chat",
               url: "cong-dong",
               defaults: new { controller = "Chat", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "ungdunghocthongminh.Controllers" }
           );

            routes.MapRoute(
               name: "Schedule",
               url: "lich-hoc",
               defaults: new { controller = "Schedule", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "ungdunghocthongminh.Controllers" }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "ungdunghocthongminh.Controllers" }
            );
        }
    }
}
