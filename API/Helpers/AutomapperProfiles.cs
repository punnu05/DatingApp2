using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;

namespace API.Helpers
{
    public class AutomapperProfiles :Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<AppUser ,MemberDTO>()
            .ForMember(dest=>dest.Photourl,
            opt=>opt.MapFrom(src=>src.Photos.FirstOrDefault(x=>x.IsMain).Url))
            .ForMember(dest=>dest.Age,opt=>opt.MapFrom(src=>src.DateOfBirth.CalculateAge()));
            CreateMap<Photo ,photoDTO>();
        }
    }
}