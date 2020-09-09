namespace Domain
{
    public class Cliente : BaseEntity
    {
        public decimal Id { get; set; }


        public string Nome { get; set; }

        public string Endereco { get; set; }

        public string Telefone { get; set; }

        public string CPF { get; set; }
    }
}



