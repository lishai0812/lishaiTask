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
            new Message { Content = "Hello World", Date = DateTime.Now, UserId = "123456789" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Message>> GetMessages()
        {
            return Ok(messages);
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
