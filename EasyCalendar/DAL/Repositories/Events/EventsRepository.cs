using EasyCalendar.DAL.Context;
using EasyCalendar.DAL.Models;
using System;
using System.Linq;

namespace EasyCalendar.DAL.Repositories.Events
{
    public class EventsRepository : BaseRepository<Event>
    {
        internal EventsRepository(DatabaseContext context)
            : base(context)
        {
        }

        public Event[] GetEventsForDate(DateTime date)
        {
            return _dbSet.Where(e => e.Date == date).ToArray();
        }
    }
}
