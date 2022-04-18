using Contratos;
using Entidade;
using Entidade.configuracao;

namespace Repositorio
{
    public class PedidoRepositorio : RepositorioBase<Pedido>, IPedidoRepositorio
    {
        public PedidoRepositorio(MeuBanco meuBanco) : base(meuBanco) 
        {

        }
        protected override string nomeTabela => "pedido";

        protected override string sqlInsert
        {
            get
            {
                return string.Format("insert into {0}(datahora, notafiscal,valorfrete, desconto, valortotal)values(@datahora, @notafiscal, @valorfrete, @desconto, @valortotal)", nomeTabela);
            }
        }
        protected override string sqlUpdate
        {
            get
            {
                return string.Format("update {0} set datahora=@datahora, notafiscal=@notafiscal, valorfrete=@valorfrete, desconto=@valordesconto, valortotal=@valortotal where id={1}id", nomeTabela);
            }
        }
    }
}