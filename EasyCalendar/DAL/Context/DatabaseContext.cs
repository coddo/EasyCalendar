using EasyCalendar.DAL.Initializers;
using EasyCalendar.DAL.Models;
using System.Data.Entity;

namespace EasyCalendar.DAL.Context
{
    public class DatabaseContext : DbContext
    {
        protected internal DatabaseContext()
            : base("EventsDb")
        {
            System.Data.Entity.Database.SetInitializer(new DatabaseInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            EventsContextInitializer.InitializeEventsContext(modelBuilder);
            EventsDataContextInitializer.InitializeEventsDataContext(modelBuilder);
        }

        public DbSet<EventData> EventsData { get; set; }

        public DbSet<Event> Events { get; set; }
    }
}
