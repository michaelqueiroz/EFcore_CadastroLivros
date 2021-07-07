using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFcore_CadastroLivros.Models
{
    public class Livro
    {
        public int Id { get; set; }
        [StringLength(40)]
        public string Titulo { get; set; }

        [StringLength(40)]
        public string Editora { get; set; }
        public int Edicao { get; set; }

        [StringLength(40)]
        public string AnoPublicacao{ get; set; }


    }
}
