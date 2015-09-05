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
        public bool IsRecursive { get; set; }

        [Column("RecursionDays")]
        public int? RecursionDays { get; set; }

        [Column("RecursionMonths")]
        public int? RecursionMonths { get; set; }

        [Column("RecursionYears")]
        public int? RecursionYears { get; set; }

        public Collection<Event> Events { get; set; }
    }
}
