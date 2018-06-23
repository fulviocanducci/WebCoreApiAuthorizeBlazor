using Api.Data;
using Api.Extensions;
using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]User user,
            [FromServices]UserManager<ApplicationUser> userManager,
            [FromServices]SignInManager<ApplicationUser> signInManager,
            [FromServices]SigningConfigurations signingConfigurations,
            [FromServices]TokenConfigurations tokenConfigurations)
        {
            await CheckUserCreatedAsync(userManager);

            if (string.IsNullOrEmpty(user.Email)) return NotFound(new { Message = "E-mail invalid" });
            if (string.IsNullOrEmpty(user.Password)) return NotFound(new { Message = "Password invalid" });

            ApplicationUser appUser = await userManager.FindByEmailAsync(user.Email);

            if (appUser == null) return NotFound(new { Message = "User not exists" });
            var result = await signInManager.CheckPasswordSignInAsync(appUser, user.Password, false);

            if (!result.Succeeded) return NotFound(new { Message = "User not credentials" });

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new GenericIdentity(appUser.Email, "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, appUser.Id),
                        new Claim(JwtRegisteredClaimNames.UniqueName, appUser.Email)
                    }
                );
            
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            SecurityToken securityToken = handler.CreateToken(tokenConfigurations, signingConfigurations, claimsIdentity);
            string token = handler.WriteToken(securityToken);

            return Ok(TokenValidate.Create(true, handler.DateCreateToken(), handler.DateExpirationToken(), token));
        }

        [NonAction]
        public async Task CheckUserCreatedAsync(UserManager<ApplicationUser> userManager)
        {
            if (await userManager.FindByEmailAsync("fulviocanducci@hotmail.com") == null)
            {
                var result = await userManager.CreateAsync(new ApplicationUser
                {
                    Email = "fulviocanducci@hotmail.com",
                    UserName = "fulviocanducci@hotmail.com",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                }, "Ab@123456");
            }
        }
    }
}