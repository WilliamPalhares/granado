using Microsoft.EntityFrameworkCore.Migrations;

namespace granado_clinica_veterinaria_domain.Migrations
{
    public partial class RelacionamentoAgendamentoxVeterinario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "VeterinarioId",
                schema: "public",
                table: "Agendamento",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_VeterinarioId",
                schema: "public",
                table: "Agendamento",
                column: "VeterinarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Veterinario_VeterinarioId",
                schema: "public",
                table: "Agendamento",
                column: "VeterinarioId",
                principalSchema: "public",
                principalTable: "Veterinario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Veterinario_VeterinarioId",
                schema: "public",
                table: "Agendamento");

            migrationBuilder.DropIndex(
                name: "IX_Agendamento_VeterinarioId",
                schema: "public",
                table: "Agendamento");

            migrationBuilder.DropColumn(
                name: "VeterinarioId",
                schema: "public",
                table: "Agendamento");
        }
    }
}
