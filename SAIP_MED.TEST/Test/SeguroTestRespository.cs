using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAIP_MED.CORE.Models;
using SAIP_MED.DATA.Config;
using SAIP_MED.DATA.Persistences;

namespace SAIP_MED.TEST.Test
{
    [TestClass]
    public class SeguroTestRespository
    {
        AppDbContext Context;
        SeguroRepository Repository;
        Seguro Seguro;

        [TestInitialize()]
        public void Initialize() {
            Context = new AppDbContext();
            Context.Database.EnsureCreated();
            Repository = new SeguroRepository();
            Seguro = new Seguro();
        }

        [TestCleanup()]
        public void Cleanup() {
            Context.Dispose();
        }

        [TestMethod]
        public async Task CreateSeguroTest()
        {
            Seguro.Nombre = "Nacional Vida";
            Seguro.IdDocumento = 1;
            Seguro.NroDocumento = "5323182-BCK SC";
            Seguro.Telefono = "69101806";
            Seguro.Direccion = "Villa 1ro de Mayo C/14 G";
            Seguro.Email = "fbfranco@gmail.com";

            var Result = await Repository.Create(Seguro);
            Assert.AreEqual("El Seguro se guardó correctamente.",Result);
        } 

        [TestMethod]
        public async Task UpdateSeguroTest()
        {
            Seguro.IdSeguro = Context.Seguro.OrderByDescending(x => x.IdSeguro).First().IdSeguro;
            Seguro.Nombre = "Nacional Vida Modificado";
            
            var Result = await Repository.Update(Seguro);
            Assert.AreEqual("El Seguro se actualizó correctamente.", Result);
        }

        [TestMethod]
        public async Task DeleteSeguroTest()
        {
            Seguro.IdSeguro = Context.Seguro.OrderByDescending(x => x.IdSeguro).First().IdSeguro;
            var Result = await Repository.Delete(Seguro.IdSeguro);
            Assert.AreEqual("El Seguro se eliminó correctamente.", Result);
        }

        [TestMethod]
        public async Task GetSegurosTest() 
        { 
            var Result = await Repository.GetSeguros().ToAsyncEnumerable().Count();
            Assert.IsTrue(Result > 0);
        }
        
        [TestMethod]
        public async Task GetSeguroByIdTest() 
        { 
            Seguro.IdSeguro = Context.Seguro.OrderByDescending(x => x.IdSeguro).First().IdSeguro;
            var Result = await Repository.GetSeguroById(Seguro.IdSeguro).ToAsyncEnumerable().Count();
            Assert.IsTrue(Result == 1);
        }
    }
}