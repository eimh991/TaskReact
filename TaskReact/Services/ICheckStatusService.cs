using TaskReact.Enum;

namespace TaskReact.Services
{
    public interface ICheckStatusService
    {
        public Statuses GenerateStatus();
    }
}
