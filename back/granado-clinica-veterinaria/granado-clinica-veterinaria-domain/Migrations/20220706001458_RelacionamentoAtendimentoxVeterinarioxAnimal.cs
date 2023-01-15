using Microsoft.EntityFrameworkCore.Migrations;

namespace granado_clinica_veterinaria_domain.Migrations
{
    public partial class RelacionamentoAtendimentoxVeterinarioxAnimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AnimalId",
                schema: "public",
                table: "Atendimento",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "VeterinarioId",
                schema: "public",
                table: "Atendimento",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_AnimalId",
                schema: "public",
                table: "Atendimento",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_VeterinarioId",
                schema: "public",
                table: "Atendimento",
                column: "VeterinarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimento_Animal_AnimalId",
                schema: "public",
                table: "Atendimento",
                column: "AnimalId",
                principalSchema: "public",
                principalTable: "Animal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimento_Veterinario_VeterinarioId",
                schema: "public",
                table: "Atendimento",
                column: "VeterinarioId",
                principalSchema: "public",
                principalTable: "Veterinario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimento_Animal_AnimalId",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropForeignKey(
                name: "FK_Atendimento_Veterinario_VeterinarioId",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropIndex(
                name: "IX_Atendimento_AnimalId",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropIndex(
                name: "IX_Atendimento_VeterinarioId",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "AnimalId",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "VeterinarioId",
                schema: "public",
                table: "Atendimento");
        }
    }
}
