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

            return _dbSet.Where(e => e.Date >= minDate && e.Date <= maxDate).ToList();
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

            events.ForEach(e => e.Date = e.Date.AddDays((double)e.RecursionDays).AddMonths((int)e.RecursionMonths).AddYears((int)e.RecursionYears));

            Save();
        }
    }
}
