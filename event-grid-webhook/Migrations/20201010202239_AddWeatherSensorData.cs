using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EventGridWebhook.Migrations
{
    public partial class AddWeatherSensorData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.RenameTable("Entries", "AirQualityEntries");
            
            migrationBuilder.CreateTable(
                name: "WeatherEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BarAbsolute = table.Column<decimal>(type: "numeric", nullable: true),
                    BarSeaLevel = table.Column<decimal>(type: "numeric", nullable: true),
                    BarTrend = table.Column<decimal>(type: "numeric", nullable: true),
                    DataStructureType = table.Column<decimal>(type: "numeric", nullable: false),
                    DewPoint = table.Column<decimal>(type: "numeric", nullable: true),
                    DewPointIn = table.Column<decimal>(type: "numeric", nullable: true),
                    HeatIndex = table.Column<decimal>(type: "numeric", nullable: true),
                    HeatIndexIn = table.Column<decimal>(type: "numeric", nullable: true),
                    Hum = table.Column<decimal>(type: "numeric", nullable: true),
                    HumIn = table.Column<decimal>(type: "numeric", nullable: true),
                    Lsid = table.Column<decimal>(type: "numeric", nullable: false),
                    RainfallDaily = table.Column<decimal>(type: "numeric", nullable: true),
                    RainfallLast15_Min = table.Column<decimal>(type: "numeric", nullable: true),
                    RainfallLast24_Hr = table.Column<decimal>(type: "numeric", nullable: true),
                    RainfallLast60_Min = table.Column<decimal>(type: "numeric", nullable: true),
                    RainfallMonthly = table.Column<decimal>(type: "numeric", nullable: true),
                    RainfallYear = table.Column<decimal>(type: "numeric", nullable: true),
                    RainRateHi = table.Column<decimal>(type: "numeric", nullable: true),
                    RainRateHiLast15_Min = table.Column<decimal>(type: "numeric", nullable: true),
                    RainRateLast = table.Column<decimal>(type: "numeric", nullable: true),
                    RainSize = table.Column<int>(type: "integer", nullable: true),
                    RainStorm = table.Column<decimal>(type: "numeric", nullable: true),
                    RainStormLast = table.Column<decimal>(type: "numeric", nullable: true),
                    RainStormLastEndAt = table.Column<decimal>(type: "numeric", nullable: true),
                    RainStormLastStartAt = table.Column<decimal>(type: "numeric", nullable: true),
                    RainStormStartAt = table.Column<decimal>(type: "numeric", nullable: true),
                    RxState = table.Column<decimal>(type: "numeric", nullable: true),
                    SolarRad = table.Column<decimal>(type: "numeric", nullable: true),
                    Temp = table.Column<decimal>(type: "numeric", nullable: true),
                    TempIn = table.Column<decimal>(type: "numeric", nullable: true),
                    ThswIndex = table.Column<decimal>(type: "numeric", nullable: true),
                    ThwIndex = table.Column<decimal>(type: "numeric", nullable: true),
                    TransBatteryFlag = table.Column<decimal>(type: "numeric", nullable: true),
                    Txid = table.Column<decimal>(type: "numeric", nullable: true),
                    UvIndex = table.Column<decimal>(type: "numeric", nullable: true),
                    WetBulb = table.Column<decimal>(type: "numeric", nullable: true),
                    WindChill = table.Column<decimal>(type: "numeric", nullable: true),
                    WindDirAtHiSpeedLast10_Min = table.Column<decimal>(type: "numeric", nullable: true),
                    WindDirAtHiSpeedLast2_Min = table.Column<decimal>(type: "numeric", nullable: true),
                    WindDirLast = table.Column<decimal>(type: "numeric", nullable: true),
                    WindDirScalarAvgLast10_Min = table.Column<decimal>(type: "numeric", nullable: true),
                    WindDirScalarAvgLast1_Min = table.Column<decimal>(type: "numeric", nullable: true),
                    WindDirScalarAvgLast2_Min = table.Column<decimal>(type: "numeric", nullable: true),
                    WindSpeedAvgLast10_Min = table.Column<decimal>(type: "numeric", nullable: true),
                    WindSpeedAvgLast1_Min = table.Column<decimal>(type: "numeric", nullable: true),
                    WindSpeedAvgLast2_Min = table.Column<decimal>(type: "numeric", nullable: true),
                    WindSpeedHiLast10_Min = table.Column<decimal>(type: "numeric", nullable: true),
                    WindSpeedHiLast2_Min = table.Column<decimal>(type: "numeric", nullable: true),
                    WindSpeedLast = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherEntries", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable("AirQualityEntries", "Entries");

            migrationBuilder.DropTable(
                name: "WeatherEntries");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_DeviceId",
                table: "Entries",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_SampleTime",
                table: "Entries",
                column: "SampleTime");
        }
    }
}
