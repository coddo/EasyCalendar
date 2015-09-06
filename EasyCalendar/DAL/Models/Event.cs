using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyCalendar.DAL.Models
{
    [Table("Events")]
    public class Event : BaseEntity
    {
        [Column("Title")]
        public string Title { get; set; }

        [Column("Details")]
        public string Details { get; set; }

        [Column("Date")]
        public DateTime Date { get; set; } = DateTime.Now;

        [Column("IsSeen")]
        public bool IsSeen { get; set; } = false;

        [Column("IsRecursive")]
        public bool IsRecursive { get; set; } = false;

        [Column("RecursionDays")]
        public int? RecursionDays { get; set; } = 0;

        [Column("RecursionMonths")]
        public int? RecursionMonths { get; set; } = 0;

        [Column("RecursionYears")]
        public int? RecursionYears { get; set; } = 0;
    }
}
