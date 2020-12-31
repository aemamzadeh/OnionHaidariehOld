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


        public AccountApplication(IAccountRepository accountRepository, IPasswordHasher passwordHasher, IFileUploader fileUploader, IAuthHelper authHelper, IRoleRepository roleRepository)
        {
            _accountRepository = accountRepository;
            _passwordHasher = passwordHasher;
            _fileUploader = fileUploader;
            _authHelper = authHelper;
            _roleRepository=roleRepository;
        }

        public OperationResult ChangePassword(ChangePassword command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.Get(command.Id);
            if (account ==null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            if (command.Password != command.RePassword)
                return operation.Failed(ApplicationMessages.PasswordNotMatched);
            var password = _passwordHasher.Hash(command.Password);
            account.ChangePassword(password);
            _accountRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Register(RegisterAccount command)
        {
            var operation = new OperationResult();
            if (_accountRepository.Exist(x => x.Username == command.Username || x.Mobile == command.Mobile))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var ImageFolderName = Tools.ToFolderName(this.GetType().Name);
            string ImagePath;
            if (command.ProfilePhoto != null)
            {
                ImagePath = $"{ImageFolderName}/{command.Fname}-{command.Lname}";
            } else
            {
                ImagePath = $"{ImageFolderName}";
            }
            var filepath = _fileUploader.Upload(command.ProfilePhoto, ImagePath);
            var password = _passwordHasher.Hash(command.Password);

            var account = new Account(command.Fname, command.Lname, command.Username, password,
                command.Mobile, command.RoleId, filepath);
            _accountRepository.Create(account);
            _accountRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditAccount command)
        {
            var operation = new OperationResult();
            var editItem = _accountRepository.Get(command.Id);

            if (editItem==null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            if (_accountRepository.Exist(x => (x.Username == command.Username || x.Mobile == command.Mobile) && x.Id!=command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var ImageFolderName = Tools.ToFolderName(this.GetType().Name);
            string ImagePath;
            if (command.ProfilePhoto != null)
            {
                ImagePath = $"{ImageFolderName}/{command.Fname}-{command.Lname}";
            }
            else
            {
                ImagePath = $"{ImageFolderName}";
            }

            var filepath = _fileUploader.Upload(command.ProfilePhoto, ImagePath);

            editItem.Edit(command.Fname, command.Lname, command.Username, command.Mobile, command.RoleId, filepath);
            _accountRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditAccount GetDetail(long Id)
        {
            return _accountRepository.GetDetail(Id);
        }

        public ChangePassword GetDetailPassword(long Id)
        {
            var item= _accountRepository.GetDetailPassword(Id);
            item.Password = null;
            return item;

        }

        public OperationResult Login(Login command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.GetAccount(command.Username);
            if (account == null)
                return operation.Failed(ApplicationMessages.AccountIsInvalid);
            var result = _passwordHasher.Check(account.Password, command.Password);
            if(!result.Verified)
                return operation.Failed(ApplicationMessages.AccountIsInvalid);

            var permissions = _roleRepository.Get(account.RoleId).Permissions.Select(x => x.Code).ToList();

            var authViewModel = new AuthViewModel(account.Id, account.Fname, account.Lname, account.Username, account.RoleId,permissions);
            _authHelper.SignIn(authViewModel);

            return operation.Succedded();
        }

        public void Logout()
        {
            _authHelper.SignOut();
        }

        public List<AccountViewModel> Search(AccountSearchModel searchModel)
        {
            return _accountRepository.Search(searchModel);
        }
    }
}
