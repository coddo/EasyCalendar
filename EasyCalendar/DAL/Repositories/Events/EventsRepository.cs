using EasyCalendar.DAL.Context;
using EasyCalendar.DAL.Models;

namespace EasyCalendar.DAL.Repositories.Events
{
    public class EventsRepository : BaseRepository<Event>
    {
        internal EventsRepository(DatabaseContext context)
            : base(context)
        {
        }
    }
}
