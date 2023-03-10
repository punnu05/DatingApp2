using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class seed
    {
       

        public static async Task SeedUsers(DataContext context){
           if(await context.AppUsers.AnyAsync()) return; 
           var userdata= await File.ReadAllTextAsync("Data/UserSeedData.json");
           var options = new JsonSerializerOptions{PropertyNameCaseInsensitive = true};
           var users = JsonSerializer.Deserialize<List<AppUser>>(userdata);
           
           foreach(var user in users){
            using var hmac = new HMACSHA512();
            user.UserName = user.UserName.ToLower();
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("p@$$w0rd"));
            user.PasswordSalt =hmac.Key;
            context.AppUsers.Add(user);
           }
           await context.SaveChangesAsync();
        }
    }
}