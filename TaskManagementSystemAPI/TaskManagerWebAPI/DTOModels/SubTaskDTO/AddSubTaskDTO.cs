using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManagerWebAPI.DTOModels.SubTaskDTO
{
    public class AddSubTaskDTO
    {
        [Required]
        public string SubTaskName { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime StartDateTime { get; set; }

        [Required]
        public string Status { get; set; }

    }
}