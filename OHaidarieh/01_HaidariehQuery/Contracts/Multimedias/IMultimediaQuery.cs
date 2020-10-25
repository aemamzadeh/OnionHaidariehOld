using System;
using System.Collections.Generic;
using System.Text;

namespace _01_HaidariehQuery.Contracts.Multimedias
{
    public interface IMultimediaQuery
    {
        List<MultimediaQueryModel> GetDetail(long Id);
    }
}
