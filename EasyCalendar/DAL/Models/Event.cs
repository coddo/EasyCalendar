using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyCalendar.DAL.Models
{
    [Table("Events")]
    public class Event : BaseEntity
    {
        [Column("Date")]
        public DateTime Date { get; set; } = DateTime.Now;

        [Column("Seen")]
        public bool Seen { get; set; } = false;

        public EventData EventData { get; set; }
    }
}
