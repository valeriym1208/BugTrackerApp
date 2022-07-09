using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bug_tracker_data.Models;

namespace BugTrackerData.Models
{
    public class Token
    {
        public int Id { get; set; }
        public string RefreshToken { get; set; }
        public TeamMember teamMember { get; set; }
    }
}
