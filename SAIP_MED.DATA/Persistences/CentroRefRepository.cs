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
    public class CentroRefRepository : ICentroRefRepository
    {
        AppDbContext Context;
        public async Task<string> Create(CentroRef centro)
        {
            using (Context = new AppDbContext())
            {
                try
                {
                    await Context.CentroRef.AddAsync(centro);
                    await Context.SaveChangesAsync();
                    return "El Centro se guardó correctamente.";
                }
                catch (Exception ex)
                {
                    return "Error:" + ex.ToString();
                }
            }
        }

        public async Task<string> Delete(int id)
        {
            var delete = await GetCentroById(id);
            using (Context = new AppDbContext())
            {
                try
                {
                    delete.Estado = 0;
                    Context.Entry(delete).State = EntityState.Modified;
                    await Context.SaveChangesAsync();
                    return "El Centro se eliminó correctamente.";
                }
                catch (Exception ex)
                {
                    return "Error: " + ex.ToString();
                }
            }
        }

        public async Task<CentroRef> GetCentroById(int id)
        {
            using (Context = new AppDbContext())
            {
                return await Context.CentroRef.Where(x => x.IdCentroRef == id).FirstOrDefaultAsync();
            }
        }

        public async Task<IEnumerable<CentroRef>> GetCentros()
        {
            using (Context = new AppDbContext())
            {
                return await Context.CentroRef.Where(x => x.Estado == 1).ToListAsync(); 
            }
        }

        public async Task<string> Update(CentroRef centro)
        {
            var update = await GetCentroById(centro.IdCentroRef);
            update.NombreCentro = centro.NombreCentro;
            update.Telefono = centro.Telefono;
            
            using (Context = new AppDbContext())
            {
                try
                {
                    Context.Entry(update).State = EntityState.Modified;
                    await Context.SaveChangesAsync();
                    return "El Centro se actualizó correctamente.";
                }
                catch (Exception ex)
                {
                    return "Error: " + ex.ToString();

                }
            }
        }
    }
}