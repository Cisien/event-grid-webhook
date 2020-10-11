using EventGridWebhook.Data;
using Microsoft.Azure.EventGrid.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EventGridWebhook.Mappers
{
    public class AirQualityMapper
    {
        private readonly ILogger<AirQualityMapper> _logger;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public AirQualityMapper(ILogger<AirQualityMapper> logger, JsonSerializerOptions serializerOptions)
        {
            _logger = logger;
            _jsonSerializerOptions = serializerOptions;
        }

        public Task<AirQualitySensorEntry> Map(IotHubDeviceTelemetryEventData iotData)
        {
            if (iotData.SystemProperties["iothub-connection-device-id"] != "80:7d:3a:61:62:2b")
            {
                return Task.FromResult<AirQualitySensorEntry>(null);
            }

            var data = Convert.FromBase64String(iotData.Body.ToString());
            var decoded = Encoding.UTF8.GetString(data);

            var body = JsonSerializer.Deserialize<AirQualitySensorData>(decoded, _jsonSerializerOptions);

            _logger.LogInformation($"Air Quality Sensor Data Received: {body.pm25_aqi} from {body.SensorId}");

            var entry = new AirQualitySensorEntry
            {
                DeviceId = body.SensorId,
                SampleTime = body.DateTime,
                Uptime = body.uptime,
                WifiSignalStrength = body.rssi,

                DewPoint_F = body.current_dewpoint_f,
                Humidity = body.current_humidity,
                Temperature_F = body.current_temp_f,
                Pressure_mB = body.pressure,

                PM1_0_ug_A = body.pm10_0_atm,
                PM1_0_ug_B = body.pm10_0_atm_b,

                PM2_5_ug_A = body.pm2_5_atm,
                PM2_5_ug_B = body.pm2_5_atm_b,

                PM10_0_ug_A = body.pm10_0_atm,
                PM10_0_ug_B = body.pm10_0_atm_b,

                P0_3_um_A = body.p_0_3_um,
                P0_3_um_B = body.p_0_3_um_b,

                P0_5_um_A = body.p_0_5_um,
                P0_5_um_B = body.p_0_5_um_b,

                P1_0_um_A = body.p_1_0_um,
                P1_0_um_B = body.p_1_0_um_b,

                P2_5_um_A = body.p_2_5_um,
                P2_5_um_B = body.p_2_5_um_b,

                P5_0_um_A = body.p_5_0_um,
                P5_0_um_B = body.p_5_0_um_b,

                P10_0_um_A = body.p_10_0_um,
                P10_0_um_B = body.p_10_0_um_b,

                PM2_5Index_A = body.pm25_aqi,
                PM2_5Index_B = body.pm25_aqi_b,

                PM2_5IndexColor_A = body.p25aqic,
                PM2_5IndexColor_B = body.p25aqic_b
            };
            return Task.FromResult(entry);
        }
    }
}
