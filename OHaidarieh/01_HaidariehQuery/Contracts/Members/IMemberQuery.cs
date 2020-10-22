using System;
using System.Collections.Generic;
using System.Text;

namespace _01_HaidariehQuery.Contracts.Members
{
    public interface IMemberQuery
    {
        List<MemberQueryModel> GetAll();
    }
}
