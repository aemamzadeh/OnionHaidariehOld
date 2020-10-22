using _01_HaidariehQuery.Contracts.Members;
using Haidarieh.Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01_HaidariehQuery.Query
{
    public class MemberQuery:IMemberQuery
    {
        private readonly HContext _hContext;

        public MemberQuery(HContext hContext)
        {
            _hContext = hContext;
        }

        public List<MemberQueryModel> GetAll()
        {
            return _hContext.Members.Where(x=>x.Status==true).Select(x=>new MemberQueryModel
            {
                FullName=x.FullName,
                Mobile=x.Mobile,
                Status=x.Status
            }).ToList();
        }
    }
}
