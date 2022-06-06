using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Options;
using Forum.RequestModel;
using Forum.Services;
using Forum.Entities;
using Forum.Helpers;
using Forum.Auth;
using Forum.Controllers;
using Forum.Db_Context;

namespace Forum.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        IUserService _userService;
        private DataContext _dataContext;

        public UserController(IUserService userService, DataContext context) //HttpContext context*/
        {
            _userService = userService;
            _dataContext = context;

        }
        [AllowAnonymous]
        [HttpGet("getUsers")]
        public IActionResult GetUsers()
        {
            var allUsers = _userService.GetUsers();
           
            return Ok(allUsers); 
        }
        [AllowAnonymous]
        [HttpGet("getFromName")]
        public IActionResult GetFromName([FromQuery] UserByNameRequest userModel)
        {
            var oneUser = _userService.GetFromName(userModel);

            return Ok(oneUser);

        }

        [HttpGet("getFromId")]
        public IActionResult GetFromId(int id)
        {

            var oneUser = _userService.GetFromId(id);
            if(oneUser == null)
            {
                return BadRequest("User not found");
            }

            return Ok(oneUser);
            
        }



        [AllowAnonymous]
        [HttpPost("createUser")]
        public IActionResult CreateNewUser(CreateUserRequest userModel)
        {
            if (_dataContext.Users.Any(user => user.Username == userModel.Username))
            {
                return BadRequest("Username taken");
            }

            _userService.CreateNewUser(userModel);

            return Ok(new { userModel.Username });


        }

        [AllowAnonymous]
        [HttpPost("authUser")]
        public IActionResult UserAuth(UserAuthRequest authModel)
        {
            var authUser = _dataContext.Users.FirstOrDefault(u => u.Username == authModel.Username);

            if (authUser == null)
            {
                return BadRequest("Username or password was wrong/not found");

            }
            if (!BCrypt.Net.BCrypt.Verify(authModel.Password, authUser.Password))
            {
                return BadRequest("Username or password was wrong/not found");
            }

            var response = _userService.UserAuth(authModel);
            var id = response.Id;

            return Ok(response);

        }


        [HttpPatch("updateUser")]
        public IActionResult UpdateUser(int id,UpdateUser userModel)
        {

            if (_dataContext.Users.Any(user => user.Username == userModel.Username))
            {
                return BadRequest("Username or password taken");


            }

            _userService.UpdateUser(id, userModel);
            return Ok(new { message = "Update done!" });
        }
        [HttpDelete("deleteUser")]
        public IActionResult DeleteUser(int id)
        {
            _userService.RemoveUser(id);
            return Ok(new{ message = "User deleted" });
        }

    }
}