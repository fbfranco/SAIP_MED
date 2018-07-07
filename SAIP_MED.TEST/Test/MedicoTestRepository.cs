using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAIP_MED.CORE.Models;
using SAIP_MED.DATA.Config;
using SAIP_MED.DATA.Persistences;

namespace SAIP_MED.TEST.Test
{
    [TestClass]
    public class MedicoTestRepository
    {
        AppDbContext Context;
        MedicoRepository Repository;
        Medico Medico;

        [TestInitialize()]
        public void Initialize() {
            Context = new AppDbContext();
            Context.Database.EnsureCreated();
            Repository = new MedicoRepository();
            Medico = new Medico();
        }

        [TestCleanup()]
        public void Cleanup() {
            Context.Dispose();
        }

        [TestMethod]
        public async Task CreateMedicoTest()
        {
            Medico.Nombre = "Bismarck";
            Medico.Apellidos = "Franco Hoyos";
            Medico.IdDocumento = 1;
            Medico.NroDocumento = "5323182 SC";
            Medico.Telefono = "69101806";
            Medico.Direccion = "Villa 1ro de Mayo C/14 G";
            Medico.Email = "fbfranco@gmail.com";
            Medico.IdEspecialidad = 1;

            var Result = await Repository.Create(Medico);
            Assert.AreEqual("El Medico se guardó correctamente.",Result);
        } 

        [TestMethod]
        public async Task UpdateMedicoTest()
        {
            Medico.IdMedico = Context.Medico.OrderByDescending(x => x.IdMedico).First().IdMedico;
            Medico.Nombre = "Bismarck Modificado";
            
            var Result = await Repository.Update(Medico);
            Assert.AreEqual("El Medico se actualizó correctamente.", Result);
        }

        [TestMethod]
        public async Task DeleteMedicoTest()
        {
            Medico.IdMedico = Context.Medico.OrderByDescending(x => x.IdMedico).First().IdMedico;
            var Result = await Repository.Delete(Medico.IdMedico);
            Assert.AreEqual("El Medico se eliminó correctamente.", Result);
        }

        [TestMethod]
        public async Task GetMedicosTest() 
        { 
            var Result = await Repository.GetMedicos().ToAsyncEnumerable().Count();
            Assert.IsTrue(Result > 0);
        }
        
        [TestMethod]
        public async Task GetMedicoByIdTest() 
        { 
            Medico.IdMedico = Context.Medico.OrderByDescending(x => x.IdMedico).First().IdMedico;
            var Result = await Repository.GetMedicoById(Medico.IdMedico).ToAsyncEnumerable().Count();
            Assert.IsTrue(Result == 1);
        }
    }
}