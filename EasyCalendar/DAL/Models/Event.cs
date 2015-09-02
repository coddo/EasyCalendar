using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyCalendar.DAL.Models
{
    public class Event : BaseEntity
    {
        [Column("Date")]
        public DateTime Date { get; set; }

        public EventData EventData { get; set; }
    }
}
