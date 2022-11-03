using _0_Framework.Application;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrustructure.EFCore.RepositoryBase
{
    public class AccountRepository : RepositoryBase<long, Account>, IAccountRepository
    {
        private readonly AccountContext _context;
        public AccountRepository(AccountContext context) : base(context)
        {
            _context = context;
        }

        public Account GetBy(string username)
        {
            return _context.Accounts.FirstOrDefault(x=>x.Username==username);
        }

        public EditAccount GetDetails(long Id)
        {
            return _context.Accounts.Select(x => new EditAccount 
            {
                Id = x.Id,
                Fullname = x.Fullname,
                Mobile=x.Mobile,
                RoleId = x.RoleId,
                Username = x.Username,
            }).FirstOrDefault(x=>x.Id==Id);  
        }

        public List<AccountViewModel> Search(AccountSearchModel SearchModel)
        {
            var query = _context.Accounts.Include(x=>x.Role).Select(x => new AccountViewModel
            {
                Id = x.Id,
                Fullname = x.Fullname,
                Mobile = x.Mobile,
                ProfilePhoto = x.ProfilePhoto,
                Role = x.Role.Name,
                RoleId=x.RoleId,
                Username = x.Username,
                CreationDate=x.CreationDate.ToFarsi()

            });
            if(!string.IsNullOrWhiteSpace(SearchModel.Fullname))
                query=query.Where(x=>x.Fullname==SearchModel.Fullname);
            if(!string.IsNullOrWhiteSpace(SearchModel.Mobile))
                query = query.Where(x => x.Mobile == SearchModel.Mobile);
            if (!string.IsNullOrWhiteSpace(SearchModel.Username))
                query = query.Where(x => x.Username == SearchModel.Username);
            if (SearchModel.RoleId > 0)
                query = query.Where(x => x.RoleId == SearchModel.RoleId);
            return query.OrderByDescending(x=>x.Id).ToList();

        }
    }
}
