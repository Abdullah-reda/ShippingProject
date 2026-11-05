using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class CreateVwCitiesView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
        CREATE VIEW VwCities AS
        SELECT
            c.Id,
            c.CityAname,
            c.CityEname,
            co.CountryAname,
            co.CountryEname,
            c.CountryId,
            c.UpdatedBy,
            c.CurrentState,
            c.CreatedDate,
            c.CreatedBy,
            c.UpdatedDate
        FROM TbCities c
        INNER JOIN TbCountries co ON c.CountryId = co.Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW VwCities");
        }
    }
}
