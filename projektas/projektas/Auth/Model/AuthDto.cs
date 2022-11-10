using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace projektas.Auth.Model
{
    //public class AuthDto
    //{
    public record RegisterUserDto([Required] string UserName, [EmailAddress][Required] string Email, [Required] string Password);
    public record LoginDto(string UserName, string Password);

    public record UserDto(string Id, string UserName, string Email);
    public record SuccessfulLoginDto(string AccessToken);

    //}
}
