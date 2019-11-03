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
    }
}
