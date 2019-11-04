using System.Collections.Generic;
using Api.Models;

namespace Api.Repos.Fotos
{
    public interface IFotosRepo
    {
        Usuario GetUsuario(string document);
        void AddFoto(Foto foto);
        IEnumerable<Foto> GetFotoByUser(Usuario usuario);
    }
}