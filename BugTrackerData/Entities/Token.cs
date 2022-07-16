using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bug_tracker_data.Models;
using BugTrackerData.Entities;

namespace BugTrackerData.Models
{
    public class Token : BaseEntity
    {
        public string TokenJwt { get; set; }
        public TeamMember teamMember { get; set; }
    }
}
