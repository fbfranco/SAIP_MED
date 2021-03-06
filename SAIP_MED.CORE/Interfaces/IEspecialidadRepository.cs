using System.Collections.Generic;
using System.Threading.Tasks;
using SAIP_MED.CORE.Models;

namespace SAIP_MED.CORE.Interfaces
{
    public interface IEspecialidadRepository
    {
        Task<string> Create(Especialidad especialidad);
        Task<string> Update(Especialidad especialidad);
        Task<string> Delete(int id);
        Task<IEnumerable<Especialidad>> GetEspecialidades();
        Task<Especialidad> GetEspecialidadById(int id);
    }
}