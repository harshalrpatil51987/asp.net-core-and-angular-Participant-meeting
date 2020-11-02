using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace eduvanz.Meetup.MeetupEvents
{
    [Table("StateMasters")]
    public class StateMaster : Entity<int>  
    {
        public string Name { get; set; }
        public int country { get; set; }
    }
}
