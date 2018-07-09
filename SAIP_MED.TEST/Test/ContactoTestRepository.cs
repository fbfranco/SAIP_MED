using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAIP_MED.CORE.Models;
using SAIP_MED.DATA.Config;
using SAIP_MED.DATA.Persistences;

namespace SAIP_MED.TEST.Test
{
    [TestClass]
    public class ContactoTestRepository
    {
        AppDbContext Context;
        ContactoRepository Repository;
        Contacto Contacto;

        [TestInitialize()]
        public void Initialize() {
            Context = new AppDbContext();
            Context.Database.EnsureCreated();
            Repository = new ContactoRepository();
            Contacto = new Contacto();
        }

        [TestCleanup()]
        public void Cleanup() {
            Context.Dispose();
        }

        [TestMethod]
        public async Task CreateContactoTest()
        {
            Contacto.Nombre = "Bismarck";
            Contacto.Apellidos = "Franco Hoyos";
            Contacto.IdDocumento = 1;
            Contacto.NroDocumento = "5323182 SC";
            Contacto.Telefono = "69101806";
            Contacto.Direccion = "Villa 1ro de Mayo C/14 G";
            Contacto.Email = "fbfranco@gmail.com";
            Contacto.IdPaciente = 1;
            Contacto.Relacion = "Hermano";

            var Result = await Repository.Create(Contacto);
            Assert.AreEqual("El Contacto se guardó correctamente.",Result);
        } 

        [TestMethod]
        public async Task UpdateContactoTest()
        {
            Contacto.IdContacto = Context.Contacto.OrderByDescending(x => x.IdContacto).First().IdContacto;
            Contacto.Nombre = "Bismarck Modificado";
            Contacto.IdDocumento = 1;
            Contacto.NroDocumento = "5323182 SC";
            Contacto.IdPaciente = 1;
            Contacto.Relacion = "Hermano";

            var Result = await Repository.Update(Contacto);
            Assert.AreEqual("El Contacto se actualizó correctamente.", Result);
        }

        [TestMethod]
        public async Task DeleteContactoTest()
        {
            Contacto.IdContacto = Context.Contacto.OrderByDescending(x => x.IdContacto).First().IdContacto;
            var Result = await Repository.Delete(Contacto.IdContacto);
            Assert.AreEqual("El Contacto se eliminó correctamente.", Result);
        }

        [TestMethod]
        public void GetContactosTest() 
        { 
            var Result = Repository.GetContactos().Result.Count();
            Assert.IsTrue(Result > 0);
        }
        
        [TestMethod]
        public async Task GetContactoByIdTest() 
        { 
            Contacto.IdContacto = Context.Contacto.OrderByDescending(x => x.IdContacto).First().IdContacto;
            var Result = await Repository.GetContactoById(Contacto.IdContacto).ToAsyncEnumerable().Count();
            Assert.IsTrue(Result == 1);
        }
    }
}