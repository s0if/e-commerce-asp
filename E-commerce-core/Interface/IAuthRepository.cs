using E_commerce_core.DTO_s;
using E_commerce_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_core.Interface
{
    public interface IAuthRepository
    {
        Task<string> RegisterAsync (Users user, string password);
        Task<string> LoginAsync(string username,string password);
        Task<string> ChangePassword(string email,string oldPassword,string newPassword);
        Task<string> ForgetPassword(ForgetPasswordDTOs Email,string restPasswordUrl);
        Task<string> RestPassword(RestPasswordDTOs restPasswordDTOs,string token);
        Task<string> ConfirmEmailAsync(string userId);
       
    }
}
