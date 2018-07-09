using System.Collections.Generic;
using System.Threading.Tasks;
using SAIP_MED.CORE.Models;

namespace SAIP_MED.CORE.Interfaces
{
    public interface IMedicoRepository
    {
        Task<string> Create(Medico medico);
        Task<string> Update(Medico medico);
        Task<string> Delete(int id);
        Task<IEnumerable<Medico>>  GetMedicos();
        Task<Medico> GetMedicoById(int id);
    }
}