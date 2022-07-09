using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace bug_tracker_data.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Title { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        public TeamMember Author { get; set; }
        public TicketStatus Status { get; set; }
        public TicketType Type { get; set; }
        public TicketPriority Priority { get; set; }
        [Range(1,168)]
        public int TimeEstimate { get; set; }
        public IEnumerable<TeamMember> AssignedDevs { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}
