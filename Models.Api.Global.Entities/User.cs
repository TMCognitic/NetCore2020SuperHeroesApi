﻿using System;

namespace Models.Api.Global.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Passwd { get; set; }
        public bool IsAdmin { get; set; }
        public string Token { get; set; }
    }
}
