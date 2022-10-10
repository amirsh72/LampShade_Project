using _0_Framework.Application;
using ShopManagement.application.Contracts.Slide;
using ShopManagement.Domain.SlideAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Aplication
{
    public class SlideApplication : ISlideApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly ISlideRepository _slideRepository;

        public SlideApplication(ISlideRepository slideRepository, IFileUploader fileUploader)
        {
            _slideRepository = slideRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateSlide command)
        {
            var operation=new OperationResult();
            var pictureName = _fileUploader.Upload(command.Picture, "Slide");
            var slide = new Slide(pictureName, command.PictureAlt, command.Title
                , command.Heading, command.Title, command.Text, command.BtnText,command.Link);
            _slideRepository.Create(slide);
            _slideRepository.SaveChange();
            return operation.Succedded();
        }

        public OperationResult Edit(EditSlide command)
        {
            var operation = new OperationResult();
            var slide=_slideRepository.Get(command.Id);
            if (slide == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);
            var pictureName = _fileUploader.Upload(command.Picture, "Slide");
            slide.Edit(pictureName, command.PictureAlt, command.Title
                , command.Heading, command.Title, command.Text, command.BtnText,command.Link);
            _slideRepository.SaveChange();
            return operation.Succedded();

        }

        public EditSlide GetDetails(long id)
        {
            return _slideRepository.GetDetails(id);
        }

        public List<SlideViewModel> GetList()
        {
            return _slideRepository.GetList();
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var slide = _slideRepository.Get(id);
            if (slide == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);
            slide.Remove();
            _slideRepository.SaveChange();
            return operation.Succedded();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var slide = _slideRepository.Get(id);
            if (slide == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);
            slide.Restore();
            _slideRepository.SaveChange();
            return operation.Succedded();
        }
    }
}
