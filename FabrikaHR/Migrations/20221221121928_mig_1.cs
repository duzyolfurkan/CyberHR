using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FabrikaHR.Migrations
{
    public partial class mig_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciTipi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonelAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonelSoyadi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DogumTarihi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DogumYeri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IseGirisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fotograf = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    MailAdresi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonNumarasi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Departman = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CalismaStatusu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Avanses",
                columns: table => new
                {
                    AvansID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TalepTuru = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TalepTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParaBirimi = table.Column<int>(type: "int", nullable: false),
                    TalepTutari = table.Column<double>(type: "float", nullable: false),
                    OnayDurumu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CevaplanmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avanses", x => x.AvansID);
                    table.ForeignKey(
                        name: "FK_Avanses_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Harcamas",
                columns: table => new
                {
                    HarcamaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HarcamaTuru = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TalepTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParaBirimi = table.Column<int>(type: "int", nullable: false),
                    HarcamaTutari = table.Column<double>(type: "float", nullable: false),
                    OnayDurumu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CevaplanmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EkDosya = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Harcamas", x => x.HarcamaID);
                    table.ForeignKey(
                        name: "FK_Harcamas_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Avanses_UserID",
                table: "Avanses",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Harcamas_UserID",
                table: "Harcamas",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avanses");

            migrationBuilder.DropTable(
                name: "Harcamas");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
