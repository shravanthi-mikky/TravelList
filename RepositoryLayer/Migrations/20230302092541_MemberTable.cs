using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace RepositoryLayer.Migrations
{
    public partial class MemberTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MemberTable",
                columns: table => new
                {
                    MemberId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(nullable: true),
                    Residence = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Place = table.Column<string>(nullable: true),
                    Age = table.Column<string>(nullable: true),
                    ListId = table.Column<long>(nullable: false),
                    ListTableListId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberTable", x => x.MemberId);
                    table.ForeignKey(
                        name: "FK_MemberTable_ListTable_ListTableListId",
                        column: x => x.ListTableListId,
                        principalTable: "ListTable",
                        principalColumn: "ListId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MemberTable_ListTableListId",
                table: "MemberTable",
                column: "ListTableListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberTable");
        }
    }
}
