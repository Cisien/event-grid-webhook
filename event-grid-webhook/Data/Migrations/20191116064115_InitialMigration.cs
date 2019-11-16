using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EventGridWebhook.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None),
                    DeviceId = table.Column<string>(nullable: true),
                    SampleTime = table.Column<DateTimeOffset>(nullable: false),
                    Uptime = table.Column<long>(nullable: false),
                    WifiSignalStrength = table.Column<long>(nullable: false),
                    Temperature_F = table.Column<long>(nullable: false),
                    Humidity = table.Column<long>(nullable: false),
                    DewPoint_F = table.Column<long>(nullable: false),
                    Pressure_mB = table.Column<decimal>(nullable: false),
                    PM2_5IndexColor_A = table.Column<string>(nullable: true),
                    PM2_5IndexColor_B = table.Column<string>(nullable: true),
                    PM2_5Index_A = table.Column<long>(nullable: false),
                    PM2_5Index_B = table.Column<long>(nullable: false),
                    PM1_0_ug_A = table.Column<decimal>(nullable: false),
                    PM1_0_ug_B = table.Column<decimal>(nullable: false),
                    PM2_5_ug_A = table.Column<decimal>(nullable: false),
                    PM2_5_ug_B = table.Column<decimal>(nullable: false),
                    PM10_0_ug_A = table.Column<decimal>(nullable: false),
                    PM10_0_ug_B = table.Column<decimal>(nullable: false),
                    P0_3_um_A = table.Column<decimal>(nullable: false),
                    P0_3_um_B = table.Column<decimal>(nullable: false),
                    P0_5_um_A = table.Column<decimal>(nullable: false),
                    P0_5_um_B = table.Column<decimal>(nullable: false),
                    P1_0_um_A = table.Column<decimal>(nullable: false),
                    P1_0_um_B = table.Column<decimal>(nullable: false),
                    P2_5_um_A = table.Column<decimal>(nullable: false),
                    P2_5_um_B = table.Column<decimal>(nullable: false),
                    P5_0_um_A = table.Column<decimal>(nullable: false),
                    P5_0_um_B = table.Column<decimal>(nullable: false),
                    P10_0_um_A = table.Column<decimal>(nullable: false),
                    P10_0_um_B = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entries_DeviceId",
                table: "Entries",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_SampleTime",
                table: "Entries",
                column: "SampleTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entries");
        }
    }
}
