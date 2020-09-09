using System;

namespace Domain
{

    public class Locacoes : BaseEntity
    {
        public decimal CodLocacao { get; set; }
        public decimal CodFilme { get; set; }
        public decimal CodCliente { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime? DataEntrega { get; set; }
        public DateTime DataDevolucao { get; set; }
    }
}
