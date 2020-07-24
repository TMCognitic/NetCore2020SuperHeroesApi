using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperHeroes.Api.Models
{
    public class LoginInfo
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Passwd { get; set; }
    }
}