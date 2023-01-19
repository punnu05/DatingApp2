using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await _context.AppUsers.ToListAsync();
            return users;
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<AppUser>> GetUser(int Id)
        {
            return await _context.AppUsers.FindAsync(Id);
        }
        [HttpPost]
        public  string PostUser(AppUser user)
        {
            try
            {
                 _context.AppUsers.Add(user);
                _context.SaveChangesAsync();
                return "added";
            }
            catch
            {
                return "failed to add";
            }
        }
    }
}