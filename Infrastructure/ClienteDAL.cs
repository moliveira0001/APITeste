using Domain;
using Infrastructure.AcessoDados;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Infrastructure
{
    public class ClienteDAL<TEntity> : Padrao<TEntity> where TEntity : Cliente
    {
        public ClienteDAL(IConfiguration configuration) : base(configuration)
        {
        }

        public override TEntity Criar(TEntity  objEntity_)
        {

            try
            {
                CreateCommand(System.Data.CommandType.StoredProcedure, "SP_CLIENTE_I");
                AddInParamString("@NOME", objEntity_.Nome);
                AddInParamString("@CPF", objEntity_.CPF);
                AddInParamString("@ENDERECO", objEntity_.Endereco);
                AddInParamString("@TELEFONE", objEntity_.Telefone);

                return base.Criar(objEntity_);
            }
            finally
            {
                base.Dispose();
            }
           
        }


        public override List<TEntity> Listar(int? Id)
        {
            CreateCommand(System.Data.CommandType.StoredProcedure, "SP_CLIENTE_S");
            AddInParamInt32("@ID", Id);

            return base.Listar(Id);
        }
    }
}
