using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAIP_MED.CORE.Models;
using SAIP_MED.DATA.Config;
using SAIP_MED.DATA.Persistences;

namespace SAIP_MED.TEST.Test
{
    [TestClass]
    public class EmpleadoTestRepository
    {
        AppDbContext Context;
        EmpleadoRepository Repository;
        Empleado Empleado;

        [TestInitialize()]
        public void Initialize() {
            Context = new AppDbContext();
            Context.Database.EnsureCreated();
            Repository = new EmpleadoRepository();
            Empleado = new Empleado();
        }

        [TestCleanup()]
        public void Cleanup() {
            Context.Dispose();
        }

        [TestMethod]
        public async Task CreateEmpleadoTest()
        {
            Empleado.Nombre = "Bismarck";
            Empleado.Apellidos = "Franco Hoyos";
            Empleado.IdDocumento = 1;
            Empleado.NroDocumento = "5323182 SC";
            Empleado.Telefono = "69101806";
            Empleado.Direccion = "Villa 1ro de Mayo C/14 G";
            Empleado.Email = "fbfranco@gmail.com";
            Empleado.Cargo = "Developer";

            var Result = await Repository.Create(Empleado);
            Assert.AreEqual("El Empleado se guardó correctamente.",Result);
        } 

        [TestMethod]
        public async Task UpdateEmpleadoTest()
        {
            Empleado.IdEmpleado = Context.Empleado.OrderByDescending(x => x.IdEmpleado).First().IdEmpleado;
            Empleado.Nombre = "Bismarck Modificado";
            
            var Result = await Repository.Update(Empleado);
            Assert.AreEqual("El Empleado se actualizó correctamente.", Result);
        }

        [TestMethod]
        public async Task DeleteEmpleadoTest()
        {
            Empleado.IdEmpleado = Context.Empleado.OrderByDescending(x => x.IdEmpleado).First().IdEmpleado;
            var Result = await Repository.Delete(Empleado.IdEmpleado);
            Assert.AreEqual("El Empleado se eliminó correctamente.", Result);
        }

        [TestMethod]
        public async Task GetEmpleadosTest() 
        { 
            var Result = await Repository.GetEmpleados().ToAsyncEnumerable().Count();
            Assert.IsTrue(Result > 0);
        }
        
        [TestMethod]
        public async Task GetEmpleadoByIdTest() 
        { 
            Empleado.IdEmpleado = Context.Empleado.OrderByDescending(x => x.IdEmpleado).First().IdEmpleado;
            var Result = await Repository.GetEmpleadoById(Empleado.IdEmpleado).ToAsyncEnumerable().Count();
            Assert.IsTrue(Result == 1);
        }
    }
}