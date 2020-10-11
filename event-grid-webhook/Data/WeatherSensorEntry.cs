using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventGridWebhook.Data
{
    public class WeatherSensorEntry
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int Id { get; set; }
        public decimal? BarAbsolute { get; set; }
        public decimal? BarSeaLevel { get; set; }
        public decimal? BarTrend { get; set; }
        public decimal DataStructureType { get; set; }
        public decimal? DewPoint { get; set; }
        public decimal? DewPointIn { get; set; }
        public decimal? HeatIndex { get; set; }
        public decimal? HeatIndexIn { get; set; }
        public decimal? Hum { get; set; }
        public decimal? HumIn { get; set; }
        public decimal Lsid { get; set; }
        public decimal? RainfallDaily { get; set; }
        public decimal? RainfallLast15_Min { get; set; }
        public decimal? RainfallLast24_Hr { get; set; }
        public decimal? RainfallLast60_Min { get; set; }
        public decimal? RainfallMonthly { get; set; }
        public decimal? RainfallYear { get; set; }
        public decimal? RainRateHi { get; set; }
        public decimal? RainRateHiLast15_Min { get; set; }
        public decimal? RainRateLast { get; set; }
        public int? RainSize { get; set; }
        public decimal? RainStorm { get; set; }
        public decimal? RainStormLast { get; set; }
        public decimal? RainStormLastEndAt { get; set; }
        public decimal? RainStormLastStartAt { get; set; }
        public decimal? RainStormStartAt { get; set; }
        public decimal? RxState { get; set; }
        public decimal? SolarRad { get; set; }
        public decimal? Temp { get; set; }
        public decimal? TempIn { get; set; }
        public decimal? ThswIndex { get; set; }
        public decimal? ThwIndex { get; set; }
        public decimal? TransBatteryFlag { get; set; }
        public decimal? Txid { get; set; }
        public decimal? UvIndex { get; set; }
        public decimal? WetBulb { get; set; }
        public decimal? WindChill { get; set; }
        public decimal? WindDirAtHiSpeedLast10_Min { get; set; }
        public decimal? WindDirAtHiSpeedLast2_Min { get; set; }
        public decimal? WindDirLast { get; set; }
        public decimal? WindDirScalarAvgLast10_Min { get; set; }
        public decimal? WindDirScalarAvgLast1_Min { get; set; }
        public decimal? WindDirScalarAvgLast2_Min { get; set; }
        public decimal? WindSpeedAvgLast10_Min { get; set; }
        public decimal? WindSpeedAvgLast1_Min { get; set; }
        public decimal? WindSpeedAvgLast2_Min { get; set; }
        public decimal? WindSpeedHiLast10_Min { get; set; }
        public decimal? WindSpeedHiLast2_Min { get; set; }
        public decimal? WindSpeedLast { get; set; }
        public DateTimeOffset SampleTime { get; set; }
        public string DeviceId { get; set; }
    }
}