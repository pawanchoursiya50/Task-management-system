﻿using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using TaskManagerCore.DBContext;
using TaskManagerCore.Models;

namespace TaskManagerCore.Repository
{
    public class LoginCredentialRepository : IRepository<LoginCredential>
    {
        private TaskManagerDBContext _dbContext;
        public LoginCredentialRepository(TaskManagerDBContext context)
        {
            _dbContext = context;
        }

        public IQueryable<LoginCredential> Get()
        {
            return _dbContext.LoginCredentials;
        }

        public LoginCredential GetById(Guid entityId)
        {
            return _dbContext.LoginCredentials.Find(entityId);
        }

        public Guid Add(LoginCredential entity)
        {
            Guid guid = _dbContext.LoginCredentials.Add(entity).Id;
            _dbContext.SaveChanges();
            return guid;
        }

        public void Update()
        {
            _dbContext.SaveChanges();
        }

        public void Delete(LoginCredential entity)
        {
            
        }
    }
}
