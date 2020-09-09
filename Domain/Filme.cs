using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
   public class Filme : BaseEntity
    {
        public decimal CodFilme { get; set; }

        public string  NomeFilme { get; set; }
       
    }
}
