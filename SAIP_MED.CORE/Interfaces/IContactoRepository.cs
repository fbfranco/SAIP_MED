using System.Collections.Generic;
using System.Threading.Tasks;
using SAIP_MED.CORE.Models;

namespace SAIP_MED.CORE.Interfaces
{
    public interface IContactoRepository
    {
        Task<string> Create(Contacto contacto);
        Task<string> Update(Contacto contacto);
        Task<string> Delete(int id);
        Task<IEnumerable<Contacto>>  GetContactos();
        Task<Contacto> GetContactoById(int id);
    }
}