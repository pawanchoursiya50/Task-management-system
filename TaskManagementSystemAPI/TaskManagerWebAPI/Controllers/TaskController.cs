using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using TaskManagerCore.Models;
using TaskManagerWebAPI.DTOModels;
using TaskManagerWebAPI.Service;

namespace TaskManagerWebAPI.Controllers
{
    [RoutePrefix("api/v1/user/{userId}/task")]
    public class TaskController : ApiController
    {
        private MainTaskService _mainTaskService;
        private UserService _userService;
        public TaskController(MainTaskService service, UserService userservice) {
            _mainTaskService = service;
            _userService = userservice;
        }

        [Route(""), ResponseType(typeof(MainTaskDTO[]))]
        public IHttpActionResult Get(Guid userId)
        {
            User user = _userService.GetUserById(userId);
            if(user == null)
            {
                return NotFound();
            }

            var mainTasks = _mainTaskService.GetAllTask(userId).Select(mainTask => 
            new MainTaskDTO{ 
                TaskId = mainTask.MainTaskId,
                TaskName = mainTask.TaskName,
                Description = mainTask.Description,
                StartDateTime = mainTask.StartDateTime,
                Status = mainTask.Status,
            }).ToList();

            return Ok(mainTasks);
        }

        [Route("{mainTaskId}"), ResponseType(typeof(MainTaskDTO))]
        public IHttpActionResult Get(Guid userId, Guid mainTaskId)
        {

            MainTask mainTask = _mainTaskService.GetTaskById(mainTaskId);
            if(mainTask == null)
            {
                return NotFound();
            }

            MainTaskDTO mainTaskDTO = new MainTaskDTO()
            {
                TaskId = mainTask.MainTaskId,
                TaskName = mainTask.TaskName,
                Description = mainTask.Description,
                StartDateTime = mainTask.StartDateTime,
                Status = mainTask.Status,
            };

            return Ok(mainTaskDTO);
        }

        [Route("addTask")]
        public IHttpActionResult Post(Guid userId, MainTaskDTO mainTaskDTO)
        {
            User user = _userService.GetUserById(userId);
            if (user == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            MainTask newTask = new MainTask()
            {
                TaskName = mainTaskDTO.TaskName,
                Description = mainTaskDTO.Description,
                StartDateTime = mainTaskDTO.StartDateTime,
                Status = mainTaskDTO.Status,
                UserId = user.UserId,
            };
             Guid mainTaskId =_mainTaskService.AddNewTask(newTask);
            return Ok(mainTaskId);
        }

        [Route("updateTask/{mainTaskId}")]
        public IHttpActionResult Put(Guid userId, Guid mainTaskId, UpdateMainTaskDTO updateMainTaskDTO)
        {
            MainTask mainTask = _mainTaskService.GetTaskById(mainTaskId);
            if (mainTask == null)
            {
                return NotFound();
            }
            mainTask.TaskName = updateMainTaskDTO.TaskName;
            mainTask.Description = updateMainTaskDTO.Description;
            mainTask.StartDateTime = updateMainTaskDTO.StartDateTime;
            mainTask.Status = updateMainTaskDTO.Status;

            _mainTaskService.UpdateMainTask();
            return Ok();
        }


        [Route("deleteTask/{mainTaskId}")]
        public IHttpActionResult Delete(Guid userId, Guid mainTaskId)
        {
            MainTask mainTask = _mainTaskService.GetTaskById(mainTaskId);
            if (mainTask == null)
            {
                return NotFound();
            }
            _mainTaskService.Delete(mainTask);
            return Ok(mainTask.MainTaskId);
        }
    }
}
