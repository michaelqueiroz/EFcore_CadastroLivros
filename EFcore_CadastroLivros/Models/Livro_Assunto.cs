using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFcore_CadastroLivros.Models
{
    public class Livro_Assunto
    {
        public Livro Livro { get; set; }
        public int LivroID { get; set; }

        public Assunto Assunto { get; set; }
        public int AssuntoID { get; set; }
    }
}
