using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAIP_MED.CORE.Models;
using SAIP_MED.DATA.Config;
using SAIP_MED.DATA.Persistences;

namespace SAIP_MED.TEST.Test
{
    [TestClass]
    public class EspecialidadTestRepository
    {
        AppDbContext Context;
        EspecialidadRepository Repository;
        Especialidad Especialidad;

        [TestInitialize()]
        public void Initialize() {
            Context = new AppDbContext();
            Context.Database.EnsureCreated();
            Repository = new EspecialidadRepository();
            Especialidad = new Especialidad();
        }

        [TestCleanup()]
        public void Cleanup() {
            Context.Dispose();
        }

        [TestMethod]
        public async Task CreateEspecialidadTest()
        {
            Especialidad.NombreEspecialidad = "Cardiólogo";
            var Result = await Repository.Create(Especialidad);
            Assert.AreEqual("La Especialidad se guardó correctamente.",Result);
        } 

        [TestMethod]
        public async Task UpdateEspecialidadTest()
        {
            Especialidad.IdEspecialidad = Context.Especialidad.OrderByDescending(x => x.IdEspecialidad).First().IdEspecialidad;
            Especialidad.NombreEspecialidad = "Cardiólogo Modificado";
            
            var Result = await Repository.Update(Especialidad);
            Assert.AreEqual("La Especialidad se actualizó correctamente.", Result);
        }

        [TestMethod]
        public async Task DeleteEspecialidadTest()
        {
            Especialidad.IdEspecialidad = Context.Especialidad.OrderByDescending(x => x.IdEspecialidad).First().IdEspecialidad;
            var Result = await Repository.Delete(Especialidad.IdEspecialidad);
            Assert.AreEqual("La Especialidad se eliminó correctamente.", Result);
        }

        [TestMethod]
        public async Task GetEspecialidadsTest() 
        { 
            var Result = await Repository.GetEspecialidades().ToAsyncEnumerable().Count();
            Assert.IsTrue(Result > 0);
        }
        
        [TestMethod]
        public async Task GetEspecialidadByIdTest() 
        { 
            Especialidad.IdEspecialidad = Context.Especialidad.OrderByDescending(x => x.IdEspecialidad).First().IdEspecialidad;
            var Result = await Repository.GetEspecialidadById(Especialidad.IdEspecialidad).ToAsyncEnumerable().Count();
            Assert.IsTrue(Result == 1);
        }
    }
}