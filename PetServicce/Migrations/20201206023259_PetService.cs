using Microsoft.EntityFrameworkCore.Migrations;

namespace PetServicce.Migrations
{
    public partial class PetService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cadastro",
                columns: table => new
                {
                    Cpf = table.Column<string>(nullable: false),
                    NomeDoDono = table.Column<string>(nullable: true),
                    NumeroContato = table.Column<string>(nullable: false),
                    Endereco = table.Column<string>(nullable: true),
                    NomeDoPet = table.Column<string>(nullable: false),
                    Especie = table.Column<string>(nullable: true),
                    Raca = table.Column<string>(nullable: true),
                    Peso = table.Column<int>(nullable: false),
                    ApelidoDoPet = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cadastro", x => x.Cpf);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cadastro");
        }
    }
}
