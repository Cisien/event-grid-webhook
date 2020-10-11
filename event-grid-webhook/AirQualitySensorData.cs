using System;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace EventGridWebhook
{
    [CompilerGenerated]
    public class AirQualitySensorData
    {
#pragma warning disable IDE1006 // Naming Styles: Auto generated code
        public int Id { get; set; }
        public string SensorId { get; set; }
        [JsonConverter(typeof(SensorDateTimeOffsetConverter))]
        public DateTimeOffset DateTime { get; set; }
        public string Geo { get; set; }
        public int Mem { get; set; }
        public int memfrag { get; set; }
        public int memfb { get; set; }
        public int memcs { get; set; }
        public decimal lat { get; set; }
        public decimal lon { get; set; }
        public decimal Adc { get; set; }
        public int loggingrate { get; set; }
        public string place { get; set; }
        public string version { get; set; }
        public int uptime { get; set; }
        public int rssi { get; set; }
        public int period { get; set; }
        public int httpsuccess { get; set; }
        public int httpsends { get; set; }
        public string hardwareversion { get; set; }
        public string hardwarediscovered { get; set; }
        public int current_temp_f { get; set; }
        public int current_humidity { get; set; }
        public int current_dewpoint_f { get; set; }
        public decimal pressure { get; set; }
        public string p25aqic_b { get; set; }
        [JsonPropertyName("pm2.5_aqi_b")]
        public int pm25_aqi_b { get; set; }
        public decimal pm1_0_atm_b { get; set; }
        public decimal p_0_3_um_b { get; set; }
        public decimal pm2_5_atm_b { get; set; }
        public decimal p_0_5_um_b { get; set; }
        public decimal pm10_0_atm_b { get; set; }
        public decimal p_1_0_um_b { get; set; }
        public decimal pm1_0_cf_1_b { get; set; }
        public decimal p_2_5_um_b { get; set; }
        public decimal pm2_5_cf_1_b { get; set; }
        public decimal p_5_0_um_b { get; set; }
        public decimal pm10_0_cf_1_b { get; set; }
        public decimal p_10_0_um_b { get; set; }
        public string p25aqic { get; set; }
        [JsonPropertyName("pm2.5_aqi")]
        public int pm25_aqi { get; set; }
        public decimal pm1_0_atm { get; set; }
        public decimal p_0_3_um { get; set; }
        public decimal pm2_5_atm { get; set; }
        public decimal p_0_5_um { get; set; }
        public decimal pm10_0_atm { get; set; }
        public decimal p_1_0_um { get; set; }
        public decimal pm1_0_cf_1 { get; set; }
        public decimal p_2_5_um { get; set; }
        public decimal pm2_5_cf_1 { get; set; }
        public decimal p_5_0_um { get; set; }
        public decimal pm10_0_cf_1 { get; set; }
        public decimal p_10_0_um { get; set; }
        public int pa_latency { get; set; }
        public int response { get; set; }
        public int response_date { get; set; }
        public int latency { get; set; }
        public int key1_response { get; set; }
        public int key1_response_date { get; set; }
        public int key1_count { get; set; }
        public int ts_latency { get; set; }
        public int key2_response { get; set; }
        public int key2_response_date { get; set; }
        public int key2_count { get; set; }
        public int ts_s_latency { get; set; }
        public int response_b { get; set; }
        public int response_date_b { get; set; }
        public int latency_b { get; set; }
        public int key1_response_b { get; set; }
        public int key1_response_date_b { get; set; }
        public int key1_count_b { get; set; }
        public int ts_latency_b { get; set; }
        public int key2_response_b { get; set; }
        public int key2_response_date_b { get; set; }
        public int key2_count_b { get; set; }
        public int ts_s_latency_b { get; set; }
        public string wlstate { get; set; }
        public int status_0 { get; set; }
        public int status_1 { get; set; }
        public int status_2 { get; set; }
        public int status_3 { get; set; }
        public int status_4 { get; set; }
        public int status_5 { get; set; }
        public int status_6 { get; set; }
        public int status_7 { get; set; }
        public int status_8 { get; set; }
        public int status_9 { get; set; }
        public int status_10 { get; set; }

#pragma warning restore IDE1006 // Naming Styles

    }
}
