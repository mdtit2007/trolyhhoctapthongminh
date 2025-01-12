using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ungdunghocthongminh.Models;

namespace ungdunghocthongminh.Controllers
{
    public class ChatController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Chat
        public ActionResult Index()
        {
           return View();
        }
        [HttpPost]
        public ActionResult UploadFile()
        {
            var file = Request.Files["file"];
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Uploads"), fileName);
                file.SaveAs(path);

                return Json(new { filePath = Url.Content("~/Uploads/" + fileName) });
            }
            return Json(new { filePath = string.Empty });
        }
    }
}