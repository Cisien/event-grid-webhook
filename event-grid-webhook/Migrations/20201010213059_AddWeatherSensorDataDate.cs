using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventGridWebhook.Migrations
{
    public partial class AddWeatherSensorDataDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeviceId",
                table: "WeatherEntries",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "SampleTime",
                table: "WeatherEntries",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_WeatherEntries_DeviceId",
                table: "WeatherEntries",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherEntries_SampleTime",
                table: "WeatherEntries",
                column: "SampleTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WeatherEntries_DeviceId",
                table: "WeatherEntries");

            migrationBuilder.DropIndex(
                name: "IX_WeatherEntries_SampleTime",
                table: "WeatherEntries");

            migrationBuilder.DropColumn(
                name: "DeviceId",
                table: "WeatherEntries");

            migrationBuilder.DropColumn(
                name: "SampleTime",
                table: "WeatherEntries");
        }
    }
}
