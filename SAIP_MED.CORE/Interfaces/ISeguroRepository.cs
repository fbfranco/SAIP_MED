using System.Collections;
using System.Threading.Tasks;
using SAIP_MED.CORE.Models;

namespace SAIP_MED.CORE.Interfaces
{
    public interface ISeguroRepository
    {
        Task<string> Create(Seguro seguro);
        Task<string> Update(Seguro seguro);
        Task<string> Delete(int id);
        Task<IEnumerable>  GetSeguros();
        Task<Seguro> GetSeguroById(int id);
    }
}