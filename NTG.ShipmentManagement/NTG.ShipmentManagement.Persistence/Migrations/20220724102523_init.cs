using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NTG.ShipmentManagement.Persistence.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Suburb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Postcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdetId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestedPickupTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PickupAddressId = table.Column<int>(type: "int", nullable: false),
                    DeliveryAddressId = table.Column<int>(type: "int", nullable: false),
                    PickupInstruction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryInstruction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShipmentOrder_Address_DeliveryAddressId",
                        column: x => x.DeliveryAddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ShipmentOrder_Address_PickupAddressId",
                        column: x => x.PickupAddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentOrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ShipmentOrderId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentOrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShipmentOrderItem_ShipmentOrder_ShipmentOrderId",
                        column: x => x.ShipmentOrderId,
                        principalTable: "ShipmentOrder",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentOrder_DeliveryAddressId",
                table: "ShipmentOrder",
                column: "DeliveryAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentOrder_PickupAddressId",
                table: "ShipmentOrder",
                column: "PickupAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentOrderItem_ShipmentOrderId",
                table: "ShipmentOrderItem",
                column: "ShipmentOrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShipmentOrderItem");

            migrationBuilder.DropTable(
                name: "ShipmentOrder");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
