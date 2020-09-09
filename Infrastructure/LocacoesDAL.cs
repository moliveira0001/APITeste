using Domain;
using Infrastructure.AcessoDados;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class LocacoesDAL<TEntity> : Padrao<TEntity> where TEntity : Locacoes
    {
        public LocacoesDAL(IConfiguration configuration) : base(configuration)
        {
        }

        public override TEntity Criar(TEntity objEntity_)
        {

            try
            {
                CreateCommand(System.Data.CommandType.StoredProcedure, "SP_LOCACOES_I");
                AddInParamDecimal("@CODCLIENTE", objEntity_.CodCliente);
                AddInParamDecimal("@CODFILME", objEntity_.CodFilme);
                AddInParamDateTime("@DATALOCACAO", objEntity_.DataLocacao);
              

                if (objEntity_.DataEntrega != null)
                    AddInParamDateTime("@DATAENTREGA", objEntity_.DataEntrega);

                return base.Criar(objEntity_);
            }
            finally
            {
                base.Dispose();
            }
        }

        public override TEntity Atualizar(TEntity objEntity_)
        {

            try
            {
                CreateCommand(System.Data.CommandType.StoredProcedure, "SP_LOCACOES_U");
                AddInParamDecimal("@CODLOCACAO", objEntity_.CodLocacao);
                AddInParamDecimal("@CODCLIENTE", objEntity_.CodCliente);
                AddInParamDecimal("@CODFILME", objEntity_.CodFilme);

                if (objEntity_.DataDevolucao != null)
                    AddInParamDateTime("@DATADEVOLUCAO", objEntity_.DataDevolucao);

                return base.Atualizar(objEntity_);
            }
            finally
            {
                base.Dispose();
            }
        }
    }
}
