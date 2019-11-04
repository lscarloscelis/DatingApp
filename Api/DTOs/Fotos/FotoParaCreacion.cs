using System;
using Microsoft.AspNetCore.Http;

namespace Api.DTOs.Fotos
{
    public class FotoParaCreacion
    {
        public string Url { get; set; }
        public IFormFile File { get; set; } /* Only Receives This At First */
        public string Descripcion { get; set; }
        public string PublicId { get; set; }
        public DateTime Agregado { get; set; }
    }
}