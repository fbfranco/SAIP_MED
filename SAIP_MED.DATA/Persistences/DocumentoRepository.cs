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
                    Context.Documento.Remove(delete);
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

        public async Task<IEnumerable> GetDocuments()
        {
            using (Context = new AppDbContext())
            {
                return await Context.Documento.Where(x => x.Estado == 1).ToListAsync();
            }
        }

        public async Task<string> Update(int id, Documento document)
        {
            var update = await GetDocumentById(id);
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