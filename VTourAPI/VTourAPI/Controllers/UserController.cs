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
        public User Get(string mail) => this.userRepository.ReadUser(mail);

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] User user) => this.userRepository.CreateUser(user);

        // PUT api/<UserController>
        [HttpPut]
        public void Put([FromBody] User user)
        {
            
            user.Id = this.userRepository.ReadUser(user.Email).Id;
            this.userRepository.UpdateUser(user);
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