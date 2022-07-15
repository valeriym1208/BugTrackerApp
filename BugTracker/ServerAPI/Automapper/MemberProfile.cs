using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using bug_tracker_data.Models;
using BugTrackerData.DTO;
using BugTrackerData.Models;

namespace BugTracker.ServerAPI.Automapper
{
    public class MemberProfile : Profile
    {
        public MemberProfile()
        {
            CreateMap<TeamMemberModel, TeamMember>()
                .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dst => dst.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dst => dst.HashPassword, opt => opt.MapFrom(src => src.Password))
                .ForMember(dst => dst.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dst => dst.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dst => dst.Id, opt => opt.Ignore())
                ;

            CreateMap<TeamMember, AuthenticateResponse>()
                .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dst => dst.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dst => dst.FirstName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dst => dst.LastName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Token, opt => opt.Ignore())
                ;
        }
    }
}
