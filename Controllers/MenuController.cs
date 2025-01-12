using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ungdunghocthongminh.Models;

namespace ungdunghocthongminh.Controllers
{
    public class MenuController : Controller
    {
        private ApplicationDbContext  db= new ApplicationDbContext();
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MenuTop()
        {
            var items =db.Categories.OrderBy(x => x.Position).ToList();
            return PartialView("_Menutop",items);
        }
        public ActionResult MenuLetf(int? id)
        {
            if(id  == null)
            {
                ViewBag.CateId = id;
            }
            var items = db.DocumentCategories.ToList();
            return PartialView("_MenuLetf", items);
        }
        public ActionResult MenuExam(int? id)
        {
            if (id == null)
            {
                ViewBag.CateId = id;
            }
            var items = db.DocumentCategories.ToList();
            return PartialView("_MenuExam", items);
        }
    }
}