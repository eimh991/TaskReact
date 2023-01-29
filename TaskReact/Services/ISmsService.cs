using TaskReact.Enum;
using TaskReact.Models;

namespace TaskReact.Services
{
    public interface ISmsService
    {
        public Message CreateMessage(string name, string text, string phoneNumber, Statuses status);
    }
}
