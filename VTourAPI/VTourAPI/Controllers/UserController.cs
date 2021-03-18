using Microsoft.AspNetCore.Mvc;
using VTourAPI.Models;
using VTourAPI.Repositories;

namespace VTourAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository userRepository;

        public UserController(UserRepository userRepository) => this.userRepository = userRepository;

        // GET api/<UserController>
        [HttpGet("{mail}")]
        public  UserInfo Get(string mail) =>  this.userRepository.ReadUser(mail);

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] UserInfo userInfo) => this.userRepository.CreateUser(userInfo);

        // PUT api/<UserController>
        [HttpPut]
        public void Put([FromBody] UserInfo userInfo)
        {
            
            //userInfo.Id = this.userRepository.ReadUser(userInfo.Email).Id;
            this.userRepository.UpdateUser(userInfo);
        }

        // DELETE api/<UserController>
        [HttpDelete("{mail}")]
        public void Delete(string mail)
        {
            var user = this.userRepository.ReadUser(mail);
            if (user != null)
            {
                this.userRepository.DeleteUser(user);
            }
        }
    }
}