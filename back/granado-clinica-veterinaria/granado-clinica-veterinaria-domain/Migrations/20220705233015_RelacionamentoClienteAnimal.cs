using Microsoft.EntityFrameworkCore.Migrations;

namespace granado_clinica_veterinaria_domain.Migrations
{
    public partial class RelacionamentoClienteAnimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AnimalId",
                schema: "public",
                table: "Cliente",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
