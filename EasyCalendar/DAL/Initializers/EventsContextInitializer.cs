using EasyCalendar.DAL.Models;
using System.Data.Entity;

namespace EasyCalendar.DAL.Initializers
{
    public static class EventsContextInitializer
    {
        public static void InitializeEventsContext(DbModelBuilder builder)
        {
            builder.Entity<Event>()
                .HasKey(k => k.Id);

            builder.Entity<Event>()
                .Property(p => p.Date).IsRequired();

            builder.Entity<Event>()
                .HasRequired(p => p.EventData)
                .WithMany(p => p.Events)
                .Map(m => m.MapKey("EventDataId"))
                .WillCascadeOnDelete(true);
        }
    }
}
