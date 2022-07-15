using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugTrackerData.Entities;

namespace bug_tracker_data.Models
{
    public class Team : BaseEntity
    {
        public IEnumerable<TeamMember> TeamMembers { get; set; }
    }
}
