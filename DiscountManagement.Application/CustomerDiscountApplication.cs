using _0_Framework.Application;
using DiscountManagement.Application.Contract.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscountAgg;
using System;
using System.Collections.Generic;

namespace DiscountManagement.Application
{
    public class CustomerDiscountApplication : ICoustomerDiscountApplication
    {
        private readonly ICustomerDiscountRepository _customerDiscountRepository;

        public CustomerDiscountApplication(ICustomerDiscountRepository customerDiscountRepository)
        {
            _customerDiscountRepository = customerDiscountRepository;
        }

        public OperationResult Define(DefineCustomerDiscount command)
        {
           var operation=new OperationResult();
            if(_customerDiscountRepository.Exists(x=>x.ProductId==command.ProductId 
            && x.DiscountRate==command.DiscountRate))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            var startdate=command.StartDate.ToGeorgianDateTime();
            var enddate=command.EndDate.ToGeorgianDateTime();
            var customerDiscount = new CustomerDiscount(command.ProductId, command.DiscountRate,
                startdate, enddate, command.Reason);
            _customerDiscountRepository.Create(customerDiscount);
            _customerDiscountRepository.SaveChange();
            return operation.Succedded();
        }

        public OperationResult Edit(EditCustomerDiscount command)
        {
            var operation= new OperationResult();
            var customerDiscount=_customerDiscountRepository.Get(command.Id);
            if(customerDiscount==null)
                return operation.Failed(ApplicationMessage.RecordNotFound);
            if (_customerDiscountRepository.Exists(x => x.ProductId == command.ProductId
            && x.DiscountRate == command.DiscountRate))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            var startdate = command.StartDate.ToGeorgianDateTime();
            var enddate = command.EndDate.ToGeorgianDateTime();

            customerDiscount.Edit(command.ProductId, command.DiscountRate,
                startdate, enddate, command.Reason);
  
            _customerDiscountRepository.SaveChange();
            return operation.Succedded();
        }

        public EditCustomerDiscount GetDetails(long id)
        {
            return _customerDiscountRepository.GetDetails(id);
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchmodel)
        {
            return _customerDiscountRepository.Search(searchmodel);
        }
    }
}
