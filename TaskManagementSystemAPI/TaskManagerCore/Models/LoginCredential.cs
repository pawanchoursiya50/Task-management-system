using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCore.Models
{
    class LoginCredential
    {
        [ForeignKey("User")]
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public User User { get; set; }
    }
}
