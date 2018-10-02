using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using AspNetCore.Identity.LiteDB.Data;
using AspNetCore.Identity.LiteDB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SnipCodeAPI.Models;
using SnipCodeAPI.Services.Interfaces;

namespace SnipCodeAPI.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {   
        private IAuthService AuthService;
        public AuthController(IAuthService authService)
        {
            this.AuthService = authService;
        }

        [HttpPost("token")]
        public IActionResult Token()
        {
            var header = Request.Headers["Authorization"];

            if(!header.ToString().StartsWith("Basic"))
            {
                return BadRequest("Wrong Request");
            }

            var credValue = header.ToString().Substring("Basic ".Length).Trim();
            var usernameAndPassenc = Encoding.UTF8.GetString(Convert.FromBase64String(credValue)); //admin:pass
            var usernameAndPass = usernameAndPassenc.Split(":");

            //check in the db

            var user = AuthService.Authenticate(new LoginViewModel
            {
                Email = usernameAndPass[0],
                Password = usernameAndPass[1]
            });

            if(user == null)
            {
                return BadRequest("Bad Credentials");
            }

            var claims = new [] { new Claim(ClaimTypes.Name, usernameAndPass[0])};

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("asdasdadgreadsacsddscdscds"));
            var signInCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(issuer: "mysite.com",
             audience: "mysite.com",
             expires: DateTime.Now.AddMinutes(5),
             claims: claims,
             signingCredentials: signInCredentials);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(tokenString);
        }

    }
}