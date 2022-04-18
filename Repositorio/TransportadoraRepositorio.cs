using Contratos;
using Entidade;
using Entidade.configuracao;

namespace Repositorio
{
    public class TransportadoraRepositorio : RepositorioBase<Transportadora>, ITransportadoraRepositorio
    {
        public TransportadoraRepositorio(MeuBanco meuBanco) : base(meuBanco) 
        {

        }
        protected override string nomeTabela => "transportadora";

        protected override string sqlInsert
        {
            get
            {
                return string.Format("insert into {0}(nome)values(@nome)", nomeTabela);
            }
        }
        protected override string sqlUpdate
        {
            get
            {
                return string.Format("update {0} set nome=@nome, where id={1}id", nomeTabela);
            }
        }
    }
}