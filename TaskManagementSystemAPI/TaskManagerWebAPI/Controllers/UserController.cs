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
                Id = user.UserId,
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
                Id = user.UserId,
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User user = new User()
            {
                FirstName = register.FirstName,
                LastName = register.LastName,
                DOB = register.DOB,
                City = register.City,
                ContactNumber = register.ContactNumber,
                Email = register.Email,
                LoginCredential = new LoginCredential {
                    UserName = register.UserName,
                    Password = register.UserPass,
                }
            };
            Guid userId = _userService.AddNewUser(user);

            return Ok(userId);
        }


        [Route("UpdateUser")]
        public IHttpActionResult PutUser(Guid userId, UpdateUserDTO updateUserDTO)
        {
            User user = _userService.GetUserById(userId);
            if (user == null)
                return NotFound();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            user.FirstName = updateUserDTO.FirstName;
            user.LastName = updateUserDTO.LastName;
            user.DOB = updateUserDTO.DOB;
            user.City = updateUserDTO.City;
            user.ContactNumber = updateUserDTO.ContactNumber;
            user.Email = updateUserDTO.Email;

            _userService.UpdateUser();

            return Ok(userId);
        }

        [Route("UpdateLogin")]
        public IHttpActionResult PutLogin(Guid userId, LoginCredentialDTO loginCredentialDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            LoginCredential loginCredential = _loginService.GetLoginCredentialById(userId);
            if (loginCredential == null)
                return NotFound();

            loginCredential.UserName = loginCredentialDTO.UserName;
            loginCredential.Password = loginCredentialDTO.Password;
            _loginService.UpdateLoginCredential();

            return Ok(userId);
        }


        [Route(""), ResponseType(typeof(Guid))]
        public IHttpActionResult DELETE(Guid userId)
        {
            User user = _userService.GetUserById(userId);
            if (user == null)
                return BadRequest("User Id is wrong");

            _userService.DeleteUser(user);
            return Ok(userId);
        }
    }
}
