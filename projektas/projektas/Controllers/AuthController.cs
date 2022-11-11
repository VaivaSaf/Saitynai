using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using projektas.Auth.Model;

namespace projektas.Controllers
{
    [ApiController]
    [Route("api")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ForumRestUser> _userManager;
        private readonly IJwtTokenService _jwtTokenService;

        public AuthController(UserManager<ForumRestUser> userManager, IJwtTokenService jwtTokenService)
        {
            _userManager = userManager;
            _jwtTokenService = jwtTokenService;
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterUserDto registerUserDto)
        {
            var user = await _userManager.FindByNameAsync(registerUserDto.UserName);
            if(user != null)
            {
                return BadRequest("Request Error");
            }
            var newUser = new ForumRestUser
            { 
                Email = registerUserDto.Email,
                UserName = registerUserDto.UserName
            };
            var createUserResult = await _userManager.CreateAsync(newUser, registerUserDto.Password);
            if(!createUserResult.Succeeded)
            {
                return BadRequest("Could nor create a user");
            }
            await _userManager.AddToRoleAsync(newUser, ForumRoles.SystemUser);

            return CreatedAtAction(nameof(Register), new UserDto(newUser.Id, newUser.UserName, newUser.Email));

        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.UserName);
            if (user == null)
            {
                return BadRequest("User name or password is invalid");
            }
            var isPasswordValid = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if(!isPasswordValid)
            {
                return BadRequest("User name or password is invalid");
            }

            var roles = await _userManager.GetRolesAsync(user);
            var accessToken = _jwtTokenService.CreateAccesssToken(user.UserName, user.Id, roles);

            return Ok(new SuccessfulLoginDto(accessToken));
        }
    }
}
