using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCore.Models
{
    public class MainTask
    {
        public MainTask()
        {
            MainTaskId = Guid.NewGuid();
        }

        public Guid MainTaskId { get; set; }

        [Required]
        public string TaskName { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime StartDateTime { get; set; }

        [Required]
        public string Status { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
        public ICollection<SubTask> SubTask { get; set; }

    }
}
