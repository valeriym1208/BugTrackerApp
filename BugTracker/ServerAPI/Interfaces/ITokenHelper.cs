using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bug_tracker_data.Models;
using BugTrackerData.Models;

namespace BugTracker.ServerAPI.Interfaces
{
    public interface ITokenHelper
    {
        string GenerateJwtToken(TeamMember teamMember);
        Task<Token> DeleteJwtToken(string token);
    }
}
