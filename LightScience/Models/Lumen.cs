namespace LightScience.Models
{
    public class Lumen
    {
        public int LumenId { get; set; }

        public int QuantidadeLumen { get; set; }

        public int MedidaLuminosidade { get; set; }

        public string UnidadeMedida { get; set; }

        public DateTime DataLeitura { get; set; }

        public int CuturaId { get; set; }
        public virtual Cutura Cutura { get; set; }
    }
}
