using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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

        [Route("")]
        public IHttpActionResult Get(Guid userId)
        {
            User user = _userService.GetUserById(userId);
            if(user == null)
            {
                return NotFound();
            }


            return Ok();
        }

        [Route("{taskId}")]
        public IHttpActionResult Get(Guid userId, Guid taskId)
        {
            return Ok();
        }

        [Route("AddTask")]
        public IHttpActionResult Post(Guid userId, MainTaskDTO mainTaskDTO)
        {
            User user = _userService.GetUserById(userId);
            if (user == null)
            {
                return NotFound();
            }

            

            MainTask newTask = new MainTask()
            {
                TaskName = mainTaskDTO.TaskName,
                Description = mainTaskDTO.Description,
                StartDateTime = mainTaskDTO.StartDateTime,
                Status = mainTaskDTO.Status,
                //User = user,
            };
             user.Task.Add(newTask);

             _mainTaskService.AddNewTask(user, newTask);

            //Guid id = _mainTaskService.AddNewTask(user, newTask);

            return Ok();
        }

        [Route("UpdateTask/{taskId}")]
        public IHttpActionResult Put(Guid userId, Guid taskId, MainTaskDTO mainTaskDTO)
        {
            return Ok();
        }


        [Route("DeleteTask/{taskId}")]
        public IHttpActionResult Delete(Guid userId, Guid taskId)
        {
            return Ok();
        }
    }
}
