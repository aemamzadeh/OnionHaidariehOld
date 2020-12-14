using _0_Framework.Application;
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
            var operation = new OperationResult();
            if (_roleRepository.Exist(x=>x.Title==command.Title))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            var role = new Role(command.Title,new List<Permission>());
            _roleRepository.Create(role);
            _roleRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditRole command)
        {
            var operation = new OperationResult();
            var editItem = _roleRepository.Get(command.Id);
            if (command.Title == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            if (command.Title == editItem.Title && command.Id != editItem.Id)
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            var permissions = new List<Permission>();
            command.Permissions.ForEach(code => permissions.Add(new Permission(code)));
            editItem.Edit(command.Title, permissions);
            _roleRepository.SaveChanges();
            return operation.Succedded();
        }
        public EditRole GetDetail(long id)
        {
            return _roleRepository.GetDetail(id);
        }
        public List<RoleViewModel> GetRoles()
        {
            return _roleRepository.GetRoles();
        }
    }
}
