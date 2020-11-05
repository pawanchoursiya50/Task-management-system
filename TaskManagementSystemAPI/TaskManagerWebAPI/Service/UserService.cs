using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManagerCore.Models;
using TaskManagerCore.Repository;
using TaskManagerWebAPI.Controllers;

namespace TaskManagerWebAPI.Service
{
    public class UserService
    {
        private IRepository<User> _userRepo;

        public UserService(IRepository<User> userRepo)
        {
            _userRepo = userRepo;
        }
        
        public IQueryable<User> GetAllUser()
        {
            return _userRepo.Get();
        }

        public User GetUserById(Guid id)
        {
            return _userRepo.GetById(id);
        }

        public Guid AddNewUser(User user)
        {
           return  _userRepo.Add(user);
        }

        public void UpdateUser()
        {
            _userRepo.Update();
        }

        public void DeleteUser(User user)
        {
            _userRepo.Delete(user);
        }



    }
}