using EasyCalendar.DAL.Context;
using EasyCalendar.DAL.Models;

namespace EasyCalendar.DAL.Repositories.Events
{
    public class EventsDataRepository : BaseRepository<EventData>
    {
        internal EventsDataRepository(DatabaseContext context)
            : base(context)
        {
        }
    }
}
