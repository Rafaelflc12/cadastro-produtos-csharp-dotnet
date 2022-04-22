using Contratos;
using Entidade;
using Entidade.configuracao;

namespace Repositorio
{
    public class ProdutoRepositorio : RepositorioBase<Produto>, IProdutoRepositorio
    {
        public ProdutoRepositorio(MeuBanco meuBanco) : base(meuBanco) 
        {

        }
        protected override string nomeTabela => "produto";

        protected override string sqlInsert
        {
            get
            {
                return string.Format("insert into {0}(nome, descricao)values(@nome, @descricao)", nomeTabela);
            }
        }
        protected override string sqlUpdate
        {
            get
            {
                return string.Format("update {0} set nome=@nome, descricao=@descricao where id=@id", nomeTabela);
            }
        }
    }
}