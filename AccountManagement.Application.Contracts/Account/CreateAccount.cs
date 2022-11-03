using _0_Framework.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contracts.Account
{
    public class CreateAccount
    {
        [Required(ErrorMessage =ValidationMessages.IsRequierd)]
        public string Fullname { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequierd)]
        public string Username { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequierd)]
        public string Password { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequierd)]
        public string Mobile { get;  set; }
        [Range(1,int.MaxValue,ErrorMessage =ValidationMessages.IsRequierd)]
        public long RoleId { get;  set; }
        public IFormFile ProfilePhoto { get;  set; }
    }
}
