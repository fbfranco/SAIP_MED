using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAIP_MED.CORE.Models;
using SAIP_MED.DATA.Config;
using SAIP_MED.DATA.Persistences;

namespace SAIP_MED.TEST.Test
{
    [TestClass]
    public class DocumentoTestRepository
    {
        AppDbContext Context;
        DocumentoRepository Repository;
        Documento Documento;

        [TestInitialize()]
        public void Initialize() {
            Context = new AppDbContext();
            Context.Database.EnsureCreated();
            Repository = new DocumentoRepository();
            Documento = new Documento();
        }

        [TestCleanup()]
        public void Cleanup() {
            Context.Dispose();
        }

        [TestMethod]
        public async Task CreateDocumentTest()
        {
            Documento.NombreDocumento = "CI";
            var Result = await Repository.Create(Documento);
            Assert.AreEqual("El Documento se guardó correctamente.",Result);
        } 

        [TestMethod]
        public async Task UpdateDocumentTest()
        {
            Documento.IdDocumento = Context.Documento.OrderByDescending(x => x.IdDocumento).First().IdDocumento;
            Documento.NombreDocumento = "CI Modificado";
            
            var Result = await Repository.Update(Documento);
            Assert.AreEqual("El Documento se actualizó correctamente.", Result);
        }

        [TestMethod]
        public async Task DeleteDocumentTest()
        {
            Documento.IdDocumento = Context.Documento.OrderByDescending(x => x.IdDocumento).First().IdDocumento;
            var Result = await Repository.Delete(Documento.IdDocumento);
            Assert.AreEqual("El Documento se eliminó correctamente.", Result);
        }

        [TestMethod]
        public async Task GetDocumentsTest() 
        { 
            var Result = await Repository.GetDocuments().ToAsyncEnumerable().Count();
            Assert.IsTrue(Result > 0);
        }
        
        [TestMethod]
        public async Task GetDocumentByIdTest() 
        { 
            Documento.IdDocumento = Context.Documento.OrderByDescending(x => x.IdDocumento).First().IdDocumento;
            var Result = await Repository.GetDocumentById(Documento.IdDocumento).ToAsyncEnumerable().Count();
            Assert.IsTrue(Result == 1);
        }
    }
}