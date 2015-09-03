using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyCalendar.DAL.Models
{
    [Table("Events")]
    public class Event : BaseEntity
    {
        [Column("Date")]
        public DateTime Date { get; set; }

        public EventData EventData { get; set; }
    }
}
