using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFcore_CadastroLivros.Models
{
    public class Assunto
    {   
        [Key]
        public int Id { get; set; }

        [StringLength(20)]
        public string Descricao { get; set; }
    }
}
