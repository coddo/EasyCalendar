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
                .Property(p => p.Title).IsRequired();

            builder.Entity<Event>()
                .Property(p => p.Details).IsOptional();

            builder.Entity<Event>()
                .Property(p => p.IsRecursive).IsRequired();

            builder.Entity<Event>()
                .Property(p => p.RecursionDays).IsOptional();

            builder.Entity<Event>()
                .Property(p => p.RecursionMonths).IsOptional();

            builder.Entity<Event>()
                .Property(p => p.RecursionYears).IsOptional();

            builder.Entity<Event>()
                .Property(p => p.Date).IsRequired();

            builder.Entity<Event>()
                .Property(p => p.Seen).IsRequired();
        }
    }
}
