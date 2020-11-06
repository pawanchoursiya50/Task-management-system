using System;
using System.ComponentModel.DataAnnotations;
using TaskManagerWebAPI.DTOModels.LoginDTO;

namespace TaskManagerWebAPI.DTOModels.UserDTO
{
    public class SendUserDTO
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

    }
}