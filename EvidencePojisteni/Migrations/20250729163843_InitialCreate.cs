using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvidencePojisteni.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PojisteneOsoby",
                columns: table => new
                {
                    CisloPojistence = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Jmeno = table.Column<string>(type: "TEXT", nullable: false),
                    Prijmeni = table.Column<string>(type: "TEXT", nullable: false),
                    Telefon = table.Column<string>(type: "TEXT", nullable: false),
                    Vek = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PojisteneOsoby", x => x.CisloPojistence);
                });

            migrationBuilder.CreateTable(
                name: "Pojisteni",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Typ = table.Column<string>(type: "TEXT", nullable: false),
                    Predmet = table.Column<string>(type: "TEXT", nullable: false),
                    Castka = table.Column<decimal>(type: "TEXT", nullable: false),
                    PlatnostOd = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PlatnostDo = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CisloPojistence = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pojisteni", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pojisteni_PojisteneOsoby_CisloPojistence",
                        column: x => x.CisloPojistence,
                        principalTable: "PojisteneOsoby",
                        principalColumn: "CisloPojistence",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pojisteni_CisloPojistence",
                table: "Pojisteni",
                column: "CisloPojistence");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pojisteni");

            migrationBuilder.DropTable(
                name: "PojisteneOsoby");
        }
    }
}
