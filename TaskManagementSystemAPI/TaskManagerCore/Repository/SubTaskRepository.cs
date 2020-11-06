using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskManagerCore.DBContext;
using TaskManagerCore.Models;

namespace TaskManagerCore.Repository
{
    public class SubTaskRepository : IRepository<SubTask>
    {
        private TaskManagerDBContext _dbContext;
        public SubTaskRepository(TaskManagerDBContext context)
        {
            _dbContext = context;
        }

        public IQueryable<SubTask> Get()
        {
            return _dbContext.SubTasks.Include("MainTask");
        }

        public SubTask GetById(Guid entityId)
        {
            return _dbContext.SubTasks.Find(entityId);
        }

        public Guid Add(SubTask entity)
        {
            Guid guid = _dbContext.SubTasks.Add(entity).SubTaskId;
            _dbContext.SaveChanges();
            return guid;
        }

        public void Update()
        {
            _dbContext.SaveChanges();
        }

        public void Delete(SubTask entity)
        {
            _dbContext.SubTasks.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
