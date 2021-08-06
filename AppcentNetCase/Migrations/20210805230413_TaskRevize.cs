using Microsoft.EntityFrameworkCore.Migrations;

namespace AppcentNetCase.Migrations
{
    public partial class TaskRevize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProjectTitle",
                table: "Tasks",
                newName: "TaskTitle");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TaskTitle",
                table: "Tasks",
                newName: "ProjectTitle");
        }
    }
}
