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
    public class DocumentoRepository : IDocumentoRepository
    {
        AppDbContext Context;
        public async Task<string> Create(Documento document)
        {
            using (Context = new AppDbContext())
            {
                try
                {
                    await Context.Documento.AddAsync(document);
                    await Context.SaveChangesAsync();
                    return "El Documento se guardó correctamente.";
                }
                catch (Exception ex)
                {
                    return "Error: " + ex.ToString();
                }
            }
        }

        public async Task<string> Delete(int id)
        {
            var delete = await GetDocumentById(id);
            using (Context = new AppDbContext())
            {
                try
                {
                    delete.Estado = 0;
                    Context.Entry(delete).State = EntityState.Modified;
                    await Context.SaveChangesAsync();
                    return "El Documento se eliminó correctamente.";

                }
                catch (Exception ex)
                {
                    return "Error: " + ex.ToString();
                }
            }
        }

        public async Task<Documento> GetDocumentById(int id)
        {
            using (Context = new AppDbContext())
            {
                return await Context.Documento.Where(x => x.IdDocumento == id).FirstOrDefaultAsync();
            }
        }

        public async Task<IEnumerable<Documento>> GetDocuments()
        {
            using (Context = new AppDbContext())
            {
                return await Context.Documento.Where(x => x.Estado == 1).ToListAsync();
            }
        }

        public async Task<string> Update(Documento document)
        {
            var update = await GetDocumentById(document.IdDocumento);
            update.NombreDocumento = document.NombreDocumento;

            using (Context = new AppDbContext())
            {
                try
                {
                    Context.Entry(update).State = EntityState.Modified;
                    await Context.SaveChangesAsync();
                    return "El Documento se actualizó correctamente.";

                }
                catch (Exception ex)
                {
                    return "Error: " + ex.ToString();
                }
            }
        }
    }
}