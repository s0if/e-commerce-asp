using E_commerce_API.HelperFunctions;
using E_commerce_core.DTO_s;
using E_commerce_core.Interface;
using E_commerce_core.Models;
using E_commerce_Infrastructure.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace E_commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository authRepository;
        private readonly UserManager<Users> userManager;

        public AuthController(IAuthRepository authRepository,UserManager<Users> userManager)
        {
            this.authRepository = authRepository;
            this.userManager = userManager;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTOs request)
        {
            if (ModelState.IsValid)
            {
                Users user = new Users()
                {
                    UserName = request.Name,
                    Email = request.Email,
                    CityId = request.CityCode,
                    GovernmentsId = request.GovCode,
                    ZonesId = request.ZoneCode,

                };
                


                var result = await authRepository.RegisterAsync(user, request.Password);

                return new JsonResult(result);
            }
            return BadRequest(ModelState);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTOs request)
        {
            if (ModelState.IsValid)
            {
                string ReturnMessage = await authRepository.LoginAsync(request.Name, request.Password);
                if (string.IsNullOrEmpty(ReturnMessage))
                {
                    return Unauthorized(new { message = "username or password error" });
                }

                return Ok(new { message = "Token", ReturnMessage });

            }
            return BadRequest(ModelState);
        }
        [HttpPut("UpdatePassword")]
        
        public async Task<IActionResult> UpdatePassword(ChangePasswordDTOs request)
        {
            if (ModelState.IsValid)
            {
                
                string change = await authRepository.ChangePassword(request.Email, request.OldPassword, request.NewPassword);
                if (string.IsNullOrEmpty(change))
                {
                    return BadRequest("The email or password error try again");
                }
                if (change == "done")
                {

                    return Ok("Update Password Successful");
                }
                return BadRequest(change);
            }
            return BadRequest(ModelState);
        }

        [HttpPost("ForgetPassword")]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordDTOs request)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(request.Email);
                string token = await userManager.GeneratePasswordResetTokenAsync(user);
                string restPasswordUrl = Url.Action("RestPassword", "Auth", new { email = request.Email, token = token }, protocol: HttpContext.Request.Scheme);
                string rest = await authRepository.ForgetPassword(request, restPasswordUrl);
                if (string.IsNullOrEmpty(rest))
                {
                    return BadRequest("The email error try again");
                }
                if (rest == "done")
                {

                    return Ok("send Password Successful");
                }
                return BadRequest(rest);
            }
            return BadRequest(ModelState);
        }

        [HttpPost("RestPassword")]
        public async Task<IActionResult> RestPassword(RestPasswordDTOs request)
        {
            if (ModelState.IsValid)
            {
                string token = Request.Headers["Authorization"].ToString().Replace("Bearer", "");
                if (string.IsNullOrEmpty(token))
                    return Unauthorized("Token Is Missing");
                var rest = await authRepository.RestPassword(request, token);
                if (rest == "done")
                {
                    return Ok("rest successful");
                }
                if (rest is null)
                {
                    return Unauthorized("The email error try again");
                }
                return BadRequest(rest);

            }
            return BadRequest(ModelState);
        }

        [HttpGet("ConfirmEmail")]

        public async Task<IActionResult> ConfirmEmail()
        {
            if (ModelState.IsValid)
            {
                

                    string token = Request.Headers["Authorization"].ToString().Replace("Bearer", "");
                    if (string.IsNullOrEmpty(token))
                        return Unauthorized("Token Is Missing");
                int? userId = ExtractClaims.ExtractUserId(token);
                string confirm = await authRepository.ConfirmEmailAsync(userId.ToString());
                    if (string.IsNullOrEmpty(confirm))
                    {
                        return BadRequest(confirm);
                    }
                    if (confirm == "done")
                    {
                        return Ok("confirm successful");
                    }
                    return BadRequest(confirm);
                
            }
            return BadRequest(ModelState);
        }


    }
}
