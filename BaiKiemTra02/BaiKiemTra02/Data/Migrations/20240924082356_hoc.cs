using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaiKiemTra02.Data.Migrations
{
    /// <inheritdoc />
    public partial class hoc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOut",
                table: "LopHoc",
                newName: "ngayratruong");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "LopHoc",
                newName: "ngaynhaptruong");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ngayratruong",
                table: "LopHoc",
                newName: "DateOut");

            migrationBuilder.RenameColumn(
                name: "ngaynhaptruong",
                table: "LopHoc",
                newName: "DateCreated");
        }
    }
}
