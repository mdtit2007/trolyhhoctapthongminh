# 📚 Trợ Lý Học Tập Thông Minh | Smart Study Assistant

> 🌟 Một nền tảng web hỗ trợ học tập thông minh, giúp học sinh, giáo viên và phụ huynh quản lý, theo dõi và cải thiện quá trình học tập một cách hiệu quả.  
> 🌟 A smart web-based learning assistant platform that helps students, teachers, and parents manage, track, and improve the learning process effectively.

---

## 📖 Giới thiệu | Introduction

**Tiếng Việt**  
Dự án **Trợ Lý Học Tập Thông Minh** được xây dựng cho **Cuộc Thi Khoa Học – Kỹ Thuật cấp tỉnh năm 2025**.  
Ứng dụng cung cấp các tính năng:

- Quản lý nội dung học tập
- Tương tác thời gian thực giữa giáo viên và học sinh
- Lên lịch học tập,sự kiện và thông báo cho học sinh lịch học sự kiện quan trọng
- Tích hợp AI để hỗ trợ trả lời câu hỏi và gợi ý nội dung học tập

**English**  
The **Smart Study Assistant** project was developed for the **Provincial Science and Technology Competition 2025**.  
The application provides:

- Learning content management
- Real-time interaction between teachers and students
- Schedule classes, events and notify students of important class and event schedules
- AI integration for answering questions and suggesting learning materials

---

## 🛠 Công nghệ sử dụng | Technologies Used

- **ASP.NET MVC** – Backend framework
- **C#** – Main backend language
- **SignalR** – Real-time communication
- **JavaScript / jQuery** – Frontend scripting
- **HTML5 / CSS3 / SCSS** – User interface
- **SQL Server** – Database management
- **Entity Framework** – ORM for database access

---

## 📂 Cấu trúc dự án | Project Structure

```plaintext
trolyhhoctapthongminh/
│── .vs/                 # Thiết lập Visual Studio | Visual Studio settings
│── App_Start/           # RouteConfig, FilterConfig, BundleConfig
│── Areas/
│   └── Admin/           # Khu vực quản trị | Admin area
│── Common/              # Tiện ích & helper chung | Common utilities & helpers
│── Content/             # CSS, SCSS, hình ảnh | Stylesheets & images
│── Controllers/         # Xử lý yêu cầu từ client | Handle client requests
│── Hubs/                # Kết nối thời gian thực (SignalR) | Real-time hubs
│── Migrations/          # Quản lý phiên bản CSDL | Database migrations
│── Models/              # Mô hình dữ liệu | Data models
│── Properties/          # Thuộc tính dự án | Project properties
│── Scripts/             # JavaScript, jQuery, plugin | Client scripts
│── Uploads/             # Tệp người dùng tải lên | User uploads
│── Views/               # Giao diện Razor (MVC) | Razor views
│── bin/                 # Thư mục build output | Build output
│── obj/                 # Tệp tạm khi build | Build intermediates
│── Global.asax          # Entry point ứng dụng | Application entry
│── Global.asax.cs
│── Startup.cs           # Cấu hình OWIN/SignalR | OWIN/SignalR startup
│── Web.config           # Cấu hình ứng dụng | App configuration
│── Web.Debug.config
│── Web.Release.config
│── favicon.ico
│── hocthongminh.sql     # Script CSDL | Database script
│── packages.config      # Phụ thuộc NuGet | NuGet dependencies
│── ungdunghocthongminh.csproj
│── ungdunghocthongminh.csproj.user
└── ungdunghocthongminh.sln
```

---

## 🚀 Cài đặt & Chạy dự án | Installation & Running

**Tiếng Việt**

> Dự án là **ASP.NET MVC 5 (không phải .NET Core)**, sử dụng **IIS Express** khi chạy từ Visual Studio.

1. Cài đặt **Visual Studio 2019/2022** với workload **.NET Framework 4.x development**.
2. Cài **SQL Server** (hoặc **SQL Server Express/LocalDB**).
3. Khôi phục CSDL từ file `hocthongminh.sql`.
4. Mở `ungdunghocthongminh.sln` bằng Visual Studio.
5. Visual Studio sẽ tự **Restore NuGet packages** (hoặc vào `Tools → NuGet Package Manager → Restore`).
6. Cập nhật **connectionString** trong `Web.config` nếu cần.
7. Chạy bằng **IIS Express** (phím `F5`).
8. Truy cập theo URL mà VS hiển thị (ví dụ `http://localhost:xxxxx`).

**English**

> This is an **ASP.NET MVC 5 (non-.NET Core)** app using **IIS Express** when running from Visual Studio.

1. Install **Visual Studio 2019/2022** with **.NET Framework 4.x development** workload.
2. Install **SQL Server** (or **SQL Server Express/LocalDB**).
3. Restore the database from `hocthongminh.sql`.
4. Open `ungdunghocthongminh.sln` in Visual Studio.
5. Visual Studio will **Restore NuGet packages** (or use `Tools → NuGet Package Manager → Restore`).
6. Update the **connectionString** in `Web.config` as needed.
7. Run with **IIS Express** (`F5`).
8. Browse the URL shown by VS (e.g., `http://localhost:xxxxx`).

---

## ✨ Tính năng chính | Key Features

- 👩‍🏫 **Quản lý lớp học & bài giảng** | Class & lesson management
- 💬 **Chat thời gian thực** | Real-time chat
- 📊 **Báo cáo tiến độ học tập** | Learning progress reports
- 🤖 **Trợ lý AI gợi ý nội dung** | AI assistant suggestions
- 🔒 **Hệ thống phân quyền** | Role-based access control

---

## 📜 Giấy phép | License

MIT License – Xem chi tiết tại [LICENSE](LICENSE)  
MIT License – See [LICENSE](LICENSE) for details.

---

## 👥 Tác giả | Authors

- **Mdtit07** – Phát triển và duy trì dự án | Development & maintenance
