using System;

namespace Api.DTOs.Auth
{
    public class Register
    {
        public string Document { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public string Genero { get; set; }
        public string ConocidoComo { get; set; }
        public DateTime Nacimiento { get; set; }
        public string Introduccion { get; set; }
        public string Buscando { get; set; }
        public string Intereses { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
    }
}
