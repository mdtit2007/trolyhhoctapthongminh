using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ungdunghocthongminh.Models;
using ungdunghocthongminh.Models.EF;
using Microsoft.AspNet.Identity;

namespace ungdunghocthongminh.Controllers
{
    public class ScheduleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Schedule
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PartialSchedule(int weekOffset = 0, string filterType = "all")
        {
            // Kiểm tra xem người dùng đã đăng nhập chưa
            if (!User.Identity.IsAuthenticated)
            {
                // Nếu chưa đăng nhập, trả về thông báo yêu cầu đăng nhập kèm JavaScript
                return Content("<script type='text/javascript'>"
                                + "if(confirm('Bạn chưa đăng nhập. Bạn muốn đăng nhập ngay bây giờ để xem lịch học và lịch thi của mình?')) {"
                                + "window.location.href = '/Account/Login'; } else { window.history.back(); }</script>");
            }

            // Lấy thông tin lớp học của người dùng
            string userId = User.Identity.GetUserId();
            var user = db.Users.Find(userId);
            string className = user.lop; // Lấy tên lớp từ thông tin người dùng

            // Tính toán ngày bắt đầu của tuần (Thứ 2) trong tuần hiện tại
            DateTime today = DateTime.Now;
            int diff = today.DayOfWeek - DayOfWeek.Monday;
            DateTime startOfWeek = today.AddDays(-diff).Date; // Thứ 2 của tuần này

            // Cộng hoặc trừ 7 ngày theo weekOffset
            startOfWeek = startOfWeek.AddDays(weekOffset * 7);

            // Lấy ngày kết thúc của tuần (Chủ nhật)
            DateTime endOfWeek = startOfWeek.AddDays(6);

            // Lấy các lịch học trong tuần từ startOfWeek đến endOfWeek và lọc theo lớp
            var items = db.Schedules
                           .Where(x => x.Start >= startOfWeek && x.Start <= endOfWeek)
                           .Where(x => x.className == className) // Lọc theo lớp của người dùng
                           .ToList();

            // Nếu filter là "schedule" chỉ lấy Lịch học
            if (filterType == "schedule")
            {
                items = items.Where(x => x.ScheduleCategoryId == 1).ToList(); // Giả sử "1" là ID của Lịch học
            }
            // Nếu filter là "exam" chỉ lấy Lịch thi
            else if (filterType == "exam")
            {
                items = items.Where(x => x.ScheduleCategoryId == 2).ToList(); // Giả sử "2" là ID của Lịch thi
            }
            // Nếu filter là "sk" chỉ lấy Lịch sự kiện
            if (filterType == "sk")
            {
                items = items.Where(x => x.ScheduleCategoryId == 5).ToList();
            }

            // Trả về PartialView với danh sách lịch học đã lọc
            ViewBag.WeekOffset = weekOffset;
            ViewBag.StartOfWeek = startOfWeek.ToString("dd/MM/yyyy"); // Truyền thông tin ngày bắt đầu tuần
            ViewBag.EndOfWeek = endOfWeek.ToString("dd/MM/yyyy"); // Truyền thông tin ngày kết thúc tuần

            return PartialView("_PartialSchedule", items);
        }


        public ActionResult NhacNho()
        {
            // Kiểm tra nếu người dùng chưa đăng nhập
            if (!User.Identity.IsAuthenticated)
            {
                // Truyền thông báo JavaScript xuống View
                ViewBag.ShowLoginAlert = true;
                return View();
            }

            // Kiểm tra nếu người dùng có vai trò là "Giáo Viên"
            if (User.IsInRole("Giáo Viên"))
            {
                // Nếu là giáo viên, không hiển thị nhắc nhở
                ViewBag.ShowReminder = false;
                return View();
            }

            // Lấy thông tin lớp học của người dùng
            string userId = User.Identity.GetUserId();
            var user = db.Users.Find(userId);
            string className = user.lop; // Lấy tên lớp từ thông tin người dùng

            // Lọc lịch học theo lớp của người dùng
            var items = db.Schedules
                          .Where(x => x.className == className) // Chỉ lấy lịch học của lớp này
                          .ToList();

            // Trả về View với danh sách lịch học đã lọc và hiển thị nhắc nhở
            ViewBag.ShowReminder = true;
            return View(items);
        }




    }
}
