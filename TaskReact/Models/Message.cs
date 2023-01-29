using System;
using TaskReact.Enum;

namespace TaskReact.Models
{
    public class Message
    {
        public int Id { get; set; }

        public DateTime Created { get; set; }
        public string MessageText { get; set; }
        public string PhoneNumber { get; set; }
        public Statuses Status { get; set; }
        public string SendersName { get; set; }
    }
}
