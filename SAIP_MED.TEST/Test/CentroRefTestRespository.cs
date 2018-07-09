using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAIP_MED.CORE.Models;
using SAIP_MED.DATA.Config;
using SAIP_MED.DATA.Persistences;

namespace SAIP_MED.TEST.Test
{
    [TestClass]
    public class CentroRefTestRespository
    {
        AppDbContext Context;
        CentroRefRepository Repository;
        CentroRef CentroRef;

        [TestInitialize()]
        public void Initialize() {
            Context = new AppDbContext();
            Context.Database.EnsureCreated();
            Repository = new CentroRefRepository();
            CentroRef = new CentroRef();
        }

        [TestCleanup()]
        public void Cleanup() {
            Context.Dispose();
        }

        [TestMethod]
        public async Task CreateCentroTest()
        {
            CentroRef.NombreCentro = "Hospital Hernandez Vera";
            CentroRef.Telefono = "76666323";
            var Result = await Repository.Create(CentroRef);
            Assert.AreEqual("El Centro se guardó correctamente.",Result);
        } 

        [TestMethod]
        public async Task UpdateCentroTest()
        {
            CentroRef.IdCentroRef = Context.CentroRef.OrderByDescending(x => x.IdCentroRef).First().IdCentroRef;
            CentroRef.NombreCentro = "Hospital Hernandez Modificado";
            var Result = await Repository.Update(CentroRef);
            Assert.AreEqual("El Centro se actualizó correctamente.", Result);
        }

        [TestMethod]
        public async Task DeleteCentroTest()
        {
            CentroRef.IdCentroRef = Context.CentroRef.OrderByDescending(x => x.IdCentroRef).First().IdCentroRef;
            var Result = await Repository.Delete(CentroRef.IdCentroRef);
            Assert.AreEqual("El Centro se eliminó correctamente.", Result);
        }

        [TestMethod]
        public void GetCentrosTest() 
        { 
            var Result = Repository.GetCentros().Result.Count();
            Assert.IsTrue(Result > 0);
        }
        
        [TestMethod]
        public async Task GetCentroByIdTest() 
        { 
            CentroRef.IdCentroRef = Context.CentroRef.OrderByDescending(x => x.IdCentroRef).First().IdCentroRef;
            var Result = await Repository.GetCentroById(CentroRef.IdCentroRef).ToAsyncEnumerable().Count();
            Assert.IsTrue(Result == 1);
        }
    }
}