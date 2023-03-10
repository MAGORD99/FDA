using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 

namespace FastDeliveryAPI.Migrations
{
    
    public partial class MyFirtsMigration : Migration
    {
        
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", maxLength: 100, nullable: false),
                    PhoneNumberCustomer = table.Column<string>(type: "text", maxLength: 9, nullable: false),
                    Email = table.Column<string>(type: "text", maxLength: 120, nullable: false),
                    Address = table.Column<string>(type: "text", maxLength: 120, nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Email", "Name", "PhoneNumberCustomer", "Status" },
                values: new object[,]
                {
                    { 1, "San miguel", "magdiel@univo.edu.sv", "Magdiel Alvarado", "1234-5678", true },
                    
                });
        }

        
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
