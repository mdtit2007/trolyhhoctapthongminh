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
    public class ExamController : Controller
    {
        private ApplicationDbContext db =new ApplicationDbContext();
        // GET: Exam
        public ActionResult Index(string Searchtext, int? page)
        {
            var pageSize = 12;
            if (page == null)
            {
                page = 1;
            }
            IEnumerable<Exam> items = db.Exams.OrderBy(x => x.Id);
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
        public ActionResult ExamCategory(int id, string alias, int? page)
        {
            // Số trang hiện tại (mặc định là 1 nếu không truyền page)
            int pageNumber = page ?? 1;

            // Số lượng mục hiển thị trên mỗi trang
            int pageSize = 10;

            // Lấy danh sách Document
            var items = db.Exams.AsQueryable(); // Queryable để hỗ trợ LINQ và phân trang

            if (id > 0)
            {
                items = items.Where(x => x.DocumentCategoryId == id);
            }

            var cate = db.DocumentCategories.Find(id);
            if (cate != null)
            {
                ViewBag.CateName = cate.Title;
            }
            ViewBag.CateId = id;

            // Chuyển danh sách thành dạng PagedList
            var pagedItems = items.OrderBy(x => x.Id).ToPagedList(pageNumber, pageSize);

            // Trả về view với PagedList
            return View(pagedItems);
        }
        public ActionResult Detail( string alias,int id)
        {
            var item = db.Exams.Find(id);
            return View(item);
        }
    }
}