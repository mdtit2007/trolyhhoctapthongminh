using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ungdunghocthongminh.Models;
using ungdunghocthongminh.Models.EF;

namespace ungdunghocthongminh.Areas.Admin.Controllers
{
    public class DocumentCategoryController : Controller
    {
        private ApplicationDbContext db= new ApplicationDbContext();
        // GET: Admin/DocumentCategory
        public ActionResult Index()
        {
            var items = db.DocumentCategories;
            return View(items);
        }
        public ActionResult Add() 
        { 
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(DocumentCategory model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                model.Alias = ungdunghocthongminh.Models.Common.Filter.FilterChar(model.Title);
                db.DocumentCategories.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            var item = db.DocumentCategories.Find(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DocumentCategory model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                model.Alias = ungdunghocthongminh.Models.Common.Filter.FilterChar(model.Title);
                db.DocumentCategories.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.DocumentCategories.Find(id);
            if (item != null)
            {
                db.DocumentCategories.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
        
    }
}