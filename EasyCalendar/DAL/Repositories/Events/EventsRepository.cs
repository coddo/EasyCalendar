using EasyCalendar.DAL.Context;
using EasyCalendar.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyCalendar.DAL.Repositories.Events
{
    public class EventsRepository : BaseRepository<Event>
    {
        internal EventsRepository(DatabaseContext context)
            : base(context)
        {
        }

        public List<Event> GetActiveEventsAsList(DateTime minDate, DateTime maxDate)
        {
            if (minDate >= DateTime.Today)
                minDate = DateTime.Today;

            return _dbSet.Where(e => (e.Date >= minDate && e.Date <= maxDate) || (e.Date < DateTime.Today && !e.IsSeen && e.IsRecursive)).ToList();
        }

        public Event[] GetEventsForDate(DateTime date)
        {
            return _dbSet.Where(e => e.Date == date).ToArray();
        }

        public Event[] GetMissedEvents()
        {
            return _dbSet.Where(e => e.Date < DateTime.Today && !e.IsSeen).ToArray();
        }

        public Event[] GetActiveEvents()
        {
            return _dbSet.Where(e => e.Date >= DateTime.Today).ToArray();
        }

        public Event[] GetPassedEvents()
        {
            return _dbSet.Where(e => e.Date < DateTime.Today).ToArray();
        }

        public void RescheduleRecursiveEvents()
        {
            var events = _dbSet.Where(e => e.IsRecursive && e.IsSeen).ToList();

            events.ForEach(ev =>
            {
                // Reschedule events recursively until their new date is after TODAY
                while (ev.Date < DateTime.Today)
                {
                    // Create a standalone event
                    Insert(new Event
                    {
                        Date = ev.Date,
                        Details = ev.Details,
                        Title = ev.Title,
                        IsSeen = true,
                        IsRecursive = false,
                        RecursionDays = 0,
                        RecursionMonths = 0,
                        RecursionYears = 0
                    });

                    // Reschedule the event with one step
                    ev.Date = ev.Date.AddDays((double)ev.RecursionDays).AddMonths((int)ev.RecursionMonths).AddYears((int)ev.RecursionYears);
                }
            });

            Save();
        }
    }
}
