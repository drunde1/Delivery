using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Delivery.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Filters",
                columns: table => new
                {
                    District = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    FirstDeliveryTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filters", x => new { x.District, x.FirstDeliveryTime });
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    WhereFrom = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Message = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Weight = table.Column<double>(type: "double precision", nullable: false),
                    District = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    DeliveryTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilterEntityOrderEntity",
                columns: table => new
                {
                    OrdersId = table.Column<Guid>(type: "uuid", nullable: false),
                    FiltersDistrict = table.Column<string>(type: "character varying(20)", nullable: false),
                    FiltersFirstDeliveryTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilterEntityOrderEntity", x => new { x.OrdersId, x.FiltersDistrict, x.FiltersFirstDeliveryTime });
                    table.ForeignKey(
                        name: "FK_FilterEntityOrderEntity_Filters_FiltersDistrict_FiltersFirs~",
                        columns: x => new { x.FiltersDistrict, x.FiltersFirstDeliveryTime },
                        principalTable: "Filters",
                        principalColumns: new[] { "District", "FirstDeliveryTime" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilterEntityOrderEntity_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilterEntityOrderEntity_FiltersDistrict_FiltersFirstDeliver~",
                table: "FilterEntityOrderEntity",
                columns: new[] { "FiltersDistrict", "FiltersFirstDeliveryTime" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilterEntityOrderEntity");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Filters");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
