using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManagerWebAPI.DTOModels
{
    public class UpdateUserDTO
    {

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