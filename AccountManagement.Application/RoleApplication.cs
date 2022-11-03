﻿using _0_Framework.Application;
using AccountManagement.Application.Contracts.Role;
using AccountManagement.Domain.RoleAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application
{
    public class RoleApplication : IRoleApplication
    {
        private readonly IRoleRepository _roleRepository;

        public RoleApplication(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public OperationResult Create(CreateRole command)
        {
            var operation=new OperationResult();
            if (_roleRepository.Exists(x => x.Name == command.Name))
                operation.Failed(ApplicationMessage.DuplicatedRecord);
            var role = new Role(command.Name);
            _roleRepository.Create(role);
            _roleRepository.SaveChange();
            return operation.Succedded();

        }

        public OperationResult Edit(EditRole command)
        {
            var operation=new OperationResult();
            var role = _roleRepository.Get(command.Id);
            if(role == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);
            if (_roleRepository.Exists(x => x.Name == command.Name&& x.Id!=command.Id))
                operation.Failed(ApplicationMessage.DuplicatedRecord);
            role.Edit(command.Name);
            _roleRepository.SaveChange();
            return operation.Succedded();
        }

        public EditRole GetDetails(long id)
        {
            return _roleRepository.GetDetails(id);
        }

        public List<RoleViewModel> List()
        {
           return _roleRepository.List();
        }
    }
}