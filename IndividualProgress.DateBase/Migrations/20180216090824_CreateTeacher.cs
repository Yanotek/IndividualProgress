using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IndividualProgress.DateBase.Migrations
{
    public partial class CreateTeacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Part");

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Part",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Part_TeacherId",
                table: "Part",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Part_Teacher_TeacherId",
                table: "Part",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Part_Teacher_TeacherId",
                table: "Part");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_Part_TeacherId",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Part");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Part",
                maxLength: 100,
                nullable: true);
        }
    }
}
