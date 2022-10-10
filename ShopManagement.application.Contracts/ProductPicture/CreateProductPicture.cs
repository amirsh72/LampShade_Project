using _0_Framework.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.application.Contracts.ProductPicture
{
    public class CreateProductPicture
    {
        [Range(1,100000,ErrorMessage =ValidationMessages.IsRequierd)]
        public long ProductId { get;  set; }
        [Required(ErrorMessage =ValidationMessages.IsRequierd)]
        [MaxFileSize(1*1024*1024,ErrorMessage =ValidationMessages.MaxFileSize)]
        public IFormFile Picture { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequierd)]
        public string PictureAlt { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequierd)]
        public string PictureTitle { get;  set; }
    }
    

}
