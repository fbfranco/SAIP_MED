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
    public class MedicoRepository: IMedicoRepository
    {
        AppDbContext Context;
        public async Task<string> Create(Medico medico)
        {
            using (Context = new AppDbContext())
            {
                try
                {
                    await Context.Medico.AddAsync(medico);
                    await Context.SaveChangesAsync();
                    return "El Medico se guardó correctamente.";
                }
                catch (Exception ex)
                {
                    return "Error: " + ex.ToString();
                }
            }
        }

        public async Task<string> Delete(int id)
        {
            var delete = await GetMedicoById(id);
            using (Context = new AppDbContext())
            {
                try
                {
                    delete.Estado = 0;
                    Context.Entry(delete).State = EntityState.Modified;
                    await Context.SaveChangesAsync();
                    return "El Medico se eliminó correctamente.";

                }
                catch (Exception ex)
                {
                    return "Error: " + ex.ToString();
                }
            }
        }

        public async Task<Medico> GetMedicoById(int id)
        {
            using (Context = new AppDbContext())
            {
                return await Context.Medico.Where(x => x.IdMedico == id).FirstOrDefaultAsync();
            }
        }

        public async Task<IEnumerable> GetMedicos()
        {
            using (Context = new AppDbContext())
            {
                return await Context.Medico.Where(x => x.Estado == 1).ToListAsync();
            }
        }

        public async Task<string> Update(Medico medico)
        {
            using (Context = new AppDbContext())
            {
                try
                {
                    Context.Entry(medico).State = EntityState.Modified;
                    await Context.SaveChangesAsync();
                    return "El Medico se actualizó correctamente.";

                }
                catch (Exception ex)
                {
                    return "Error: " + ex.ToString();
                }
            }
        }
    }
}