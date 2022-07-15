using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BugTrackerData.Entities;
using Microsoft.EntityFrameworkCore;

namespace bug_tracker_data.Models
{
    public class TeamMember : BaseEntity
    {
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20)]
        public string LastName { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        public string Role = "User";
        [Required]  
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string HashPassword { get; set; }
    }
}
