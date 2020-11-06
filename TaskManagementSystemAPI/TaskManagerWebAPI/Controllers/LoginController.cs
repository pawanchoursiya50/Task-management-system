using System;
using System.Linq;
using System.Web.Http;
using TaskManagerCore.Models;
using TaskManagerWebAPI.DTOModels.LoginDTO;
using TaskManagerWebAPI.Service;

namespace TaskManagerWebAPI.Controllers
{
    [RoutePrefix("api/v1/login")]
    public class LoginController : ApiController
    {
        private LoginService _loginService;
        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [Route("{userName}/{userPass}")]
        public IHttpActionResult GetLogin(string userName, string userPass)
        {
            var loginCredentials = _loginService.GetAllLoginCredential();

            LoginCredential loginCredential = loginCredentials.Where(login => 
            login.UserName == userName && login.Password == userPass
            ).SingleOrDefault();

            if(loginCredential == null)
            {
                return NotFound();
            }

            return Ok(loginCredential.Id);

        }

        [Route("confirmEmail")]
        public IHttpActionResult PostResetPass([FromBody]string email)
        {
            var loginCredentials = _loginService.GetAllLoginCredential();

            LoginCredential loginCredential = loginCredentials.Where(login =>
            login.UserName == email
            ).SingleOrDefault();

            if (loginCredential == null)
            {
                return NotFound();
            }

            return Ok(loginCredential.Id);
        }

        [Route("resetPass/{userId}")]
        public IHttpActionResult Put(Guid userId, ForgetDTO forgetDTO)
        {
            LoginCredential loginCredential = _loginService.GetLoginCredentialById(userId);

            if (loginCredential == null)
            {
                return NotFound();
            }

            loginCredential.Password = forgetDTO.passWord;
            _loginService.UpdateLoginCredential();
            return Ok();
        }


    }
}
