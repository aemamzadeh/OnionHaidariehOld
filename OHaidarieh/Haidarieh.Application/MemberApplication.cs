using _0_Framework.Application;
using Haidarieh.Application.Contracts.Member;
using Haidarieh.Domain.MemberAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Haidarieh.Application
{
    public class MemberApplication : IMemberApplication
    {
        private readonly IMemberRepository _memberRepository;

        public MemberApplication(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public OperationResult Create(CreateMember command)
        {
            var operation = new OperationResult();
            if(_memberRepository.Exist(x=>x.Mobile==command.Mobile))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            var member = new Member(command.FullName, command.Mobile);
            _memberRepository.Create(member);
            _memberRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditMember command)
        {
            var operation = new OperationResult();
            operation.IsSuccedded = false;
            var editItem = _memberRepository.Get(command.Id);
            if (editItem == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            if(_memberRepository.Exist(x=>x.Mobile==command.Mobile && x.Id!=command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            editItem.Edit(command.FullName, command.Mobile);
            _memberRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditMember GetDetail(long Id)
        {
            return _memberRepository.GetDetail(Id);
        }

        public List<MemberViewModel> Search(MemberSearchModel searchModel)
        {
            return _memberRepository.Search(searchModel);
        }
    }
}
