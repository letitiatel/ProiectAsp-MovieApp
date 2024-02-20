using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiectasp.Migrations
{
    /// <inheritdoc />
    public partial class _3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProducerDetailss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Known_for = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Born = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Spouse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProducerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProducerDetailss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProducerDetailss_Producers_ProducerId",
                        column: x => x.ProducerId,
                        principalTable: "Producers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProducerDetailss_ProducerId",
                table: "ProducerDetailss",
                column: "ProducerId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProducerDetailss");
        }
    }
}
