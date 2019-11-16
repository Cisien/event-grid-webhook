using EventGridWebhook.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.EventGrid;
using Microsoft.Azure.EventGrid.Models;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EventGridWebhook.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Webhook : ControllerBase
    {
        private readonly ILogger<Webhook> _logger;
        private readonly SensorDataDbContext _context;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public Webhook(ILogger<Webhook> logger, SensorDataDbContext context, JsonSerializerOptions jsonSerializerOptions)
        {
            _logger = logger;
            _context = context;
            _jsonSerializerOptions = jsonSerializerOptions;
        }

        [HttpPost("ingest")]
        public async Task<IActionResult> Post()
        {
            var subscriber = new EventGridSubscriber();
            using var ms = new MemoryStream();
            await Request.Body.CopyToAsync(ms); ms.Position = 0;
            using var sr = new StreamReader(ms);
            var message = await sr.ReadToEndAsync();
            _logger.LogInformation($"Message Received:\n{message}");
            ms.Position = 0;
            var events = subscriber.DeserializeEventGridEvents(ms);

            foreach (var evt in events)
            {
                evt.Validate();
                _ = evt.Data switch
                {
                    SubscriptionValidationEventData validationEvent => Ok(new SubscriptionValidationResponse(validationEvent.ValidationCode)),
                    IotHubDeviceTelemetryEventData iotData => await HandleIotData(iotData),
                    _ => HandleUnknown(evt.Data)
                };
            }
            return Ok();
        }

        private async Task<IActionResult> HandleIotData(IotHubDeviceTelemetryEventData iotData)
        {
            var data = Convert.FromBase64String(iotData.Body.ToString());
            var decoded = Encoding.UTF8.GetString(data);
            _logger.LogInformation($"Sensor Data Received\n{decoded}");
            var body = JsonSerializer.Deserialize<SensorData>(decoded, _jsonSerializerOptions);
            _logger.LogInformation($"From sensor {body.SensorId}");

            var entry = new SensorEntry
            {
                Id = body.Id,
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

            _context.Entries.Add(entry);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private IActionResult HandleUnknown(object data)
        {
            var jsonData = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            _logger.LogInformation($"Unknown message received \n{jsonData}");
            return Ok();
        }
    }
}
