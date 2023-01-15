using Microsoft.EntityFrameworkCore.Migrations;

namespace granado_clinica_veterinaria_domain.Migrations
{
    public partial class RelacionamentoVeterinarioxAnimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VeterinarioAnimal",
                schema: "public",
                columns: table => new
                {
                    VeterinarioId = table.Column<long>(nullable: false),
                    AnimalId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VeterinarioAnimal", x => new { x.VeterinarioId, x.AnimalId });
                    table.ForeignKey(
                        name: "FK_VeterinarioAnimal_Animal_AnimalId",
                        column: x => x.AnimalId,
                        principalSchema: "public",
                        principalTable: "Animal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VeterinarioAnimal_Veterinario_VeterinarioId",
                        column: x => x.VeterinarioId,
                        principalSchema: "public",
                        principalTable: "Veterinario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VeterinarioAnimal_AnimalId",
                schema: "public",
                table: "VeterinarioAnimal",
                column: "AnimalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VeterinarioAnimal",
                schema: "public");
        }
    }
}
