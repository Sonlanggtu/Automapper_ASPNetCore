using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FluentValidationASPNET.Migrations
{
    public partial class InitDatabase2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Url = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Alias = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true, defaultValue: new DateTime(2021, 2, 10, 1, 23, 1, 779, DateTimeKind.Local).AddTicks(8025)),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdateBy = table.Column<string>(nullable: true),
                    IdCustomer = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Customers_IdCustomer",
                        column: x => x.IdCustomer,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdCustomer",
                table: "Products",
                column: "IdCustomer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
