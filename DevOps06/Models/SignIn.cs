using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevOps06.Models
{
    public class SignIn
    {
        [Required]
        public string Password { get; set; }

        [Required]
        public string Username { get; set; }
    }
}
