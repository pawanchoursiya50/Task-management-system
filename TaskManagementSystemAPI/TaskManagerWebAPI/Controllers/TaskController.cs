using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManagerWebAPI.DTOModels;
using TaskManagerWebAPI.Service;

namespace TaskManagerWebAPI.Controllers
{
    [RoutePrefix("api/v1/user/{userId}/task")]
    public class TaskController : ApiController
    {
        private MainTaskService _mainTaskService;
        public TaskController(MainTaskService service) {
            _mainTaskService = service;
        }

        [Route("")]
        public IHttpActionResult Get(Guid userId)
        {
            return Ok();
        }

        public IHttpActionResult Get(Guid userId, Guid taskId)
        {
            return Ok();
        }

        public IHttpActionResult Post(Guid userId, MainTaskDTO mainTaskDTO)
        {
            return Ok();
        }

        public IHttpActionResult Put(Guid userId, Guid taskId, MainTaskDTO mainTaskDTO)
        {
            return Ok();
        }

        public IHttpActionResult Delete(Guid userId, Guid taskId)
        {
            return Ok();
        }
    }
}
