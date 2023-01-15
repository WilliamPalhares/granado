using Microsoft.EntityFrameworkCore.Migrations;

namespace granado_clinica_veterinaria_domain.Migrations
{
    public partial class RelacionamentoClienteAnimal_ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Animal_AnimalId",
                schema: "public",
                table: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_AnimalId",
                schema: "public",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "AnimalId",
                schema: "public",
                table: "Cliente");

            migrationBuilder.AddColumn<long>(
                name: "ClienteId",
                schema: "public",
                table: "Animal",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Animal_ClienteId",
                schema: "public",
                table: "Animal",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_Cliente_ClienteId",
                schema: "public",
                table: "Animal",
                column: "ClienteId",
                principalSchema: "public",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animal_Cliente_ClienteId",
                schema: "public",
                table: "Animal");

            migrationBuilder.DropIndex(
                name: "IX_Animal_ClienteId",
                schema: "public",
                table: "Animal");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                schema: "public",
                table: "Animal");

            migrationBuilder.AddColumn<long>(
                name: "AnimalId",
                schema: "public",
                table: "Cliente",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_AnimalId",
                schema: "public",
                table: "Cliente",
                column: "AnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Animal_AnimalId",
                schema: "public",
                table: "Cliente",
                column: "AnimalId",
                principalSchema: "public",
                principalTable: "Animal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
