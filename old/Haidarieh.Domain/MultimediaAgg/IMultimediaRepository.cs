using System;
using System.Collections.Generic;
using System.Text;

namespace Haidarieh.Domain.MultimediaAgg
{
    public interface IMultimediaRepository
    {
        void Create(Multimedia entity);
        Multimedia Get(long Id);
        List<Multimedia> GetAll();
    }
}
