using Microsoft.EntityFrameworkCore;
using CW_EventsManagerApp.Models;

namespace CW_EventsManagerApp.Data
{
    public class EventDBContext : DbContext
    {
        public EventDBContext(DbContextOptions<EventDBContext> options) : base(options) { }

        public DbSet<Event> Events { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
