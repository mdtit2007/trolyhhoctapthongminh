# 📚 Smart Study Assistant

> 🌟 A smart web-based learning assistant platform that helps students, teachers, and parents manage, track, and improve the learning process effectively.

---

## 📖 Introduction

The **Smart Study Assistant** project was developed for the **Provincial Science and Technology Competition 2025**.  
The application provides:

- Learning content management
- Real-time interaction between teachers and students
- Schedule classes, events and notify students of important class and event schedules
- AI integration for answering questions and suggesting learning materials

---

## 🛠 Technologies Used

- **ASP.NET MVC** – Backend framework
- **C#** – Main backend language
- **SignalR** – Real-time communication
- **JavaScript / jQuery** – Frontend scripting
- **HTML5 / CSS3 / SCSS** – User interface
- **SQL Server** – Database management
- **Entity Framework** – ORM for database access

---

## 📂 Project Structure

```plaintext
trolyhhoctapthongminh/
│── .vs/                 # Visual Studio settings
│── App_Start/           # RouteConfig, FilterConfig, BundleConfig
│── Areas/
│   └── Admin/           # Admin area
│── Common/              # Common utilities & helpers
│── Content/             # Stylesheets & images
│── Controllers/         # Handle client requests
│── Hubs/                # Real-time hubs
│── Migrations/          # Database migrations
│── Models/              # Data models
│── Properties/          # Project properties
│── Scripts/             # Client scripts
│── Uploads/             # User uploads
│── Views/               # Razor views
│── bin/                 # Build output
│── obj/                 # Build intermediates
│── Global.asax          # Application entry
│── Global.asax.cs
│── Startup.cs           # OWIN/SignalR startup
│── Web.config           # App configuration
│── Web.Debug.config
│── Web.Release.config
│── favicon.ico
│── hocthongminh.sql     # Database script
│── packages.config      # NuGet dependencies
│── ungdunghocthongminh.csproj
│── ungdunghocthongminh.csproj.user
└── ungdunghocthongminh.sln
```

---

## 🚀 Installation & Running

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

## ✨ Key Features

- 👩‍🏫 Class & lesson management
- 💬 Real-time chat
- 📊 Learning progress reports
- 🤖 AI assistant suggestions
- 🔒 Role-based access control

---

## 📜 License

MIT License – See [LICENSE](LICENSE) for details.

---

## 👥 Tác giả | Authors

- **Mdtit07** – Phát triển và duy trì dự án | Development & maintenance
