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
    public class SeguroRepository: ISeguroRepository
    {
        AppDbContext Context;
        public async Task<string> Create(Seguro seguro)
        {
            using (Context = new AppDbContext())
            {
                try
                {
                    await Context.Seguro.AddAsync(seguro);
                    await Context.SaveChangesAsync();
                    return "El Seguro se guardó correctamente.";
                }
                catch (Exception ex)
                {
                    return "Error: " + ex.ToString();
                }
            }
        }

        public async Task<string> Delete(int id)
        {
            var delete = await GetSeguroById(id);
            using (Context = new AppDbContext())
            {
                try
                {
                    delete.Estado = 0;
                    Context.Entry(delete).State = EntityState.Modified;
                    await Context.SaveChangesAsync();
                    return "El Seguro se eliminó correctamente.";

                }
                catch (Exception ex)
                {
                    return "Error: " + ex.ToString();
                }
            }
        }

        public async Task<Seguro> GetSeguroById(int id)
        {
            using (Context = new AppDbContext())
            {
                return await Context.Seguro.Where(x => x.IdSeguro == id).FirstOrDefaultAsync();
            }
        }

        public async Task<IEnumerable> GetSeguros()
        {
            using (Context = new AppDbContext())
            {
                return await Context.Seguro.Where(x => x.Estado == 1).ToListAsync();
            }
        }

        public async Task<string> Update(Seguro seguro)
        {
            using (Context = new AppDbContext())
            {
                try
                {
                    Context.Entry(seguro).State = EntityState.Modified;
                    await Context.SaveChangesAsync();
                    return "El Seguro se actualizó correctamente.";

                }
                catch (Exception ex)
                {
                    return "Error: " + ex.ToString();
                }
            }
        }
    }
}