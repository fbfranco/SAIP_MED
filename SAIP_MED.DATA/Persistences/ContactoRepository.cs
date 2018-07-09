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
    public class ContactoRepository: IContactoRepository
    {
        AppDbContext Context;
        public async Task<string> Create(Contacto contacto)
        {
            using (Context = new AppDbContext())
            {
                try
                {
                    await Context.Contacto.AddAsync(contacto);
                    await Context.SaveChangesAsync();
                    return "El Contacto se guardó correctamente.";
                }
                catch (Exception ex)
                {
                    return "Error: " + ex.ToString();
                }
            }
        }
        public async Task<string> Create(AppDbContext context,Contacto contacto)
        {
            try
            {
                contacto.IdContacto = -2;
                await context.Contacto.AddAsync(contacto);
                await context.SaveChangesAsync();
                return "El Contacto se guardó correctamente.";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.ToString();
            }
        }

        public async Task<string> Delete(int id)
        {
            var delete = await GetContactoById(id);
            using (Context = new AppDbContext())
            {
                try
                {
                    Context.Contacto.Remove(delete);
                    await Context.SaveChangesAsync();
                    return "El Contacto se eliminó correctamente.";

                }
                catch (Exception ex)
                {
                    return "Error: " + ex.ToString();
                }
            }
        }

        public async Task<Contacto> GetContactoById(int id)
        {
            using (Context = new AppDbContext())
            {
                return await Context.Contacto.Where(x => x.IdContacto == id).FirstOrDefaultAsync();
            }
        }

        public async Task<IEnumerable<Contacto>> GetContactos()
        {
            using (Context = new AppDbContext())
            {
                return await Context.Contacto.ToListAsync();
            }
        }

        public async Task<string> Update(Contacto contacto)
        {
            var update = await GetContactoById(contacto.IdContacto);
            update.Nombre = contacto.Nombre;
            update.Apellidos = contacto.Apellidos;
            update.Telefono = contacto.Telefono;
            update.Direccion = contacto.Direccion;
            update.Email = contacto.Email;
            update.IdDocumento = contacto.IdDocumento;
            update.NroDocumento = contacto.NroDocumento;
            update.Relacion = contacto.Relacion;
            
            using (Context = new AppDbContext())
            {
                try
                {
                    Context.Entry(update).State = EntityState.Modified;
                    await Context.SaveChangesAsync();
                    return "El Contacto se actualizó correctamente.";

                }
                catch (Exception ex)
                {
                    return "Error: " + ex.ToString();
                }
            }
        }
    }
}