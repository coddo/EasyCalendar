using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyCalendar.DAL.Models
{
    [Table("event")]
    public class Event
    {
        [Column("id")]
        public Guid Id { get; set; }
    }
}
