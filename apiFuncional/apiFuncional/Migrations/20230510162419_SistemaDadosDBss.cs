using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiFuncional.Migrations
{
    /// <inheritdoc />
    public partial class SistemaDadosDBss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Idade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContatoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contatos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoContato = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PessoaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contatos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contatos_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_PessoaId",
                table: "Contatos",
                column: "PessoaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contatos");

            migrationBuilder.DropTable(
                name: "Pessoas");
        }
    }
}
