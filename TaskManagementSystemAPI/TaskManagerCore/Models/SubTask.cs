using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCore.Models
{
    public class SubTask
    {
        public SubTask()
        {
            SubTaskId = Guid.NewGuid();
        }

        public Guid SubTaskId { get; set; }

        [Required]
        public string SubTaskName { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime StartDateTime { get; set; }

        [Required]
        public string Status { get; set; }


        public Guid MainTaskId { get; set; }
        public MainTask Task { get; set; }

    }
}
