using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFcore_CadastroLivros.Models
{
    public class Autor
    {
        public int Id { get; set; }
        
        [StringLength(40)]
        public string Nome { get; set; }
    }
}
