using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManagerCore.Models;
using TaskManagerCore.Repository;
using TaskManagerWebAPI.Controllers;

namespace TaskManagerWebAPI.Service
{
    public class MainTaskService
    {
        private IRepository<MainTask> _mainTaskRepo;

        public MainTaskService(IRepository<MainTask> repo)
        {
            _mainTaskRepo = repo;
        }
    }
}