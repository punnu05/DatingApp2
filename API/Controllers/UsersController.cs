using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers.DTOs;
using API.Data;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userrepsitory;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userrepsitory,IMapper mapper)
        {
            _mapper = mapper;
            _userrepsitory = userrepsitory;

        }
        // [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDTO>>> GetUsers()
        {
            var users = await _userrepsitory.GetMembersAsync();
           
            return Ok(users);
        }
        [Authorize]
        [HttpGet("GetUserById/{Id}")]
        public async Task<ActionResult<AppUser>> GetUser(int Id)
        {
            var user = await _userrepsitory.GetUserByIdAsync(Id);
            return Ok(user);
        }
        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDTO>> GetUserByName(string username)
        {
           // var user = await _userrepsitory.GetUserByUserNameAsync(username);
            return await _userrepsitory.GetMemberByMemberName(username);
        }

        [HttpPost]
        public ActionResult UpdateUser(AppUser user)
        {
          _userrepsitory.update(user);
          return Ok();
        }

        // [HttpPost]
        // public string PostUser(AppUser user)
        // {
        //     try
        //     {
        //         _context.AppUsers.Add(user);
        //         _context.SaveChangesAsync();
        //         return "added";
        //     }
        //     catch
        //     {
        //         return "failed to add";
        //     }
        // }
    }
}