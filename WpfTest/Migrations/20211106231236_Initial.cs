using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WpfTest.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    x1a = table.Column<string>(type: "text", nullable: true),
                    x1b = table.Column<string>(type: "text", nullable: true),
                    x1c = table.Column<string>(type: "text", nullable: true),
                    x1d = table.Column<string>(type: "text", nullable: true),
                    x2 = table.Column<string>(type: "text", nullable: true),
                    x3 = table.Column<string>(type: "text", nullable: true),
                    x4 = table.Column<string>(type: "text", nullable: true),
                    x5 = table.Column<string>(type: "text", nullable: true),
                    x6 = table.Column<string>(type: "text", nullable: true),
                    x7 = table.Column<string>(type: "text", nullable: true),
                    x8 = table.Column<string>(type: "text", nullable: true),
                    x9 = table.Column<string>(type: "text", nullable: true),
                    x10 = table.Column<string>(type: "text", nullable: true),
                    x11 = table.Column<string>(type: "text", nullable: true),
                    x12 = table.Column<string>(type: "text", nullable: true),
                    x13 = table.Column<string>(type: "text", nullable: true),
                    x14 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tables");
        }
    }
}
