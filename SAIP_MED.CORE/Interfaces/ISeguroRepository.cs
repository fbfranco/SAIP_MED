using SAIP_MED.CORE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAIP_MED.CORE.Interfaces
{
    public interface ISeguroRepository
    {
        Task<string> Create(Seguro seguro);
        Task<string> Update(Seguro seguro);
        Task<string> Delete(int id);
        Task<IEnumerable<Seguro>>  GetSeguros();
        Task<Seguro> GetSeguroById(int id);
    }
}