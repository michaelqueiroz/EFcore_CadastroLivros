using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFcore_CadastroLivros.Models
{
    public class Livro_Autor
    {
        public Livro Livro { get; set; }
        public int LivroID { get; set; }

        public Autor Autor { get; set; }
        public int AutorID { get; set; }        
    }
}
