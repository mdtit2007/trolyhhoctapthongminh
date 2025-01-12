using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ungdunghocthongminh.Models;

namespace ungdunghocthongminh.Controllers
{
  
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var tomorrow = DateTime.Now.AddDays(1).Date;
            var hasScheduleTomorrow = db.Schedules.Any(m => DbFunctions.TruncateTime(m.Start) == tomorrow);

            if (hasScheduleTomorrow)
            {
                // Thông báo đã được thay đổi
                ViewBag.ReminderText = "Bạn có lịch học vào ngày mai, hãy kiểm tra đừng bỏ lỡ.";
            }
            else
            {
                ViewBag.ReminderText = null;
            }

            return View();
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