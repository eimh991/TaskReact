using Microsoft.EntityFrameworkCore;

namespace TaskReact.Models
{
    public class MessageContext:DbContext
    {
        public DbSet<Message> Messages { get; set; }
        public MessageContext(DbContextOptions<MessageContext> options) : base(options) { }
    }
}
