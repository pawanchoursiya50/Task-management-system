﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskManagerCore.Models
{
    public class User
    {
        public User()
        {
            UserId = Guid.NewGuid();
        }
        public Guid UserId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public DateTime DOB { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public long ContactNumber { get; set; }

        [Required]
        public string Email { get; set; }

        public LoginCredential LoginCredential { get; set; }
        public ICollection<MainTask> Task { get; set; }

    }
}
