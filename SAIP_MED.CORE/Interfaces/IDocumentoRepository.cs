using System;
using System.Collections;
using System.Threading.Tasks;
using SAIP_MED.CORE.Models;

namespace SAIP_MED.CORE.Interfaces
{
    public interface IDocumentoRepository
    {
        Task<string> Create(Documento document);
        Task<string> Update(int id, Documento document);
        Task<string> Delete(int id);
        Task<IEnumerable>  GetDocuments();
        Task<Documento> GetDocumentById(int id);
    }
}