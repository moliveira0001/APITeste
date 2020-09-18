using System;
using System.Collections.Generic;

namespace Domain
{
    public abstract class BaseEntity
    {
        public List<string> MensagemErroValidator { get; set; }
        public string MensagemExeption { get; set; }
        public string Mensagem { get; set; }
        public bool BadRequest { get; set; }
        public DateTime DataCricacao { get; set; }
        public int? Id { get; set; }

        public BaseEntity()
        {
            MensagemErroValidator = new List<string>();
        }


    }
}
