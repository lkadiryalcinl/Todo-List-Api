using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoList.DataAccess.Migrations
{
    public partial class IsFavpropisadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFav",
                table: "Todos",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFav",
                table: "Todos");
        }
    }
}
