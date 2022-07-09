using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bug_tracker_data.Models;

namespace BugTrackerData.DTO
{
    public class TeamMemberDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public TeamMemberDTO(TeamMember tm)
        {
            Id = tm.Id;
            Email = tm.Email;
        }
    }
}
