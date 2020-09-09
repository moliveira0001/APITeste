using Domain;
using Infrastructure.AcessoDados;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class FilmeDAL<TEntity> : Padrao<TEntity> where TEntity : Filme
    {
        public FilmeDAL(IConfiguration configuration) : base(configuration)
        {
        }

        public override TEntity Criar(TEntity objEntity_)
        {
            CreateCommand(System.Data.CommandType.StoredProcedure, "SP_FILME_I");
            AddInParamString("@NOME", objEntity_.NomeFilme);
       

            return base.Criar(objEntity_);
        }
    }
}
