using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManagerWebAPI.DTOModels.LoginDTO
{
    public class ForgetDTO
    {
        [Required]
        public string passWord { get; set; }
    }
}