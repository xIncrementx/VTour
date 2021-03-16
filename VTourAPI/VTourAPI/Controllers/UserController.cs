using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VTourAPI.Models;
using VTourAPI.Repositories;

namespace VTourAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserRepository UserRepository{ get; }

        public UserController()
        {
            UserRepository = new UserRepository();
        }

        // GET api/<UserController>
        [HttpGet("{mail}")]
        public User Get(string mail)
        {
            return UserRepository.ReadUser(mail);
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] User user)
        {
            UserRepository.CreateUser(user);
        }

        // PUT api/<UserController>
        [HttpPut]
        public void Put([FromBody] User user)
        {
            user.Id = UserRepository.ReadUser(user.Email).Id;
            if (user != null)
            {
                UserRepository.UpdateUser(user);
            }
        }

        // DELETE api/<UserController>
        [HttpDelete("{mail}")]
        public void Delete(string mail)
        {
            User user = UserRepository.ReadUser(mail);
            if (user != null)
            {
                UserRepository.DeleteUser(user);
            }
        }
    }
}
