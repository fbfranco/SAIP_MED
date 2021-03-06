using System.Collections.Generic;
using System.Threading.Tasks;
using SAIP_MED.CORE.Models;

namespace SAIP_MED.CORE.Interfaces
{
    public interface IDocumentoRepository
    {
        Task<string> Create(Documento document);
        Task<string> Update(Documento document);
        Task<string> Delete(int id);
        Task<IEnumerable<Documento>> GetDocuments();
        Task<Documento> GetDocumentById(int id);
    }
}