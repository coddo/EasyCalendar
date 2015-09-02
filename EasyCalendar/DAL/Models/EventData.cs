﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyCalendar.DAL.Models
{
    [Table("event")]
    public class EventData : BaseEntity
    {
        [Column("Title")]
        public string Title { get; set; }

        [Column("Details")]
        public string Details { get; set; }

        [Column("isRecursive")]
        public bool IsRecursive { get; set; }

        [Column("recursionDays")]
        public int? RecursionDays { get; set; }

        public Collection<Event> Events { get; set; }
    }
}