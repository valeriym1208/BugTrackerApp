using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bug_tracker_data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BugTracker.ServerAPI.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var member = (TeamMember) context.HttpContext.Items["Member"];
            if (member == null)
                context.Result = new JsonResult(new {message = "Unauthorized"})
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
        }
    }
}
