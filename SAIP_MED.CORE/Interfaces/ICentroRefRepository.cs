using System.Collections;
using System.Threading.Tasks;
using SAIP_MED.CORE.Models;

namespace SAIP_MED.CORE.Interfaces
{
    public interface ICentroRefRepository
    {
         Task<string> Create(CentroRef centro);
         Task<string> Update(CentroRef centro);
         Task<string> Delete(int id);
         Task<IEnumerable> GetCentros();
         Task<CentroRef> GetCentroById(int id);
    }
}