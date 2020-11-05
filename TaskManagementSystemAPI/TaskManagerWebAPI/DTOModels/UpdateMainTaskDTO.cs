using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManagerWebAPI.DTOModels
{
    public class UpdateMainTaskDTO
    {
        [Required]
        public string TaskName { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime StartDateTime { get; set; }

        [Required]
        public string Status { get; set; }
    }
}