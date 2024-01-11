using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Posts.Challenge.Infrastructure.Migrations
{
    public partial class createdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_user",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    full_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_post",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_post", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_post_tb_user_user_id",
                        column: x => x.user_id,
                        principalTable: "tb_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tb_user",
                columns: new[] { "id", "active", "created_at", "email", "full_name", "password", "phone_number", "type", "updated_at" },
                values: new object[] { 1L, true, new DateTime(2024, 1, 10, 8, 57, 39, 614, DateTimeKind.Local).AddTicks(6066), "system@posts.com", "Administrator", "1234", "31 99999-9999", "System", null });

            migrationBuilder.InsertData(
                table: "tb_user",
                columns: new[] { "id", "active", "created_at", "email", "full_name", "password", "phone_number", "type", "updated_at" },
                values: new object[] { 2L, true, new DateTime(2024, 1, 10, 8, 57, 39, 614, DateTimeKind.Local).AddTicks(6077), "admin@posts.com", "Administrator", "1234", "31 99999-9999", "Administrator", null });

            migrationBuilder.CreateIndex(
                name: "IX_tb_post_user_id",
                table: "tb_post",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_post");

            migrationBuilder.DropTable(
                name: "tb_user");
        }
    }
}
