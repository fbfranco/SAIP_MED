using System.Collections;
using System.Threading.Tasks;
using SAIP_MED.CORE.Models;

namespace SAIP_MED.CORE.Interfaces
{
    public interface IEmpleadoRepository
    {
        Task<string> Create(Empleado empleado);
        Task<string> Update(Empleado empleado);
        Task<string> Delete(int id);
        Task<IEnumerable>  GetEmpleados();
        Task<Empleado> GetEmpleadoById(int id);
    }
}