using Microsoft.EntityFrameworkCore.Migrations;

namespace granado_clinica_veterinaria_domain.Migrations
{
    public partial class RelacionamentoAnimalxTipoAnimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TipoAnimalId",
                schema: "public",
                table: "Animal",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Animal_TipoAnimalId",
                schema: "public",
                table: "Animal",
                column: "TipoAnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_TipoAnimal_TipoAnimalId",
                schema: "public",
                table: "Animal",
                column: "TipoAnimalId",
                principalSchema: "public",
                principalTable: "TipoAnimal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animal_TipoAnimal_TipoAnimalId",
                schema: "public",
                table: "Animal");

            migrationBuilder.DropIndex(
                name: "IX_Animal_TipoAnimalId",
                schema: "public",
                table: "Animal");

            migrationBuilder.DropColumn(
                name: "TipoAnimalId",
                schema: "public",
                table: "Animal");
        }
    }
}
