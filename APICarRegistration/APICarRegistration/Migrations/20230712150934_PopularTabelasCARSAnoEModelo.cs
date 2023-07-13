using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICarRegistration.Migrations
{
    /// <inheritdoc />
    public partial class PopularTabelasCARSAnoEModelo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Cars(Description, Price, ModelYear, ManufactureYear, RegisterDate, CategoryId, ModelId, ImageUrl) " +
                                        "Values('Carro bem consevado, pouco rodado', 45900.00, '2008', '2007', '2023-07-12', 1, 1, 'honda2008.jpg')");

            migrationBuilder.Sql("Insert into Cars(Description, Price, ModelYear, ManufactureYear, RegisterDate, CategoryId, ModelId, ImageUrl) " +
                                                    "Values('Carro de empresa, esta rodado', 70900.00, '2017', '2016',  '2023-07-12', 1, 2, 'yaris2017.jpg')");

            migrationBuilder.Sql("Insert into Cars(Description, Price, ModelYear, ManufactureYear, RegisterDate, CategoryId, ModelId, ImageUrl) " +
                                                    "Values('Carro Zero', 90530.00, '2023', '2023',  '2023-07-12', 1, 3, 'toro2023.jpg')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Cars");
        }
    }
}
