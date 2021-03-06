﻿using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using TaskManagerCore.DBContext;
using TaskManagerCore.Models;

namespace TaskManagerCore.Repository
{
    public class UserRepository : IRepository<User>
    {
        private TaskManagerDBContext _dbContext;
        public UserRepository(TaskManagerDBContext context)
        {
            _dbContext = context;
        }

        public IQueryable<User> Get()
        {
            return _dbContext.Users.Include("LoginCredential");
        }

        public User GetById(Guid entityId)
        {
            return _dbContext.Users.Include("LoginCredential").Where(u => u.UserId == entityId).FirstOrDefault();
        }

        public Guid Add(User entity)
        {
            Guid guid = _dbContext.Users.Add(entity).UserId;
            _dbContext.SaveChanges();
            return guid;
        }

        public void Update()
        {
            _dbContext.SaveChanges();
        }

        public void Delete(User entity)
        {
            _dbContext.Users.Remove(entity);
            _dbContext.SaveChanges();
        }

    }
}
