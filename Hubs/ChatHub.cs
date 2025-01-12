using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.IO;
using System.Linq;
using ungdunghocthongminh.Models;
using ungdunghocthongminh.Models.EF;

namespace ungdunghocthongminh.Hubs
{
    [HubName("chat")]
    public class ChatHub : Hub
    {
        private readonly ApplicationDbContext _db;

        public ChatHub()
        {
            _db = new ApplicationDbContext();
        }

        public void Connect(string name)
        {
            Clients.Caller.connect(name);
        }

        public void Message(string name, string message, string filePath = null)
        {
            // Lưu tin nhắn vào database
            var chatMessage = new ChatMessage
            {
                UserName = name,
                Message = message,
                FilePath = filePath,
                Timestamp = DateTime.Now
            };
            _db.ChatMessages.Add(chatMessage);
            _db.SaveChanges();

            // Gửi tin nhắn đến tất cả người dùng
            Clients.All.message(name, message, filePath);
        }

        public void LoadMessages()
        {
            var messages = _db.ChatMessages
                              .OrderBy(m => m.Timestamp)
                              .Select(m => new
                              {
                                  m.UserName,
                                  m.Message,
                                  m.FilePath,
                                  m.Timestamp
                              })
                              .ToList();

            Clients.Caller.loadMessages(messages);
        }
    }
}
