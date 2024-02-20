using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectEMS.BAL.Interface;
using ProjectEMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectEMS.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IEmployees _Db;
        public LoginController(IEmployees Db)
        {
            _Db = Db;
        }
        [Route("loginapi")]
        [HttpPost]
        public IActionResult LogIn(LoginRequestModel loginRequestModel)
        {
            var username = loginRequestModel.Email;
            var password = loginRequestModel.Password;
            var log = _Db.Authenticate(username, password);
            return Ok(log);
        }
        }
}
