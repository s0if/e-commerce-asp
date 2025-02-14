using Azure.Core;
using E_commerce_core.DTO_s;
using E_commerce_core.Interface;
using E_commerce_core.Models;
using E_commerce_Infrastructure.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_Infrastructure.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<Users> userManager;
        private readonly SignInManager<Users> signInManager;
        private readonly AuthServices authServices;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IUrlHelper urlHelper;

        public AuthRepository(UserManager<Users> userManager, SignInManager<Users> signInManager, AuthServices authServices, IHttpContextAccessor httpContextAccessor, IUrlHelperFactory urlHelperFactory, IActionContextAccessor actionContextAccessor)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.authServices = authServices;
            this.httpContextAccessor = httpContextAccessor;
            urlHelper = urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext);
        
        }
        public async Task<string> RegisterAsync(Users user, string password)
        {
            var result = await userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                //string token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                string token=await authServices.CreateTokenAsync(user, userManager);

                string confirmEmail = urlHelper.Action("ConfirmEmail", "Auth", new { email = user.Email, token = token }, protocol: httpContextAccessor.HttpContext.Request.Scheme);

                EmailDTOs emailDTOs = new EmailDTOs()
                {
                    Subject = "Confirm Email",
                    Recivers = user.Email,
                    Body = confirmEmail
                };

                EmailSetting.SendEmail(emailDTOs);
                return "User registered successfully. Confirmation email sent.";

            }
            List<string> errorMessage = result.Errors.Select(error => error.Description).ToList();
            return string.Join(", ", errorMessage);
        }
        public async Task<string> LoginAsync(string username, string password)
        {


            Users user = await userManager.FindByNameAsync(username);
            if (user is not null)
            {

                var result = await signInManager.PasswordSignInAsync(user, password, false, false);
                if (result.Succeeded)
                {
                    return await authServices.CreateTokenAsync(user, userManager);
                }
            }
            return null;
        }
        public async Task<string> ChangePassword(string email, string oldPassword, string newPassword)
        {
            Users user = await userManager.FindByEmailAsync(email);
            if (user is not null)
            {
                IdentityResult result = await userManager.ChangePasswordAsync(user, oldPassword, newPassword);


                if (result.Succeeded)
                {
                    return "done";
                }
                return string.Join(",", result.Errors.Select(e => e.Description));
            }
            return null;
        }

        public async Task<string> ForgetPassword(ForgetPasswordDTOs request, string restPasswordUrl)
        {
           Users user=await userManager.FindByEmailAsync(request.Email);
            if (user is not null) 
            {        
                EmailDTOs emailDTOs = new EmailDTOs()
                {
                    Subject = "Rest Password"   ,
                    Recivers=user.Email,
                    Body= restPasswordUrl
                };

               EmailSetting.SendEmail(emailDTOs);
            return "done";
            }
            return null;
        }

        public async Task<string> RestPassword(RestPasswordDTOs restPasswordDTOs, string token)
        {
          Users user =await userManager.FindByEmailAsync(restPasswordDTOs.email);
            if (user is not null) {
                IdentityResult result = await userManager.ResetPasswordAsync(user, token, restPasswordDTOs.NewPassword);
                if (result.Succeeded) {
                    return "done";
                }
                return "fail rest password";
            }
            return null;
        }

        public async Task<string> ConfirmEmailAsync(string userId)
        {
            if (userId is not null)
            {
                Users user = await userManager.FindByIdAsync(userId);
                if (user is not null) {
                  user.EmailConfirmed = true;
                    await userManager.UpdateAsync(user);
                        return "done";
                }
                return "user not found";
            }
                   
            return null;
        }
    }
}
