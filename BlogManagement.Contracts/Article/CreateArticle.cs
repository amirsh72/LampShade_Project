using _0_Framework.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Application.Contracts.Article
{
    public class CreateArticle
    {
        [Required(ErrorMessage =ValidationMessages.IsRequierd)]
        public string Title { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequierd)]
        public string ShortDescription { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequierd)]
        public string Description { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequierd)]
        public IFormFile Picture { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequierd)]
        public string PictureAlt { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequierd)]
        public string PictureTitle { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequierd)]
        public string PublishDate { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequierd)]
        public string Slug { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequierd)]
        public string Keywords { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequierd)]
        public string MetaDescription { get; set; }
        public string CanonicalAddress { get; set; }
        [Range(1,1000)]
        public long CategoryId { get; set; }
    }

}
