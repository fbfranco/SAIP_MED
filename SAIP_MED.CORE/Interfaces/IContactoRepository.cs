using System.Collections;
using System.Threading.Tasks;
using SAIP_MED.CORE.Models;

namespace SAIP_MED.CORE.Interfaces
{
    public interface IContactoRepository
    {
        Task<string> Create(Contacto contacto);
        Task<string> Update(Contacto contacto);
        Task<string> Delete(int id);
        Task<IEnumerable>  GetContactos();
        Task<Contacto> GetContactoById(int id);
    }
}