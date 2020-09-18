using Domain;
using System.Collections.Generic;

namespace Infrastructure.AcessoDados
{
    public interface IService<TEntity> where TEntity : BaseEntity
    {
        public int Executar();

        public List<TEntity> Consultar(TEntity objEntity_);

        public TEntity Criar(TEntity objEntity_);

        public TEntity Atualizar(TEntity objEntity_);

        public List<TEntity> Listar(int? Id);

    }
}
