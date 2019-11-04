using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Usuario
    {
        [Key]
        public string Document { get; set; }
        public string Username { get; set; }
        public byte[] Hash { get; set; }
        public byte[] Salt { get; set; }
        public string Genero { get; set; }
        public string ConocidoComo { get; set; }
        public DateTime Creado { get; set; }
        public DateTime UltimaActividad { get; set; }
        public DateTime Nacimiento { get; set; }
        public string Introduccion { get; set; }
        public string Buscando { get; set; }
        public string Intereses { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public ICollection<Foto> Fotos { get; set; } /* No Debe Aparecer En La Tabla */
    }
}

