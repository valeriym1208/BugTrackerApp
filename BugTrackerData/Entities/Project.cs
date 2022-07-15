using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugTrackerData.Entities;

namespace bug_tracker_data.Models
{
    public class Project : BaseEntity
    {
        [Required]
        [StringLength(30)]
        public string Title { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        public Team Team { get; set; }
        public IEnumerable<Ticket> Tickets { get; set; }

    }
}
