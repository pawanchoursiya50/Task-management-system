using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using TaskManagerCore.Models;
using TaskManagerWebAPI.DTOModels.UserDTO;
using TaskManagerWebAPI.DTOModels.LoginDTO;
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

        [Route(""), ResponseType(typeof(SendUserDTO[]))]
        public IHttpActionResult Get()
        {
            var users = _userService.GetAllUser().Select(user =>
            new SendUserDTO()
            {
                Id = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DOB = user.DOB,
                City = user.City,
                ContactNumber = user.ContactNumber,
                Email = user.Email,
            }).ToList() ;

            return Ok(users);
        }


        [Route("{userId}"), ResponseType(typeof(SendUserDTO))]
        public IHttpActionResult Get(Guid userId)
        {
            User user = _userService.GetUserById(userId);
            if (user == null)
                return NotFound();

            SendUserDTO userDTO = new SendUserDTO()
            {
                Id = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DOB = user.DOB,
                City = user.City,
                ContactNumber = user.ContactNumber,
                Email = user.Email,
            };

            return Ok(userDTO);

        }


        [Route("addUser"), ResponseType(typeof(Guid))]
        public IHttpActionResult Post(RegisterUserDTO register)
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
                    UserName = register.Email,
                    Password = register.UserPass,
                }
            };
            Guid userId = _userService.AddNewUser(user);

            return Ok(userId);
        }


        [Route("updateUser/{userId}")]
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


        [Route("deleteUser/{userId}"), ResponseType(typeof(Guid))]
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
