using _0_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Haidarieh.Domain.MemberAgg
{
    public class Member : EntityBase
    {
        public string FullName { get; private set; }
        public string Mobile { get; private set; }
        public bool Status { get; private set; }

        public Member(string fullName, string mobile)
        {
            FullName = fullName;
            Mobile = mobile;
            Status = true;
        }
        public void Edit(string fullName, string mobile)
        {
            FullName = fullName;
            Mobile = mobile;
            Status = true;
        }
    }
}
