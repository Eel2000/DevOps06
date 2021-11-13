using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevOps06.Models
{
    /// <summary>
    /// The model for sign into the account.
    /// </summary>
    public class SignIn
    {
        /// <summary>
        /// The user account password.
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// The user account username.
        /// </summary>
        [Required]
        public string Username { get; set; }
    }
}
