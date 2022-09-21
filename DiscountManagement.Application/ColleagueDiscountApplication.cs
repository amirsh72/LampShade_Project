using _0_Framework.Application;
using DiscountManagement.Application.Contract.ColleagueDiscount;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application
{
    public class ColleagueDiscountApplication : IColleageDiscountApplication
    {
        private readonly IColleagueDiscountRepository _colleagueDiscountRepository;

        public ColleagueDiscountApplication(IColleagueDiscountRepository colleagueDiscountRepository)
        {
            _colleagueDiscountRepository = colleagueDiscountRepository;
        }

        public OperationResult Define(DefineColleagueDiscount command)
        {
            var operation=new OperationResult();
            if (_colleagueDiscountRepository.Exists(x => x.ProductId == command.ProductId &&
             x.DiscountRate == command.DiscountRate))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);
            var colleaguediscount = new ColleagueDiscount(command.ProductId, command.DiscountRate);
            _colleagueDiscountRepository.Create(colleaguediscount);
            _colleagueDiscountRepository.SaveChange();
            return operation.Succedded();
        }

        public OperationResult Edit(EditColleagueDiscount command)
        {
            var operation = new OperationResult();
            var colleaguediscount = _colleagueDiscountRepository.Get(command.Id);

            if(colleaguediscount == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);
            if (_colleagueDiscountRepository.Exists(x => x.ProductId == command.ProductId &&
             x.DiscountRate == command.DiscountRate&& x.Id==command.Id))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);
            
            colleaguediscount.Edit(command.Id, command.DiscountRate);
            _colleagueDiscountRepository.SaveChange();
            return operation.Succedded();
        }

        public EditColleagueDiscount GetDetails(long id)
        {
            return _colleagueDiscountRepository.GetDetails(id);
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var colleaguediscount = _colleagueDiscountRepository.Get(id);

            if (colleaguediscount == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);
            

            colleaguediscount.Remove();
            _colleagueDiscountRepository.SaveChange();
            return operation.Succedded();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var colleaguediscount = _colleagueDiscountRepository.Get(id);

            if (colleaguediscount == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);


            colleaguediscount.Restore();
            _colleagueDiscountRepository.SaveChange();
            return operation.Succedded();
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchmodel)
        {
           return _colleagueDiscountRepository.Search(searchmodel);
        }
    }
}
