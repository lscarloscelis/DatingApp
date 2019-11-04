using System;

namespace Api.Models
{
    public class Foto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Descripcion { get; set; }
        public DateTime Agregada { get; set; }
        public bool EsPerfil { get; set; }
        public Usuario Usuario { get; set; }
    }
}