using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SAIP_MED.CORE.Interfaces;
using SAIP_MED.CORE.Models;
using SAIP_MED.DATA.Config;

namespace SAIP_MED.DATA.Persistences
{
    public class PacienteRepository: IPacienteRepository
    {
        AppDbContext Context;
        ContactoRepository Contacto;
        public async Task<string> Create(Paciente paciente)
        {
            using (Context = new AppDbContext())
            {
                var Trans = Context.Database.BeginTransactionAsync();
                Contacto = new ContactoRepository();
                try
                {
                    await Context.Paciente.AddAsync(paciente);
                    await Context.SaveChangesAsync();
                    var LastIdPaciente = Context.Paciente.OrderByDescending(x => x.IdPaciente).First().IdPaciente;
                    foreach (var contacto in paciente.Contactos)
                    {
                        contacto.IdPaciente = LastIdPaciente;
                        await Contacto.Create(Context,contacto);
                    }
                    Trans.Result.Commit();
                    Trans.Dispose();
                    return "El Paciente se guardó correctamente.";
                }
                catch (Exception ex)
                {
                    Trans.Result.Rollback();
                    Trans.Dispose();
                    return "Error: " + ex.ToString();
                }
            }
        }

        public async Task<string> Delete(int id)
        {
            var delete = await GetPacienteById(id);
            using (Context = new AppDbContext())
            {
                try
                {
                    delete.Estado = 0;
                    Context.Entry(delete).State = EntityState.Modified;
                    await Context.SaveChangesAsync();
                    return "El Paciente se eliminó correctamente.";

                }
                catch (Exception ex)
                {
                    return "Error: " + ex.ToString();
                }
            }
        }

        public async Task<Paciente> GetPacienteById(int id)
        {
            using (Context = new AppDbContext())
            {
                return await Context.Paciente.Where(x => x.IdPaciente == id).FirstOrDefaultAsync();
            }
        }

        public async Task<IEnumerable> GetPacientes()
        {
            using (Context = new AppDbContext())
            {
                return await Context.Paciente.Include("Contactos").Include("Seguro").Where(x => x.Estado == 1).ToListAsync();
            }
        }

        public async Task<string> Update(Paciente paciente)
        {
            using (Context = new AppDbContext())
            {
                try
                {
                    Context.Entry(paciente).State = EntityState.Modified;
                    await Context.SaveChangesAsync();
                    return "El Paciente se actualizó correctamente.";

                }
                catch (Exception ex)
                {
                    return "Error: " + ex.ToString();
                }
            }
        }
    }
}