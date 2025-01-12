using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ungdunghocthongminh.Models.EF;
using ungdunghocthongminh.Models;

namespace ungdunghocthongminh.Controllers
{
    public class AdviseController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Advise
        public ActionResult Index(int? page)
        {

            var pageSize = 10;
            if (page == null)
            {
                page = 1;
            }
            IEnumerable<Advise> items = db.Advise.OrderByDescending(x => x.CreatedDate);
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }

        public ActionResult Detail(int id)
        {
            var item = db.Advise.Find(id);
            return View(item);
        }
    }
}