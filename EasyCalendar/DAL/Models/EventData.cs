using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyCalendar.DAL.Models
{
    [Table("EventsData")]
    public class EventData : BaseEntity
    {
        [Column("Title")]
        public string Title { get; set; }

        [Column("Details")]
        public string Details { get; set; }

        [Column("IsRecursive")]
        public bool IsRecursive { get; set; } = false;

        [Column("RecursionDays")]
        public int? RecursionDays { get; set; } = 0;

        [Column("RecursionMonths")]
        public int? RecursionMonths { get; set; } = 0;

        [Column("RecursionYears")]
        public int? RecursionYears { get; set; } = 0;

        public Collection<Event> Events { get; set; } = new Collection<Event>();
    }
}
