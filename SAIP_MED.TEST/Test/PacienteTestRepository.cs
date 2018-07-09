using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAIP_MED.CORE.Models;
using SAIP_MED.DATA.Config;
using SAIP_MED.DATA.Persistences;

namespace SAIP_MED.TEST.Test
{
    [TestClass]
    public class PacienteTestRepository
    {
        AppDbContext Context;
        PacienteRepository Repository;
        Paciente Paciente;
        Contacto Contacto;

        [TestInitialize()]
        public void Initialize() {
            Context = new AppDbContext();
            Context.Database.EnsureCreated();
            Repository = new PacienteRepository();
            Paciente = new Paciente();
            Contacto = new Contacto();
        }

        [TestCleanup()]
        public void Cleanup() {
            Context.Dispose();
        }

        [TestMethod]
        public async Task CreatePacienteTest()
        {
            var Contactos = new Collection<Contacto>();
            for (int i = 1; i <= 4; i++)
            {
                Contacto = new Contacto();
                Contacto.Nombre = "Nombre Contacto Nro. " + i;
                Contacto.Apellidos = "Apellido Contacto Nro. " + i;
                Contacto.IdDocumento = 1;
                Contacto.NroDocumento = "5323182 SC";
                Contacto.Telefono = "69101806";
                Contacto.Direccion = "Villa 1ro de Mayo C/14 G";
                Contacto.Email = "fbfranco@gmail.com";
                Contacto.Relacion = "Hermano";

                Contactos.Add(Contacto);
            }

            Paciente.Nombre = "Bismarck";
            Paciente.Apellidos = "Franco Hoyos";
            Paciente.IdDocumento = 1;
            Paciente.NroDocumento = "5323182 SC";
            Paciente.Telefono = "69101806";
            Paciente.Direccion = "Villa 1ro de Mayo C/14 G";
            Paciente.Email = "fbfranco@gmail.com";
            Paciente.Sexo = "Masculino";
            Paciente.FechaNacimiento = new DateTime(1991,08,19);
            Paciente.IdSeguro = 1;
            Paciente.Contactos = Contactos;

            var Result = await Repository.Create(Paciente);
            Assert.AreEqual("El Paciente se guardó correctamente.",Result);
        } 

        [TestMethod]
        public async Task UpdatePacienteTest()
        {
            Paciente.IdPaciente = Context.Paciente.OrderByDescending(x => x.IdPaciente).First().IdPaciente;
            Paciente.Nombre = "Bismarck Modificado";
            Paciente.IdDocumento = 1;
            Paciente.NroDocumento = "5323182 SC";
            Paciente.Sexo = "Masculino";
            Paciente.FechaNacimiento = new DateTime(1991, 08, 19);
            Paciente.IdSeguro = 1;

            var Result = await Repository.Update(Paciente);
            Assert.AreEqual("El Paciente se actualizó correctamente.", Result);
        }

        [TestMethod]
        public async Task DeletePacienteTest()
        {
            Paciente.IdPaciente = Context.Paciente.OrderByDescending(x => x.IdPaciente).First().IdPaciente;
            var Result = await Repository.Delete(Paciente.IdPaciente);
            Assert.AreEqual("El Paciente se eliminó correctamente.", Result);
        }

        [TestMethod]
        public void GetPacientesTest() 
        { 
            var Result = Repository.GetPacientes().Result.Count();
            Assert.IsTrue(Result > 0);
        }
        
        [TestMethod]
        public async Task GetPacienteByIdTest() 
        { 
            Paciente.IdPaciente = Context.Paciente.OrderByDescending(x => x.IdPaciente).First().IdPaciente;
            var Result = await Repository.GetPacienteById(Paciente.IdPaciente).ToAsyncEnumerable().Count();
            Assert.IsTrue(Result == 1);
        }
    }
}