using _0_Framework.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.application.Contracts.Product
{
    public class CreateProduct
    {
        [Required(ErrorMessage = ValidationMessages.IsRequierd)]
        public string Name { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequierd)]
        public string Code { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequierd)]
        public string ShortDescription { get;  set; }
        public string Description { get;  set; }
        public IFormFile Picture { get; set; }
        public string PictureAlt { get;  set; }
        public string PictureTitle { get;  set; }
        public long CategoryId { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequierd)]
        public string Slug { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequierd)]
        public string KeyWords { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequierd)]
        public string MetaDescription { get;  set; }
    }
}
