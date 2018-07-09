using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SAIP_MED.CORE.Interfaces;
using SAIP_MED.CORE.Models;
using SAIP_MED.DATA.Config;

namespace SAIP_MED.DATA.Persistences 
{
    public class EspecialidadRepository: IEspecialidadRepository
    {
        AppDbContext Context;
        public async Task<string> Create(Especialidad especialidad)
        {
            using (Context = new AppDbContext())
            {
                try
                {
                    await Context.Especialidad.AddAsync(especialidad);
                    await Context.SaveChangesAsync();
                    return "La Especialidad se guardó correctamente.";
                }
                catch (Exception ex)
                {
                    return "Error: " + ex.ToString();
                }
            }
        }

        public async Task<string> Delete(int id)
        {
            var delete = await GetEspecialidadById(id);
            using (Context = new AppDbContext())
            {
                try
                {
                    delete.Estado = 0;
                    Context.Entry(delete).State = EntityState.Modified;
                    await Context.SaveChangesAsync();
                    return "La Especialidad se eliminó correctamente.";

                }
                catch (Exception ex)
                {
                    return "Error: " + ex.ToString();
                }
            }
        }

        public async Task<Especialidad> GetEspecialidadById(int id)
        {
            using (Context = new AppDbContext())
            {
                return await Context.Especialidad.Where(x => x.IdEspecialidad == id).FirstOrDefaultAsync();
            }
        }

        public async Task<IEnumerable<Especialidad>> GetEspecialidades()
        {
            using (Context = new AppDbContext())
            {
                return await Context.Especialidad.Where(x => x.Estado == 1).ToListAsync();
            }
        }

        public async Task<string> Update(Especialidad especialidad)
        {
            var update = await GetEspecialidadById(especialidad.IdEspecialidad);
            update.NombreEspecialidad = especialidad.NombreEspecialidad;

            using (Context = new AppDbContext())
            {
                try
                {
                    Context.Entry(update).State = EntityState.Modified;
                    await Context.SaveChangesAsync();
                    return "La Especialidad se actualizó correctamente.";

                }
                catch (Exception ex)
                {
                    return "Error: " + ex.ToString();
                }
            }
        }
    }
}