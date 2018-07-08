using System.Collections;
using System.Threading.Tasks;
using SAIP_MED.CORE.Models;

namespace SAIP_MED.CORE.Interfaces
{
    public interface IPacienteRepository
    {
        Task<string> Create(Paciente paciente);
        Task<string> Update(Paciente paciente);
        Task<string> Delete(int id);
        Task<IEnumerable> GetPacientes();
        Task<Paciente> GetPacienteById(int id);
    }
}