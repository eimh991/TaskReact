using System;

namespace TaskReact.Models
{
    public class MessageInfo
    {
        public DateTime Created { get; set; }
        public string Sendername { get; set; }
        public string MessageText { get; set; }

        public string PhoneNumber { get; set; }

        public string Status { get; set; }

        public MessageInfo() { }
        public MessageInfo(Message mess)
        {

            Created = mess.Created;
            MessageText = mess.MessageText;
            PhoneNumber = mess.PhoneNumber;
            Status = mess.Status.ToString();
            Sendername = mess.SendersName;
        }
    }
}
