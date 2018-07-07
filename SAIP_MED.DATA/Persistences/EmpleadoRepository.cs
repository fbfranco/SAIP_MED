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
    public class EmpleadoRepository: IEmpleadoRepository
    {
        AppDbContext Context;
        public async Task<string> Create(Empleado empleado)
        {
            using (Context = new AppDbContext())
            {
                try
                {
                    await Context.Empleado.AddAsync(empleado);
                    await Context.SaveChangesAsync();
                    return "El Centro se guardó correctamente.";
                }
                catch (Exception ex)
                {
                    return "Error: " + ex.ToString();
                }
            }
        }

        public async Task<string> Delete(int id)
        {
            var delete = await GetEmpleadoById(id);
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

        public async Task<Empleado> GetEmpleadoById(int id)
        {
            using (Context = new AppDbContext())
            {
                return await Context.Empleado.Where(x => x.IdEmpleado == id).FirstOrDefaultAsync();
            }
        }

        public async Task<IEnumerable> GetEmpleados()
        {
            using (Context = new AppDbContext())
            {
                return await Context.Empleado.Where(x => x.Estado == 1).ToListAsync();
            }
        }

        public async Task<string> Update(Empleado empleado)
        {
            using (Context = new AppDbContext())
            {
                try
                {
                    Context.Entry(empleado).State = EntityState.Modified;
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