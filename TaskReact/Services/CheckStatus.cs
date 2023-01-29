using System;
using TaskReact.Enum;

namespace TaskReact.Services
{
    public class CheckStatus:ICheckStatusService
    {
        public Statuses GenerateStatus()
        {
            Statuses status = new Statuses();
            Random rnd = new Random();
            status = (Statuses)rnd.Next(0, 3);
            return status;

        }
    }
}
