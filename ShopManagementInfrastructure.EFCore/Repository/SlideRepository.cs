using _0_Framework.Application;
using _0_Framework.Infrastructure;
using ShopManagement.application.Contracts.Slide;
using ShopManagement.Domain.SlideAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagementInfrastructure.EFCore.Repository
{
    public class SlideRepository : RepositoryBase<long, Slide>, ISlideRepository
    {
        private readonly ShopContext  _context;

        public SlideRepository(ShopContext context):base(context)
        {
            _context = context;
        }

        public EditSlide GetDetails(long id)
        {
           return _context.slides.Select(x=>new EditSlide {
               Id =x.Id,
               BtnText = x.BtnText,
               Heading=x.Heading,
               Picture=x.Picture,
               PictureAlt=x.PictureAlt,
               PictureTitle=x.PictureTitle,
               Text=x.Text,
               Title=x.Title,

           }).FirstOrDefault(x=>x.Id==id);
        }

        public List<SlideViewModel> GetList()
        {
            return _context.slides.Select(x=>new SlideViewModel
            {
                Id = x.Id,
                Heading=x.Heading,
                Picture= x.Picture,
                Title=x.Title,
                IsRemoved=x.IsRemove,
                CreationDate=x.CreationDate.ToFarsi()
            }).OrderByDescending(x=>x.Id).ToList();
        }
    }
}
