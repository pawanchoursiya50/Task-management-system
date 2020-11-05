using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TaskManagerCore.Models;
using TaskManagerCore.Repository;
using TaskManagerWebAPI.DTOModels;
using TaskManagerWebAPI.Service;

namespace TaskManagerWebAPI.Controllers
{
    [RoutePrefix("api/v1/user")]
    public class UserController : ApiController
    {
        private UserService _userService;
        private LoginService _loginService;
        
        public UserController(UserService userservice, LoginService loginService)
        {
           _userService = userservice;
            _loginService = loginService;
        }

        [Route(""), ResponseType(typeof(UserDTO[]))]
        public IHttpActionResult Get(bool includeLogin = false)
        {
            var users = _userService.GetAllUser().Select(user =>
            new UserDTO()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DOB = user.DOB,
                City = user.City,
                ContactNumber = user.ContactNumber,
                Email = user.Email,
                LoginCredential = (includeLogin == false) ? null : new LoginCredentialDTO()
                {
                    Id = user.LoginCredential.Id,
                    UserName = user.LoginCredential.UserName,
                    Password = user.LoginCredential.Password
                }
            }).ToList() ;

            return Ok(users);
        }


        [Route("{UserId}"), ResponseType(typeof(UserDTO))]
        public IHttpActionResult Get(Guid id, bool includeLogin=false)
        {
            User user = _userService.GetUserById(id);
            if (user == null)
                return NotFound();

            UserDTO userDTO = new UserDTO()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DOB = user.DOB,
                City = user.City,
                ContactNumber = user.ContactNumber,
                Email = user.Email,
                LoginCredential = (includeLogin == false)? null : new LoginCredentialDTO()
                {
                    Id = user.LoginCredential.Id,
                    UserName = user.LoginCredential.UserName,
                    Password = user.LoginCredential.Password
                }
            };

            return Ok(userDTO);

        }


        [Route(""), ResponseType(typeof(Guid))]
        public IHttpActionResult Post(RegisterDTO register)
        {

            User user = new User()
            {
                //Id = register.Id,
                FirstName = register.FirstName,
                LastName = register.LastName,
                DOB = register.DOB,
                City = register.City,
                ContactNumber = register.ContactNumber,
                Email = register.Email,
            };
            Guid id = _userService.AddNewUser(user);

            LoginCredential LoginCredential = new LoginCredential()
            {
                Id = id,
                UserName = register.UserName,
                Password = register.UserPass
            };

            
            _loginService.AddNewLoginCredential(LoginCredential);

            return Ok(id);
        }

        [Route("UpdateUser")]
        public IHttpActionResult PutUser(Guid userId, UserDTO userDTO)
        {
            User user = _userService.GetUserById(userId);
            if (user == null)
                return NotFound();

            user.FirstName = userDTO.FirstName;
            user.LastName = userDTO.LastName;
            user.DOB = userDTO.DOB;
            user.City = userDTO.City;
            user.ContactNumber = userDTO.ContactNumber;
            user.Email = userDTO.Email;
            _userService.UpdateUser(user);

            return Ok(userId);
        }

        [Route("UpdateLogin")]
        public IHttpActionResult PutLogin(Guid userId, LoginCredentialDTO loginCredentialDTO)
        {
            
            LoginCredential loginCredential = _loginService.GetLoginCredentialById(userId);
            if (loginCredential == null)
                return NotFound();

            loginCredential.UserName = loginCredentialDTO.UserName;
            loginCredential.Password = loginCredentialDTO.Password;
            _loginService.UpdateLoginCredential(loginCredential);

            return Ok(userId);
        }


        [Route(""), ResponseType(typeof(Guid))]
        public IHttpActionResult DELETE(Guid userId)
        {
            User user = _userService.GetUserById(userId);
            if (user == null)
                return BadRequest("User Id is wrong");

            _userService.DeleteUser(userId);
            //_loginService.DeleteLoginCredential(userId);
            return Ok(userId);
        }
    }
}
