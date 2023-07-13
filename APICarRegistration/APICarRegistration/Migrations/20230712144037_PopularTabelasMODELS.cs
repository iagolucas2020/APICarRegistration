using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICarRegistration.Migrations
{
    /// <inheritdoc />
    public partial class PopularTabelasMODELS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Models(Name, BrandId) Values('Civic', 1)");
            migrationBuilder.Sql("Insert into Models(Name, BrandId) Values('Yaris', 2)");
            migrationBuilder.Sql("Insert into Models(Name, BrandId) Values('Toro', 3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Models");
        }
    }
}
