using Domain;
using Infrastructure.AcessoDados;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

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

        public override List<TEntity> Listar(int? Id)
        {
            CreateCommand(System.Data.CommandType.StoredProcedure, "SP_FILME_S");
            AddInParamInt32("@ID", Id);

            return base.Listar(Id);
        }
    }
}
