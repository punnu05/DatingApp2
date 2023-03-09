using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _Context ;
        private readonly IMapper _mapper;
        public UserRepository(DataContext context ,IMapper mapper)
        {
            _mapper = mapper;
            _Context = context;
            
        }

        public async Task<MemberDTO> GetMemberByMemberName(string username)
        {
            var member =await _Context.AppUsers.Where(x=>x.UserName==username)
            .ProjectTo<MemberDTO>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(x=>x.UserName==username);
            return member;
        }

        public async Task<IEnumerable<MemberDTO>> GetMembersAsync()
        {
          var member = await _Context.AppUsers.ProjectTo<MemberDTO>(_mapper.ConfigurationProvider)
          .ToListAsync();
          return member;
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
           return await _Context.AppUsers.FindAsync(id);
        }

        public async Task<AppUser> GetUserByUserNameAsync(string username)
        {
           return await _Context.AppUsers
           .Include(p=>p.Photos)
           .SingleOrDefaultAsync(x =>x.UserName == username);
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            return await _Context.AppUsers
            .Include(p=>p.Photos)
            .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
           return await _Context.SaveChangesAsync()>0;
        }

        public  void update(AppUser user)
        {
           _Context.Entry(user).State =EntityState.Modified ;
           
        }
    }
}