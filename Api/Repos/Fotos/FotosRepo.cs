using System.Collections.Generic;
using System.Linq;
using Api.Data;
using Api.Models;

namespace Api.Repos.Fotos
{
    public class FotosRepo : IFotosRepo
    {
        private readonly DatingAppDbContext datingAppDbContext;
        public FotosRepo(DatingAppDbContext datingAppDbContext)
        {
            this.datingAppDbContext = datingAppDbContext;
        }

        public void AddFoto(Foto foto)
        {
            datingAppDbContext.Fotos.Add(foto);
            datingAppDbContext.SaveChanges();
        }

        public IEnumerable<Foto> GetFotoByUser(Usuario usuario)
        {
            return datingAppDbContext.Fotos.Where(x => x.Usuario == usuario);
        }

        public Usuario GetUsuario(string document)
        {
            return datingAppDbContext.Usuarios.FirstOrDefault(x => x.Document == document);
        }
    }
}