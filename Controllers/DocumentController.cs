using Aspose.Words;
using PagedList;
using Spire.Doc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ungdunghocthongminh.Migrations;
using ungdunghocthongminh.Models;

namespace ungdunghocthongminh.Controllers
{
    public class DocumentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Document
        public ActionResult Index(string Searchtext, int? page)
        {
            var pageSize = 12;
            if (page == null)
            {
                page = 1;
            }
            IEnumerable<Models.EF.Document> items = db.Documents.OrderBy(x => x.Id);
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
public ActionResult DocumentCategory(int id, string alias, int? page)
    {
        // Số trang hiện tại (mặc định là 1 nếu không truyền page)
        int pageNumber = page ?? 1;

        // Số lượng mục hiển thị trên mỗi trang
        int pageSize = 10;

        // Lấy danh sách Document
        var items = db.Documents.AsQueryable(); // Queryable để hỗ trợ LINQ và phân trang

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
            var item = db.Documents.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            // Kiểm tra sự tồn tại của file
            if (!string.IsNullOrEmpty(item.FilePath) && System.IO.File.Exists(Server.MapPath(item.FilePath)))
            {
                var filePath = Server.MapPath(item.FilePath);
                var fileExtension = Path.GetExtension(filePath).ToLower();

                // Nếu là file Word, chuyển sang PDF
                if (fileExtension == ".doc" || fileExtension == ".docx")
                {
                    var pdfPath = Path.ChangeExtension(filePath, ".pdf");
                    if (!System.IO.File.Exists(pdfPath)) // Tránh chuyển đổi lại nếu đã có
                    {
                        // Chuyển đổi sang PDF
                        ConvertWordToPdf(filePath, pdfPath);
                    }
                    ViewBag.FilePath = Url.Content(item.FilePath.Replace(fileExtension, ".pdf"));
                }
                else
                {
                    ViewBag.FilePath = item.FilePath;
                }
            }
            else
            {
                ViewBag.FilePath = null; // File không tồn tại
            }

            return View(item);
        }

        private void ConvertWordToPdf(string wordPath, string pdfPath)
        {
            Spire.Doc.Document doc = new Spire.Doc.Document();
            doc.LoadFromFile(wordPath);
            doc.SaveToFile(pdfPath, Spire.Doc.FileFormat.PDF);
        }



    }
}