using Microsoft.EntityFrameworkCore.Migrations;

namespace ravi.learn.docker.web.Migrations
{
    public partial class initSqlLite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Magazine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Magazine", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Magazine",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "MSDN Magazine" });

            migrationBuilder.InsertData(
                table: "Magazine",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Docker Magazine" });

            migrationBuilder.InsertData(
                table: "Magazine",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "EF Core Magazine" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Magazine");
        }
    }
}
