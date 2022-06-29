using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bug_tracker_data.Models
{
    public class Team
    {
        public int Id { get; set; }
        public IEnumerable<TeamMember> TeamMembers { get; set; }
    }
}
