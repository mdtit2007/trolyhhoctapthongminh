using System;
using System.Web.Mvc;

namespace ungdunghocthongminh.Controllers
{
    public class ChatGPTController : Controller
    {
        // GET: ChatGPT/RedirectToChatGPT
        public ActionResult RedirectToChatGPT()
        {
            // URL của ChatGPT
            string chatGptUrl = "https://chat.openai.com/";

            // Chuyển hướng tới URL
            return Redirect(chatGptUrl);
        }
    }
}
