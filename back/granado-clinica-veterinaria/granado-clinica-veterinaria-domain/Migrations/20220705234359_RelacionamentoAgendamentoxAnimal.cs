using Microsoft.EntityFrameworkCore.Migrations;

namespace granado_clinica_veterinaria_domain.Migrations
{
    public partial class RelacionamentoAgendamentoxAnimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AnimalId",
                schema: "public",
                table: "Agendamento",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_AnimalId",
                schema: "public",
                table: "Agendamento",
                column: "AnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Animal_AnimalId",
                schema: "public",
                table: "Agendamento",
                column: "AnimalId",
                principalSchema: "public",
                principalTable: "Animal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Animal_AnimalId",
                schema: "public",
                table: "Agendamento");

            migrationBuilder.DropIndex(
                name: "IX_Agendamento_AnimalId",
                schema: "public",
                table: "Agendamento");

            migrationBuilder.DropColumn(
                name: "AnimalId",
                schema: "public",
                table: "Agendamento");
        }
    }
}
