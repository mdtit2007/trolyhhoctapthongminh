using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;

namespace ungdunghocthongminh.Common
{
    public class Common
    {
        // Lấy thông tin Email và Password từ file cấu hình (App.config hoặc Web.config)
        private static string password = ConfigurationManager.AppSettings["PasswordEmail"]; // Mật khẩu email
        private static string Email = ConfigurationManager.AppSettings["Email"]; // Địa chỉ email

        // Hàm gửi email
        public static bool SendMail(string name, string subject, string content, string toMail)
        {
            bool rs = false; // Biến kết quả trả về, mặc định là false
            try
            {
                // Tạo một đối tượng MailMessage để gửi email
                MailMessage message = new MailMessage();

                // Cấu hình SMTP client để gửi email
                var smtp = new SmtpClient();
                {
                    smtp.Host = "smtp.gmail.com"; // Địa chỉ máy chủ SMTP
                    smtp.Port = 587; // Cổng giao tiếp SMTP
                    smtp.EnableSsl = true; // Bật mã hóa SSL để bảo mật
                    smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network; // Phương thức giao tiếp qua mạng
                    smtp.UseDefaultCredentials = false; // Không sử dụng thông tin đăng nhập mặc định
                    smtp.Credentials = new NetworkCredential()
                    {
                        UserName = Email, // Email sử dụng để gửi
                        Password = password // Mật khẩu email
                    };
                }

                // Cấu hình email cần gửi
                MailAddress fromAddress = new MailAddress(Email, name); // Email gửi và tên hiển thị
                message.From = fromAddress; // Đặt email gửi
                message.To.Add(toMail); // Thêm email người nhận
                message.Subject = subject; // Chủ đề email
                message.IsBodyHtml = true; // Nội dung email dạng HTML
                message.Body = content; // Nội dung email

                // Gửi email
                smtp.Send(message);
                rs = true; // Nếu không có lỗi, kết quả trả về là true
            }
            catch (Exception ex)
            {
                // Ghi lỗi ra console nếu xảy ra lỗi
                Console.WriteLine(ex.Message);
                rs = false; // Kết quả trả về false nếu có lỗi
            }
            return rs; // Trả về kết quả (true nếu gửi thành công, false nếu thất bại)
        }

        // Hàm định dạng số theo kiểu chuỗi (ví dụ: 1,234.56)
        public static string FormatNumber(object value, int SoSauDauPhay = 2)
        {
            bool isNumber = IsNumeric(value); // Kiểm tra giá trị có phải là số không
            decimal GT = 0; // Giá trị số (nếu là số)
            if (isNumber)
            {
                GT = Convert.ToDecimal(value); // Chuyển đổi sang kiểu decimal
            }
            string str = ""; // Chuỗi kết quả
            string thapPhan = ""; // Phần thập phân
            for (int i = 0; i < SoSauDauPhay; i++) // Tạo chuỗi định dạng thập phân
            {
                thapPhan += "#"; // Ví dụ: nếu SoSauDauPhay = 2 -> thapPhan = "##"
            }
            if (thapPhan.Length > 0) thapPhan = "." + thapPhan; // Thêm dấu "." trước phần thập phân
            string snumformat = string.Format("0:#,##0{0}", thapPhan); // Định dạng chuỗi số
            str = String.Format("{" + snumformat + "}", GT); // Áp dụng định dạng cho giá trị số

            return str; // Trả về chuỗi định dạng
        }

        // Hàm kiểm tra một giá trị có phải là số hay không
        private static bool IsNumeric(object value)
        {
            return value is sbyte       // Kiểu sbyte
                   || value is byte     // Kiểu byte
                   || value is short    // Kiểu short
                   || value is ushort   // Kiểu ushort
                   || value is int      // Kiểu int
                   || value is uint     // Kiểu uint
                   || value is long     // Kiểu long
                   || value is ulong    // Kiểu ulong
                   || value is float    // Kiểu float
                   || value is double   // Kiểu double
                   || value is decimal; // Kiểu decimal
        }


    }
}