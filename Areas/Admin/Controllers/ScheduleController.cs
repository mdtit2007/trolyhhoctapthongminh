using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ungdunghocthongminh.Models;
using ungdunghocthongminh.Models.EF;

namespace ungdunghocthongminh.Areas.Admin.Controllers
{
    public class ScheduleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Schedule
        public ActionResult Index(string Searchtext, int? page)
        {
            var pageSize = 10;
            if (page == null)
            {
                page = 1;
            }
            IEnumerable<Schedule> items = db.Schedules.OrderByDescending(x => x.Id);
            if (!string.IsNullOrEmpty(Searchtext))
            {
                items = items.Where(x => x.Alias.Contains(Searchtext) || x.Title.Contains(Searchtext));
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }
        public ActionResult Add()
        {
            ViewBag.ScheduleCategory = new SelectList(db.ScheduleCategories, "Id", "Title");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Schedule model)
        {
            if (ModelState.IsValid)
            {
                db.Schedules.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ScheduleCategory = new SelectList(db.ScheduleCategories, "Id", "Title");
            return View(model);
        }
        public ActionResult View(int id)
        {
            var items = db.Schedules.Find(id);
            return View(items);
        }
        public ActionResult Edit(int id)
        {
            ViewBag.ScheduleCategory = new SelectList(db.ScheduleCategories.ToList(), "Id", "Title");
            var items = db.Schedules.Find(id);
            return View(items);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Schedule model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                model.Alias = ungdunghocthongminh.Models.Common.Filter.FilterChar(model.Title);
                db.Schedules.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.Schedules.Find(id);
            if (item != null)
            {
                db.Schedules.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }

    }
}