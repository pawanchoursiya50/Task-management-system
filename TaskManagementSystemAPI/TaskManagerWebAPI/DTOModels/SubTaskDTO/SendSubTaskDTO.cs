using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagerWebAPI.DTOModels.SubTaskDTO
{
    public class SendSubTaskDTO
    {
        public Guid SubTaskId { get; set; }
        public string SubTaskName { get; set; }

        public string Description { get; set; }

        public DateTime StartDateTime { get; set; }

        public string Status { get; set; }
    }
}