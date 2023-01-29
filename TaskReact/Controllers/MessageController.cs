using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskReact.Models;
using TaskReact.Services;

namespace TaskReact.Controllers
{
    [Route("api/message")]
    [ApiController]
    public class MessageController : ControllerBase
    {

        private ISmsService smsService { get; set; }
        private ICheckStatusService checkStatusService { get; set; }
        private MessageContext db { get; set; }

        public MessageController(MessageContext db, ISmsService _smsService, ICheckStatusService checkStatus)
        {
            this.db = db;
            smsService = _smsService;
            checkStatusService = checkStatus;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MessageInfo>>> Get()
        {

            return await db.Messages.Select(mess => new MessageInfo(mess)).ToListAsync();

        }

        [HttpPost]
        public async Task<ActionResult<Message>> Post([FromForm] IFormCollection formData)
        {
            MessageInfo messageInfo= new MessageInfo();
            messageInfo.Sendername = formData["senderName"];
            messageInfo.MessageText= formData["textMessage"];
            messageInfo.PhoneNumber = formData["phoneNumber"];
            if (messageInfo.MessageText != "" && messageInfo.PhoneNumber != " ")
            {
                Message message = new Message();
                message = smsService.CreateMessage(messageInfo.Sendername, messageInfo.MessageText, messageInfo.PhoneNumber, checkStatusService.GenerateStatus());
                db.Add(message);
                await db.SaveChangesAsync();
                return Ok(new MessageInfo(message));
            }
            else
            {
                return BadRequest();
            }
        }
       
    }
}

