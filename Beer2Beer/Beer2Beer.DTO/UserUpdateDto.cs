﻿using System.ComponentModel.DataAnnotations;

namespace Beer2Beer.DTO
{
    public class UserUpdateDto
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasswordHash { get; set; }
    }
}