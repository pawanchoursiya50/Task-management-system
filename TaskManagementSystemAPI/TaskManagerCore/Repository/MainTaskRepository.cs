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
            //_dbContext = new TaskManagerDBContext();
            _dbContext = context;
        }
        public Guid Add(MainTask entity)
        {
            Guid guid = _dbContext.MainTasks.Add(entity).Id;
            _dbContext.SaveChanges();
            return guid;
        }

        public void Delete(Guid entityId)
        {
            MainTask MainTask = GetById(entityId);
            _dbContext.MainTasks.Remove(MainTask);
            _dbContext.SaveChanges();
        }

        public IQueryable<MainTask> Find(Expression<Func<MainTask, bool>> specification)
        {
            throw new NotImplementedException();
        }

        public IQueryable<MainTask> Get()
        {
            return _dbContext.MainTasks;
        }

        public MainTask GetById(Guid entityId)
        {
            return _dbContext.MainTasks.Find(entityId);
        }

        public void Update(MainTask entity)
        {
            _dbContext.MainTasks.AddOrUpdate(entity);
        }
    }
}
