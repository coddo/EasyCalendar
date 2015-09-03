using EasyCalendar.DAL.Initializers;
using EasyCalendar.DAL.Models;
using System.Data.Entity;
using System.Data.SQLite;

namespace EasyCalendar.DAL.Context
{
    public class DatabaseContext : DbContext
    {
        public static readonly string DATABASE_NAME = "Events.db";

        protected internal DatabaseContext()
            : base(new SQLiteConnection() { ConnectionString =
                    new SQLiteConnectionStringBuilder()
                        { DataSource = DATABASE_NAME, ForeignKeys = true }
                    .ConnectionString }, true)
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
