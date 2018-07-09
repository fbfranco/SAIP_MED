using SAIP_MED.CORE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAIP_MED.CORE.Interfaces
{
    public interface ICentroRefRepository
    {
         Task<string> Create(CentroRef centro);
         Task<string> Update(CentroRef centro);
         Task<string> Delete(int id);
         Task<IEnumerable<CentroRef>> GetCentros();
         Task<CentroRef> GetCentroById(int id);
    }
}