using Microsoft.EntityFrameworkCore.Migrations;

namespace EFcore_CadastroLivros.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assunto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assunto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Livro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Editora = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Edicao = table.Column<int>(type: "int", nullable: false),
                    AnoPublicacao = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Livro_Assunto",
                columns: table => new
                {
                    LivroID = table.Column<int>(type: "int", nullable: false),
                    AssuntoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro_Assunto", x => new { x.AssuntoID, x.LivroID });
                    table.ForeignKey(
                        name: "FK_Livro_Assunto_Assunto_AssuntoID",
                        column: x => x.AssuntoID,
                        principalTable: "Assunto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Livro_Assunto_Livro_LivroID",
                        column: x => x.LivroID,
                        principalTable: "Livro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Livro_Autor",
                columns: table => new
                {
                    LivroID = table.Column<int>(type: "int", nullable: false),
                    AutorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro_Autor", x => new { x.AutorID, x.LivroID });
                    table.ForeignKey(
                        name: "FK_Livro_Autor_Autor_AutorID",
                        column: x => x.AutorID,
                        principalTable: "Autor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Livro_Autor_Livro_LivroID",
                        column: x => x.LivroID,
                        principalTable: "Livro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Livro_Assunto_LivroID",
                table: "Livro_Assunto",
                column: "LivroID");

            migrationBuilder.CreateIndex(
                name: "IX_Livro_Autor_LivroID",
                table: "Livro_Autor",
                column: "LivroID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livro_Assunto");

            migrationBuilder.DropTable(
                name: "Livro_Autor");

            migrationBuilder.DropTable(
                name: "Assunto");

            migrationBuilder.DropTable(
                name: "Autor");

            migrationBuilder.DropTable(
                name: "Livro");
        }
    }
}
