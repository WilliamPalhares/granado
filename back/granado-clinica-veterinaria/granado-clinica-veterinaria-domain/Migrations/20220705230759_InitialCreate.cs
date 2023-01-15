using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace granado_clinica_veterinaria_domain.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "Agendamento",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DataConsulta = table.Column<DateTime>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Animal",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(nullable: false),
                    Idade = table.Column<int>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Atendimento",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Diagnostico = table.Column<string>(nullable: false),
                    DataAtendimento = table.Column<DateTime>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(nullable: false),
                    CPF = table.Column<string>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoAnimal",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoAnimal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Veterinario",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(nullable: false),
                    Geriatra = table.Column<bool>(nullable: false),
                    DataContratacao = table.Column<DateTime>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veterinario", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animal_Nome",
                schema: "public",
                table: "Animal",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_CPF",
                schema: "public",
                table: "Cliente",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Nome",
                schema: "public",
                table: "Cliente",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Veterinario_Nome",
                schema: "public",
                table: "Veterinario",
                column: "Nome",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamento",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Animal",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Atendimento",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Cliente",
                schema: "public");

            migrationBuilder.DropTable(
                name: "TipoAnimal",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Veterinario",
                schema: "public");
        }
    }
}
