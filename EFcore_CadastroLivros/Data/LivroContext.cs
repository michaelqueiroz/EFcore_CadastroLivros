using EFcore_CadastroLivros.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;

namespace EFcore_CadastroLivros.Data
{
    public class LivroContext : DbContext
    {
        public DbSet<Livro> Livro { get; set; }
        public DbSet<Livro_Autor> Livro_Autor { get; set; }
        public DbSet<Autor> Autor { get; set; }
        public DbSet<Livro_Assunto> Livro_Assunto { get; set; }
        public DbSet<Assunto> Assunto { get; set; }


        public LivroContext(DbContextOptions<LivroContext> Opcoes) : base (Opcoes)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder.UseSqlServer("");
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=DbLivros;Trusted_Connection=True;");
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=DbLivros;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Livro_Assunto>(entity =>
            {
                entity.HasKey(e => new { e.AssuntoID, e.LivroID });
            });

            modelBuilder.Entity<Livro_Autor>(entity =>
            {
                entity.HasKey(e => new { e.AutorID, e.LivroID });
            });
        }
    }
}
