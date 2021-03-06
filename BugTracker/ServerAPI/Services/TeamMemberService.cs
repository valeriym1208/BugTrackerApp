using System.Net;
using AutoMapper;
using bug_tracker_data.Models;
using BugTracker.ServerAPI.Helpers;
using BugTracker.ServerAPI.Interfaces;
using BugTrackerData.DTO;
using BugTrackerData.Models;

namespace BugTracker.ServerAPI.Services
{
    public class TeamMemberService : ITeamMemberService
    {
        private readonly IEfRepository<TeamMember> _teamMemberRepository;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly ITokenHelper _tokenHelper;
        public TeamMemberService(IEfRepository<TeamMember> teamMemberRepository,IConfiguration config, IMapper mapper, ITokenHelper tokenHelper)
        {
            _config = config;
            _teamMemberRepository = teamMemberRepository;
            _mapper = mapper;
            _tokenHelper = tokenHelper;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {   
            var member = GetAll().FirstOrDefault(
                x => x.Email == model.Email && BCrypt.Net.BCrypt.Verify(model.Password, x.HashPassword));
            if (member == null) return null;
            var token = _tokenHelper.GenerateJwtToken(member);
            return new AuthenticateResponse(member, token);
        }

        public async Task<AuthenticateResponse> Register(TeamMemberModel model)
        {
            var member = _mapper.Map<TeamMember>(model);
            var addedMember = GetAll()
                .FirstOrDefault(m => m.Email == member.Email);
            if (addedMember != null) return null;
            var hashPassword = BCrypt.Net.BCrypt.HashPassword(member.HashPassword);
            member.HashPassword = hashPassword;
            await _teamMemberRepository.Add(member);
            var response = Authenticate(
                new AuthenticateRequest
                {
                    Email = member.Email,  
                    Password = model.Password,
                });
            return response;
        }

        public async Task<Token> Logout(string token)
        {
            var deletedToken = await _tokenHelper.DeleteJwtToken(token);
            return deletedToken;
        }
        public IEnumerable<TeamMember> GetAll()
        {
            return _teamMemberRepository.GetAll();
        }

        public TeamMember GetById(int id)
        {
            return _teamMemberRepository.GetById(id);
        }
    }
}   
