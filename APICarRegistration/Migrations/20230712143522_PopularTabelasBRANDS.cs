using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICarRegistration.Migrations
{
    /// <inheritdoc />
    public partial class PopularTabelasBRANDS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Brands(Name) Values('Toyota')");
            migrationBuilder.Sql("Insert into Brands(Name) Values('Honda')");
            migrationBuilder.Sql("Insert into Brands(Name) Values('Fiat')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Brands");
        }
    }
}
