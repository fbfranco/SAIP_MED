using System.Collections.Generic;
using System.Threading.Tasks;
using SAIP_MED.CORE.Models;

namespace SAIP_MED.CORE.Interfaces
{
    public interface IPacienteRepository
    {
        Task<string> Create(Paciente paciente);
        Task<string> Update(Paciente paciente);
        Task<string> Delete(int id);
        Task<IEnumerable<Paciente>> GetPacientes();
        Task<Paciente> GetPacienteById(int id);
    }
}