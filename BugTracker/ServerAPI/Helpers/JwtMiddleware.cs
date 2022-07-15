using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugTracker.ServerAPI.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace BugTracker.ServerAPI.Helpers
{
    public class JwtMiddleware
    {
        private readonly IConfiguration _config;
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next, IConfiguration config)
        {
            _config = config;
            _next = next;
        }

        public async Task Invoke(HttpContext context, ITeamMemberService memberService)
        {
            var authorization = context.Request.Headers["Authorization"];
            var token = authorization
                .FirstOrDefault()?.Split(" ").Last();

            if (token != null) AttachUserToContext(context, memberService, token);
            await _next.Invoke(context);
        }

        public void AttachUserToContext(HttpContext context, ITeamMemberService memberService, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_config["JWT:Secret"]);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero,

                }, out SecurityToken validatedToken);
                var jwtToken = (JwtSecurityToken)validatedToken;
                var memberId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);
                context.Items["Member"] = memberService.GetById(memberId);
            }
            catch
            {

            }
        }
    }
}
