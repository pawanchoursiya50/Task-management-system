using System;
using System.Linq;
using TaskManagerCore.Models;
using TaskManagerCore.Repository;

namespace TaskManagerWebAPI.Service
{
    public class MainTaskService
    {
        private IRepository<MainTask> _mainTaskRepo;

        public MainTaskService(IRepository<MainTask> repo)
        {
            _mainTaskRepo = repo;
        }

        public IQueryable<MainTask> GetAllTask(Guid userId)
        {
           return  _mainTaskRepo.Get().Where(mainTask => mainTask.UserId == userId);
        }

        public MainTask GetTaskById(Guid taskId)
        {
            return _mainTaskRepo.GetById(taskId);
        }

        public Guid AddNewTask(MainTask newMainTask)
        {
            return _mainTaskRepo.Add(newMainTask);
        }

        public void UpdateMainTask()
        {
            _mainTaskRepo.Update();
        }

        public void Delete(MainTask mainTask)
        {
            _mainTaskRepo.Delete(mainTask);
        }

    }
}