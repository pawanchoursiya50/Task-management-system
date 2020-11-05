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
            return _dbContext.MainTasks;
        }

        public MainTask GetById(Guid entityId)
        {
            return _dbContext.MainTasks.Find(entityId);
        }

        public Guid Add(MainTask entity)
        {
           // Guid guid = _dbContext.MainTasks.Add(entity).Id;
             _dbContext.SaveChanges();
             return new Guid("88D5BE18-A5EC-46A8-BBB2-06D223A11416");

           /* user.Task.Add(entity);
            _dbContext.SaveChanges();

            return user.Id;*/
        }

        public void Delete(Guid entityId)
        {
            MainTask MainTask = GetById(entityId);
            _dbContext.MainTasks.Remove(MainTask);
            _dbContext.SaveChanges();
        }

        public void Update(MainTask entity)
        {
            _dbContext.MainTasks.AddOrUpdate(entity);
        }
    }
}
