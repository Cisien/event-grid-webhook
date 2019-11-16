using System;

namespace EventGridWebhook.Data
{
    public class SensorEntry
    {
        public long Id { get; set; }
        public string DeviceId { get; set; }
        public DateTimeOffset SampleTime { get; set; }
        public long Uptime { get; set; }
        public long WifiSignalStrength { get; set; }
        
        public long Temperature_F { get; set; }
        public long Humidity { get; set; }
        public long DewPoint_F { get; set; }
        public decimal Pressure_mB { get; set; }
        
        public string PM2_5IndexColor_A { get; set; }
        public string PM2_5IndexColor_B { get; set; }
        

        public long PM2_5Index_A { get; set; }
        public long PM2_5Index_B { get; set; }

        public decimal PM1_0_ug_A { get; set; }
        public decimal PM1_0_ug_B { get; set; }

        public decimal PM2_5_ug_A { get; set; }
        public decimal PM2_5_ug_B { get; set; }

        public decimal PM10_0_ug_A { get; set; }
        public decimal PM10_0_ug_B { get; set; }

        public decimal P0_3_um_A { get; set; }
        public decimal P0_3_um_B { get; set; }

        public decimal P0_5_um_A { get; set; }
        public decimal P0_5_um_B { get; set; }

        public decimal P1_0_um_A { get; set; }
        public decimal P1_0_um_B { get; set; }

        public decimal P2_5_um_A { get; set; }
        public decimal P2_5_um_B { get; set; }

        public decimal P5_0_um_A { get; set; }
        public decimal P5_0_um_B { get; set; }

        public decimal P10_0_um_A { get; set; }
        public decimal P10_0_um_B { get; set; }
    }
}
