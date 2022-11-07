using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountManagement.Infrustructure.EFCore.Migrations
{
    public partial class ignorenamefrompermission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "RolePermissions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "RolePermissions",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
