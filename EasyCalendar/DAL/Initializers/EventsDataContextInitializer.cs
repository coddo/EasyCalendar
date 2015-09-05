using EasyCalendar.DAL.Models;
using System.Data.Entity;

namespace EasyCalendar.DAL.Initializers
{
    public static class EventsDataContextInitializer
    {
        public static void InitializeEventsDataContext(DbModelBuilder builder)
        {
            builder.Entity<EventData>()
                .HasKey(k => k.Id);

            builder.Entity<EventData>()
                .Property(p => p.Title).IsRequired();

            builder.Entity<EventData>()
                .Property(p => p.Details).IsOptional();

            builder.Entity<EventData>()
                .Property(p => p.IsRecursive).IsRequired();

            builder.Entity<EventData>()
                .Property(p => p.RecursionDays).IsOptional();

            builder.Entity<EventData>()
                .Property(p => p.RecursionMonths).IsOptional();

            builder.Entity<EventData>()
                .Property(p => p.RecursionYears).IsOptional();

            builder.Entity<EventData>()
                .HasMany(p => p.Events)
                .WithRequired(p => p.EventData)
                .WillCascadeOnDelete(true);
        }
    }
}
