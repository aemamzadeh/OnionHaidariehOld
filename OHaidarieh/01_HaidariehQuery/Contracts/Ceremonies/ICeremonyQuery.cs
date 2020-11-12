using System;
using System.Collections.Generic;
using System.Text;

namespace _01_HaidariehQuery.Contracts.Ceremonies
{
    public interface ICeremonyQuery
    {
        List<CeremonyQueryModel> GetCeremonies();
        List<CeremonyQueryModel> GetComing();
        List<CeremonyQueryModel> GetPast();
        List<CeremonyQueryModel> GetAll();
        List<CeremonyQueryModel> GetCeremonyWithMultimedias();
        CeremonyQueryModel GetCeremonyWithMultimedias(string id);
        List<CeremonyQueryModel> Search(string phrase);
    }
}
