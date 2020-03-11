using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PowerBI.Models.Authentication;
using PowerBI.Models.Configuration;
using PowerBI.Services.Authentication.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PowerBI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly AuthenticationConfig _authConfig;
        private readonly IAppAuthenticationService _appAuthenticationService;

        public AuthenticationController(IAppAuthenticationService appAuthenticationService , IOptions<AuthenticationConfig> authConfig)
        {
            _authConfig = authConfig.Value;
            _appAuthenticationService = appAuthenticationService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody]UserModel login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        private string GenerateJSONWebToken(UserModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authConfig.JwtEncryptionKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_authConfig.Audience,
              _authConfig.Audience,
              new List<Claim> { new Claim(ClaimTypes.Name, userInfo.Username) },
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserModel AuthenticateUser(UserModel login)
        {
            UserModel user = null;

            user = _appAuthenticationService.AuthenticateUser(login.Username);

            return user;
        }
    }
}