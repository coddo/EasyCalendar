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

        public List<Event> GetPossibleEventsAsList(DateTime maxDate)
        {
            return _dbSet.Where(e => e.Date <= maxDate).ToList();
        }

        public Event[] GetEventsForDate(DateTime date)
        {
            return _dbSet.Where(e => e.Date == date).ToArray();
        }

        public Event[] GetMissedEvents()
        {
            return _dbSet.Where(e => e.Date < DateTime.Today && !e.Seen).ToArray();
        }

        public Event[] GetActiveEvents()
        {
            return _dbSet.Where(e => e.Date >= DateTime.Today).ToArray();
        }

        public Event[] GetPassedEvents()
        {
            return _dbSet.Where(e => e.Date < DateTime.Today).ToArray();
        }
    }
}
