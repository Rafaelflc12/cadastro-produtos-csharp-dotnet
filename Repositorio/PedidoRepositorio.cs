using System.Data.Common;
using Contratos;
using Dapper;
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
                return string.Format("insert into {0}(datahora, notafiscal,valorfrete, desconto, valortotal, transportadora_id)values(@datahora, @notafiscal, @valorfrete, @desconto, @valortotal, @transportadora_id)", nomeTabela);
            }
        }
        protected override string sqlUpdate
        {
            get
            {
                return string.Format("update {0} set datahora=@datahora, notafiscal=@notafiscal, valorfrete=@valorfrete, desconto=@valordesconto, valortotal=@valortotal ,transportadora_id=@transportadora_id where id=@id", nomeTabela);
            }
        }
        public async Task<List<Pedido>> ListarTodos()
        {

            try
            {
                var sql = "select * from pedido inner join item on pedido.id=item.pedido_id" ;
                using (DbConnection conexao = GetConnection())
                {
                    var geted = await conexao.QueryAsync<Pedido>(string.Format(sql));
                    return geted.ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}