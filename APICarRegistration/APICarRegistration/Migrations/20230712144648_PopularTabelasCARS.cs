using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICarRegistration.Migrations
{
    /// <inheritdoc />
    public partial class PopularTabelasCARS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Cars(Description, Price, RegisterDate, CategoryId, ModelId, ImageUrl) " +
                                                    "Values('Carro bem consevado, pouco rodado', 45900.00, '2023-07-12', 1, 1, 'honda2008.jpg')");

            migrationBuilder.Sql("Insert into Cars(Description, Price, RegisterDate, CategoryId, ModelId, ImageUrl) " +
                                                    "Values('Carro de empresa, esta rodado', 70900.00, '2023-07-12', 1, 2, 'yaris2017.jpg')");

            migrationBuilder.Sql("Insert into Cars(Description, Price, RegisterDate, CategoryId, ModelId, ImageUrl) " +
                                                    "Values('Carro Zero', 90530.00, '2023-07-12', 1, 3, 'toro2023.jpg')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Cars");
        }
    }
}
