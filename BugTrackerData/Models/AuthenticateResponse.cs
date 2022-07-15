using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bug_tracker_data.Models;

namespace BugTrackerData.DTO
{
    public class AuthenticateResponse
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(TeamMember teamMember, string token)
        {
            Id = teamMember.Id;
            FirstName = teamMember.FirstName;
            LastName = teamMember.LastName;
            Email = teamMember.Email;
            PhoneNumber = teamMember.PhoneNumber;
            Token = token;
        }
    }
}
