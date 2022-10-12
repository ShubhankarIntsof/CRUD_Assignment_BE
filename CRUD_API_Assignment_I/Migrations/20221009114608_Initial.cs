using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUD_API_Assignment_I.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons_Shuba",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    First_Name = table.Column<string>(maxLength: 50, nullable: false),
                    Last_Name = table.Column<string>(maxLength: 50, nullable: false),
                    Address = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons_Shuba", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons_Shuba");
        }
    }
}
