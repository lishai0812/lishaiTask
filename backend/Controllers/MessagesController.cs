using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MessagingSystemAPI.Models;
using System;
using System.Collections.Generic;

namespace MessagingSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MessagesController : ControllerBase
    {
        private static List<Message> messages = new List<Message>
        {
            new Message { Content = "Hello World", Date = DateTime.Now, UserId = "123456789" },
            new Message { Content = "whats up", Date = DateTime.Now, UserId = "123456789" },
            new Message { Content = "good day !", Date = DateTime.Now, UserId = "123456789" },
            new Message { Content = "good night", Date = DateTime.Now, UserId = "123456789" },
            new Message { Content = "Hello World", Date = DateTime.Now, UserId = "111111111" },
            new Message { Content = "whats up", Date = DateTime.Now, UserId = "111111111" },
            new Message { Content = "Hello World", Date = DateTime.Now, UserId = "222222222" },
            new Message { Content = "whats up", Date = DateTime.Now, UserId = "222222222" },
            new Message { Content = "Hello World", Date = DateTime.Now, UserId = "987654321" },
            new Message { Content = "whats up", Date = DateTime.Now, UserId = "987654321" },
        };

        [HttpGet("{userId}")]
        public IActionResult GetMessages(string userId)
        {
            var userMessages = messages.Where(m => m.UserId == userId).ToList();
            return Ok(userMessages);
        }

        [HttpPost]
        public ActionResult PostMessage([FromBody] Message message)
        {
            if (string.IsNullOrWhiteSpace(message.Content) || string.IsNullOrWhiteSpace(message.UserId))
            {
                return BadRequest(new { error = "Message content and UserId are required" });
            }

            message.Date = DateTime.Now;
            messages.Add(message);
            return Ok();
        }
    }
}
