using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TaskManagerCore.Models;

namespace TaskManagerWebAPI.DTOModels
{
    public class UserDTO
    {
        public Guid Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public long ContactNumber { get; set; }

        [Required]
        public string Email { get; set; }

        public LoginCredentialDTO LoginCredential { get; set; }

    }
}