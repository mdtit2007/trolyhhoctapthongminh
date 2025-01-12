using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using ungdunghocthongminh.Models;
using ungdunghocthongminh.Models.EF;

namespace ungdunghocthongminh.Controllers
{
    public class DigitalConversionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: DigitalConversion
        public ActionResult Index(int? page)
        {

            var pageSize = 10;
            if (page == null)
            {
                page = 1;
            }
            IEnumerable<DigitalConversion> items = db.DigitalConversions.OrderByDescending(x => x.CreatedDate);
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }
       
        public ActionResult Detail(int id)
        {
            var item = db.DigitalConversions.Find(id);
            return View(item);
        }
    }
}