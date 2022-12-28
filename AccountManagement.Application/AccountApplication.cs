using _0_Framework.Application;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Domain.AccountAgg;
using AccountManagement.Domain.RoleAgg;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountManagement.Application
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IFileUploader _fileUploader;
        private readonly IAuthHelper _authHelper;
        private readonly IRoleRepository _roleRepository;

        public AccountApplication(IAccountRepository accountRepository,
            IPasswordHasher passwordHasher,
            IFileUploader fileUploader, IAuthHelper authHelper, IRoleRepository roleRepository)
        {
            _accountRepository = accountRepository;
            _passwordHasher = passwordHasher;
            _fileUploader = fileUploader;
            _authHelper = authHelper;
            _roleRepository = roleRepository;
        }

        public OperationResult ChangePassword(ChangePassword command)
        {
            var operation=new OperationResult();
            var account = _accountRepository.Get(command.Id);
            if (account == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);
            if (command.Password != command.RePassword)
                return operation.Failed(ApplicationMessage.PasswordNotMatch);
            var password = _passwordHasher.Hash(command.Password);
            account.ChangePassword(password);
            _accountRepository.SaveChange();
            return operation.Succedded();
        }

        public OperationResult Create(CreateAccount command)
        {
            var operation=new OperationResult();
            if(_accountRepository.Exists(x=>x.Username == command.Username||x.Mobile==command.Mobile))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);
            var password=_passwordHasher.Hash(command.Password);
            var path = $"profilePhotos";
            var picturePath=_fileUploader.Upload(command.ProfilePhoto,path);
            var account = new Account(command.Fullname, command.Username, password, command.Mobile
                , command.RoleId, picturePath);
            _accountRepository.Create(account);
            _accountRepository.SaveChange();
           return operation.Succedded();
        }

        public OperationResult Edit(EditAccount command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.Get(command.Id);
            if (_accountRepository.Exists(x => (x.Username == command.Username 
            || x.Mobile == command.Mobile)
            && x.Id!=command.Id))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);
            
            var path = $"profilePhotos";
            var picturePath = _fileUploader.Upload(command.ProfilePhoto, path);
            account.Edit(command.Fullname, command.Username, command.Mobile
                , command.RoleId, picturePath);
           
            _accountRepository.SaveChange();
            return operation.Succedded();
        }

        public AccountViewModel GetAccountBy(long id)
        {
            var account = _accountRepository.Get(id);
            return new AccountViewModel()
            {
                Fullname = account.Fullname,
                Mobile = account.Mobile,
            };
        }

        public List<AccountViewModel> GetAccounts()
        {
            return _accountRepository.GetAccounts();
        }

        public EditAccount GetDetails(long id)
        {
            return _accountRepository.GetDetails(id);
        }

        public OperationResult Login(Login command)
        {
            var operation=new OperationResult();
            var account=_accountRepository.GetBy(command.Username);
            if(account==null)
                return operation.Failed(ApplicationMessage.WrongUserPass);
            var result = _passwordHasher.Check(account.Password, 
                command.Password);
            if (!result.Verified)
             return   operation.Failed(ApplicationMessage.WrongUserPass);

            var permissions = _roleRepository.Get(account.RoleId).Permissions.Select(x=>x.Code).ToList();

            

            var authViewModel = new AuthViewModel(account.Id, account.RoleId, account.Fullname, 
                account.Username,account.Mobile,permissions);
            _authHelper.Singin(authViewModel);
             
            
           return operation.Succedded();


        }

        public void Logout()
        {
            _authHelper.Singout();
        }

        public List<AccountViewModel> Search(AccountSearchModel searchModel)
        {
            return _accountRepository.Search(searchModel);
        }
    }
}
