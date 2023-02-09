using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers.DTOs
{
    public class RegisterDTO
    {
        [Required]
        public string  userName { get; set; } 
        [Required]
        [StringLength(8,MinimumLength =4)]
        public string password { get; set; }
    }
}