using biblioteca_fc_api.Models;
using biblioteca_fc_api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace biblioteca_fc_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<ActionResult<List<UserModel>>> CreateUser([FromBody] UserModel userModel)
        {
            List<UserModel> users = await _userRepository.CreateUser(userModel);
            return Ok(users);
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> FindAllUsers()
        {
            List<UserModel> users = await _userRepository.FindAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> FindUserById(int id)
        {
            UserModel user = await _userRepository.FindUserById(id);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> UpdateUser([FromBody] UserModel userModel, int id)
        {
            var user = await _userRepository.FindUserById(id);
            if (user == null)
            {
                return BadRequest("User not foud!");
            }
            userModel.Id = id;
            UserModel newUserData = await _userRepository.UpdateUser(userModel, id);
            return Ok(newUserData);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> RemoveUser(int id)
        {
            var user = await _userRepository.FindUserById(id);
            if (user == null)
            {
                return BadRequest("User not foud!");
            }

            bool isRemoved = await _userRepository.RemoveUser(id);
            return Ok(isRemoved);
        }
    }
}