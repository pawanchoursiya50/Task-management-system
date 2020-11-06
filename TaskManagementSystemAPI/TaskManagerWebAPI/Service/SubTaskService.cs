using System;
using System.Linq;
using TaskManagerCore.Models;
using TaskManagerCore.Repository;

namespace TaskManagerWebAPI.Service
{
    public class SubTaskService
    {
        private IRepository<SubTask> _subTaskRepo;

        public SubTaskService(IRepository<SubTask> repo)
        {
            _subTaskRepo = repo;
        }

        public IQueryable<SubTask> GetAllSubTask(Guid taskId)
        {
            return _subTaskRepo.Get().Where(subTask => subTask.MainTaskId == taskId);
        }

        public SubTask GetSubTaskById(Guid subTaskId)
        {
            return _subTaskRepo.GetById(subTaskId);
        }

        public Guid AddNewSubTask(SubTask subTask)
        {
            return _subTaskRepo.Add(subTask);
        }
        
        public void UpdateSubTaskTask()
        {
            _subTaskRepo.Update();
        }
        
        public void Delete(SubTask subTask)
        {
            _subTaskRepo.Delete(subTask);
        }

    }
}