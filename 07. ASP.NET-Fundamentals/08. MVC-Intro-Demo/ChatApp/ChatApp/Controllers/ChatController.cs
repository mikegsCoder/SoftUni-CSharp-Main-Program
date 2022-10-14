using ChatApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers
{
    public class ChatController : Controller
    {
        private static List<KeyValuePair<string, string>> Messages = new List<KeyValuePair<string, string>>();

        public IActionResult Show()
        {
            if(Messages.Count < 0)
            {
                return View(new ChatViewModel());
            }
            var chatModel = new ChatViewModel()
            {
                Messages = Messages
                .Select(m => new MessageViewModel()
                {
                    Sender = m.Key,
                    MessageText = m.Value
                })
                .ToList()
            };

            return View(chatModel);
        }

    }
}
