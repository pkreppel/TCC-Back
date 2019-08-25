using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public partial class SensoresBarragem
    {
        [Key]
        public int SensorId { get; set; }
        public int TipoSensor { get; set; }
        public double ValorSensor { get; set; }
        public DateTime HoraMonitoramento { get; set; }
    }
}
