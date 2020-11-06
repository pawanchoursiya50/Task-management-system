using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using TaskManagerCore.Models;
using TaskManagerWebAPI.DTOModels;
using TaskManagerWebAPI.DTOModels.SubTaskDTO;
using TaskManagerWebAPI.Service;

namespace TaskManagerWebAPI.Controllers
{
    [RoutePrefix("api/v1/user/{userId}/task/{taskId}/subTask")]
    public class SubTaskController : ApiController
    {
        private SubTaskService _subTaskService;
        private MainTaskService _mainTaskService;
        private UserService _userService;
        public SubTaskController(SubTaskService subTaskService, MainTaskService service, UserService userservice)
        {
            _subTaskService = subTaskService;
            _mainTaskService = service;
            _userService = userservice;
        }

        [Route(""), ResponseType(typeof(SendSubTaskDTO[]))]
        public IHttpActionResult Get(Guid userId, Guid taskId) 
        {
            MainTask mainTask;
            bool isVerified = VerifyUserAndTask(userId, taskId, out mainTask);
            if (!isVerified)
            {
                return NotFound();
            }

            var subTasks = _subTaskService.GetAllSubTask(taskId).Select(subtask => 
            new SendSubTaskDTO() { 
                SubTaskId =subtask.SubTaskId,
                SubTaskName = subtask.SubTaskName,
                Description = subtask.Description,
                StartDateTime = subtask.StartDateTime,
                Status = subtask.Status,
            });

            return Ok(subTasks);
        }

        [Route("{subTaskId}"), ResponseType(typeof(SendSubTaskDTO))]
        public IHttpActionResult GetById(Guid subTaskId)
        {
            SubTask subTask = _subTaskService.GetSubTaskById(subTaskId);
            if(subTask == null)
            {
                return NotFound();
            }

            SendSubTaskDTO sendSubTaskDTO = new SendSubTaskDTO()
            {
                SubTaskId = subTask.SubTaskId,
                SubTaskName = subTask.SubTaskName,
                Description = subTask.Description,
                StartDateTime = subTask.StartDateTime,
                Status = subTask.Status
            };

            return Ok(sendSubTaskDTO);
        }

        [Route("addSubTask")]
        public IHttpActionResult Post(Guid userId, Guid taskId, AddSubTaskDTO addSubTaskDTO)
        {
            MainTask mainTask;
            bool isVerified = VerifyUserAndTask(userId, taskId, out mainTask);
            if (!isVerified)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            SubTask subTask = new SubTask()
            {
                SubTaskName = addSubTaskDTO.SubTaskName,
                Description = addSubTaskDTO.Description,
                StartDateTime = addSubTaskDTO.StartDateTime,
                Status = addSubTaskDTO.Status,
                MainTaskId = mainTask.MainTaskId
            };

            Guid subTaskId = _subTaskService.AddNewSubTask(subTask);
            return Ok(subTaskId);

        }

        [Route("updateSubTask/{subTaskId}")]
        public IHttpActionResult Put(Guid subTaskId, AddSubTaskDTO addSubTaskDTO)
        {
            SubTask subtask = _subTaskService.GetSubTaskById(subTaskId);
            if (subtask == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            subtask.SubTaskName = addSubTaskDTO.SubTaskName;
            subtask.Description = addSubTaskDTO.Description;
            subtask.StartDateTime = addSubTaskDTO.StartDateTime;
            subtask.Status = addSubTaskDTO.Status;

            _subTaskService.UpdateSubTaskTask();
            return Ok(subTaskId);
        }

        [Route("deleteSubTask/{subTaskId}")]
        public IHttpActionResult Delete(Guid subTaskId)
        {
            SubTask subTask = _subTaskService.GetSubTaskById(subTaskId);
            if(subTask == null)
            {
                return NotFound();
            }

            _subTaskService.Delete(subTask);
            return Ok(subTask.SubTaskId); 
        }

        private bool VerifyUserAndTask(Guid userId, Guid taskId, out MainTask mainTask)
        {
            User user = _userService.GetUserById(userId);
            mainTask = _mainTaskService.GetTaskById(taskId);

            if(user == null || mainTask == null)
            {
                return false;
            }
            return true;
        }
    }
}
