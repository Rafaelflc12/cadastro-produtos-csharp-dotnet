using Contratos;
using Entidade;
using Entidade.configuracao;

namespace Repositorio
{
    public class ItemRepositorio : RepositorioBase<Item>, IItemRepositorio
    {
        public ItemRepositorio(MeuBanco meuBanco) : base(meuBanco) 
        {

        }
        protected override string nomeTabela => "item";

        protected override string sqlInsert
        {
            get
            {
                return string.Format("insert into {0}(quantidade, valor)values(@quantidade, @valor)", nomeTabela);
            }
        }
        protected override string sqlUpdate
        {
            get
            {
                return string.Format("update {0} set quantidade=@quantidade, valor=@valor where id=@id", nomeTabela);
            }
        }
    }
}