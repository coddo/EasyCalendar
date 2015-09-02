using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyCalendar.DAL.Models
{
    [Table("event")]
    public class EventData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("Title")]
        public string Title { get; set; }

        [Column("Details")]
        public string Details { get; set; }

        [Column("isRecursive")]
        public bool IsRecursive { get; set; }

        [Column("recursionDays")]
        public int? RecursionDays { get; set; }

        //[OneToMany(CascadeOperations = CascadeOperation.All)]
        public Collection<Event> Events { get; set; }
    }
}
