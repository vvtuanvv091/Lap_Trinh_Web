using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaiKiemTra03_01.Data.Migrations
{
    /// <inheritdoc />
    public partial class bai2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhongBan",
                columns: table => new
                {
                    maphongban = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenphongban = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    soluongnhanvien = table.Column<int>(type: "int", nullable: false),
                    phongbanquanli = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhongBan", x => x.maphongban);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    manhanvien = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tennhanvien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    chucvu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phongbanid = table.Column<int>(type: "int", nullable: false),
                    ngaybatdaulamviec = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.manhanvien);
                    table.ForeignKey(
                        name: "FK_NhanVien_PhongBan_phongbanid",
                        column: x => x.phongbanid,
                        principalTable: "PhongBan",
                        principalColumn: "maphongban",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_phongbanid",
                table: "NhanVien",
                column: "phongbanid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "PhongBan");
        }
    }
}
