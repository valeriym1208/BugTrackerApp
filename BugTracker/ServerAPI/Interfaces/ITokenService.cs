using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bug_tracker_data.Models;

namespace BugTracker.ServerAPI.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(string key, int minutesExpires, TeamMember tm);
        void SaveRefreshToken(string refreshToken, TeamMember tm);
    }
}
