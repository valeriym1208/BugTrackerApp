using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace bug_tracker_data.Models
{
    public class TeamMember
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string GivenName { get; set; }
        [Required]
        [StringLength(20)]
        public string Surname { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        public string AuthorizationLevel { get; set; }
        [Required]  
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
