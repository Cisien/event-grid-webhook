using EventGridWebhook.Data;
using EventGridWebhook.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.EventGrid;
using Microsoft.Azure.EventGrid.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
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
        private readonly AirQualityMapper _aqMapper;
        private readonly WeatherMapper _wMapper;

        public Webhook(ILogger<Webhook> logger, SensorDataDbContext context, AirQualityMapper aqMapper, WeatherMapper wMapper)
        {
            _logger = logger;
            _context = context;
            _aqMapper = aqMapper;
            _wMapper = wMapper;
        }

        [HttpPost("ingest")]
        public async Task<IActionResult> Post()
        {
            var subscriber = new EventGridSubscriber();
            using var ms = new MemoryStream();
            await Request.Body.CopyToAsync(ms); ms.Position = 0;
            using var sr = new StreamReader(ms);
            var message = await sr.ReadToEndAsync();
            ms.Position = 0;
            var events = subscriber.DeserializeEventGridEvents(ms);

            _logger.LogInformation($"{events.Length} Message(s) Received");

            foreach (var evt in events)
            {
                _logger.LogInformation($"Handling {evt.EventType}: {evt.GetType().Name}");
                evt.Validate();
                _ = evt.Data switch
                {
                    SubscriptionValidationEventData validationEvent => HandleValidationEvent(validationEvent),
                    IotHubDeviceTelemetryEventData iotData => await HandleIotData(iotData),
                    _ => HandleUnknown(evt.Data)
                };
            }
            return Ok();
        }

        private IActionResult HandleValidationEvent(SubscriptionValidationEventData validationEvent)
        {
            _logger.LogInformation($"{validationEvent.ValidationCode}: {validationEvent.ValidationUrl}");
            var d = new Dictionary<string, string>
            {
                ["validationResponse"] = validationEvent.ValidationCode
            };
            return Ok(d);
        }

        private async Task<IActionResult> HandleIotData(IotHubDeviceTelemetryEventData iotData)
        {
            var aqEntry = await _aqMapper.Map(iotData);
            if(aqEntry != null)
            {
                _context.AirQualityEntries.Add(aqEntry);
            }

            var wEntry = await _wMapper.Map(iotData);
            if(wEntry != null)
            {
                _context.WeatherEntries.Add(wEntry);
            }

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
