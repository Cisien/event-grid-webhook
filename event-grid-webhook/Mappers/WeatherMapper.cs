using EventGridWebhook.Data;
using Microsoft.Azure.EventGrid.Models;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherLinkClient;

namespace EventGridWebhook.Mappers
{
    public class WeatherMapper
    {
        private readonly ILogger<WeatherMapper> _logger;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public WeatherMapper(ILogger<WeatherMapper> logger, JsonSerializerOptions serializerOptions)
        {
            _logger = logger;
            _jsonSerializerOptions = serializerOptions;
        }

        public Task<WeatherSensorEntry> Map(IotHubDeviceTelemetryEventData iotData)
        {
            if (iotData.SystemProperties["iothub-connection-device-id"] != "001D0A7112D8")
            {
                return Task.FromResult<WeatherSensorEntry>(null);
            }

            var decoded = iotData.Body.ToString();

            var body = JsonSerializer.Deserialize<WeatherStationData>(decoded, _jsonSerializerOptions);

            _logger.LogInformation($"Weather Sensor Data Received: {body.Temp} from {iotData.SystemProperties["iothub-connection-device-id"]}");

            var entry = new WeatherSensorEntry
            {
                DeviceId = body.DeviceId,
                SampleTime = body.DateTime,
                BarAbsolute = body.BarAbsolute,
                BarSeaLevel = body.BarSeaLevel,
                BarTrend = body.BarTrend,
                DataStructureType = body.DataStructureType,
                DewPoint = body.DewPoint,
                DewPointIn = body.DewPointIn,
                HeatIndex = body.HeatIndex,
                HeatIndexIn = body.HeatIndexIn,
                Hum = body.Hum,
                HumIn = body.HumIn,
                Lsid = body.Lsid,
                RainfallDaily = body.RainfallDaily,
                RainfallLast15_Min = body.RainfallLast15_Min,
                RainfallLast24_Hr = body.RainfallLast24_Hr,
                RainfallLast60_Min = body.RainfallLast60_Min,
                RainfallMonthly = body.RainfallMonthly,
                RainfallYear = body.RainfallYear,
                RainRateHi = body.RainRateHi,
                RainRateHiLast15_Min = body.RainRateHiLast15_Min,
                RainRateLast = body.RainRateLast,
                RainSize = body.RainSize,
                RainStorm = body.RainStorm,
                RainStormLast = body.RainStormLast,
                RainStormLastEndAt = body.RainStormLastEndAt,
                RainStormLastStartAt = body.RainStormLastStartAt,
                RainStormStartAt = body.RainStormStartAt,
                RxState = body.RxState,
                SolarRad = body.SolarRad,
                Temp = body.Temp,
                TempIn = body.TempIn,
                ThswIndex = body.ThswIndex,
                ThwIndex = body.ThwIndex,
                TransBatteryFlag = body.TransBatteryFlag,
                Txid = body.Txid,
                UvIndex = body.UvIndex,
                WetBulb = body.WetBulb,
                WindChill = body.WindChill,
                WindDirAtHiSpeedLast10_Min = body.WindDirAtHiSpeedLast10_Min,
                WindDirAtHiSpeedLast2_Min = body.WindDirAtHiSpeedLast2_Min,
                WindDirLast = body.WindDirLast,
                WindDirScalarAvgLast10_Min = body.WindDirScalarAvgLast10_Min,
                WindDirScalarAvgLast1_Min = body.WindDirScalarAvgLast1_Min,
                WindDirScalarAvgLast2_Min = body.WindDirScalarAvgLast2_Min,
                WindSpeedAvgLast10_Min = body.WindSpeedAvgLast10_Min,
                WindSpeedAvgLast1_Min = body.WindSpeedAvgLast1_Min,
                WindSpeedAvgLast2_Min = body.WindSpeedAvgLast2_Min,
                WindSpeedHiLast10_Min = body.WindSpeedHiLast10_Min,
                WindSpeedHiLast2_Min = body.WindSpeedHiLast2_Min,
                WindSpeedLast = body.WindSpeedLast
            };

            return Task.FromResult(entry);
        }
    }
}