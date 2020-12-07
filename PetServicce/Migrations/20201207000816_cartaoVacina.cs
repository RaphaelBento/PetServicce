using Microsoft.EntityFrameworkCore.Migrations;

namespace PetServicce.Migrations
{
    public partial class cartaoVacina : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cadastro",
                columns: table => new
                {
                    Cpf = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    NumeroContato = table.Column<string>(nullable: false),
                    Endereco = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cadastro", x => x.Cpf);
                });

            migrationBuilder.CreateTable(
                name: "CartaoDeVacinacaos",
                columns: table => new
                {
                    NomeDoPet = table.Column<string>(nullable: false),
                    Sexo = table.Column<string>(nullable: true),
                    Especie = table.Column<string>(nullable: true),
                    Raca = table.Column<string>(nullable: true),
                    Peso = table.Column<int>(nullable: false),
                    DataNascimento = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    Vacina = table.Column<string>(nullable: true),
                    DataVacina = table.Column<string>(nullable: true),
                    MdeicoVeterinário = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartaoDeVacinacaos", x => x.NomeDoPet);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cadastro");

            migrationBuilder.DropTable(
                name: "CartaoDeVacinacaos");
        }
    }
}
