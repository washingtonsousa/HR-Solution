using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Core.Data.Models
{
  public class Contato : Entity
    {

        public Contato() : base() { }

        [Key]
        public int Id { get; set; }

        public string Descricao { get; set; }

        [Required]
        public long Fixo { get; set; }

        [Required]
        public long Celular { get; set; }


        public string EmailContato { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [IgnoreDataMember]
        public Usuario Usuario { get; set; }






    }
}
