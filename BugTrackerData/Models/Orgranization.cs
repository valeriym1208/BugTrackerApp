using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bug_tracker_data.Models
{
    public class Orgranization
    {
        public int Id { get; set; }
        public IEnumerable<TeamMember> Members { get; set; }
    }
}
