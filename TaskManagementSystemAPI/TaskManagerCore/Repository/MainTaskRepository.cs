using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using TaskManagerCore.DBContext;
using TaskManagerCore.Models;

namespace TaskManagerCore.Repository
{
    public class MainTaskRepository : IRepository<MainTask>
    {
        private TaskManagerDBContext _dbContext;
        public MainTaskRepository(TaskManagerDBContext context)
        {
            _dbContext = context;
        }

        public IQueryable<MainTask> Get()
        {
            return _dbContext.MainTasks.Include("User");
        }

        public MainTask GetById(Guid entityId)
        {
            return _dbContext.MainTasks.Include("User").Where(mainTask => mainTask.MainTaskId == entityId).FirstOrDefault();
        }

        public Guid Add(MainTask entity)
        {
             Guid guid = _dbContext.MainTasks.Add(entity).MainTaskId;
             _dbContext.SaveChanges();
             return guid;

           /* user.Task.Add(entity);
            _dbContext.SaveChanges();

            return user.Id;*/
        }

        public void Update()
        {
            _dbContext.SaveChanges();
        }

        public void Delete(MainTask entity)
        {
            _dbContext.MainTasks.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
