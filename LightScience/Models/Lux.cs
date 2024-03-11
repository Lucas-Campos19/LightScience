using Microsoft.EntityFrameworkCore;

namespace LightScience.Models
{
    public class Lux
    {
        public int LuxId { get; set; }

        public int QuantidadeLux { get; set; }
        public DateTime DataLeitura { get; set; }
        public int CuturaId { get; set; }
        public virtual Cutura Cutura { get; set; }
    }
}
