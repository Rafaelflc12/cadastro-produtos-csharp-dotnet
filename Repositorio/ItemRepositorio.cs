using System.Data.Common;
using Contratos;
using Dapper;
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

        public async Task alterarItem(List<Item> items)
        {
            try
            {
                string sql = "update item set quantidade=@quantidade, valor=@valor where pedido_id=@pedido_id";
                using (DbConnection conexao = GetConnection())
                {
                    await conexao.ExecuteAsync(sql, items);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task excluirItem(int pedido_id)
        {
            try
            {
                var sql = "delete from item where pedido_id = @pedido_id";
                using (DbConnection conexao = GetConnection())
                {
                    await conexao.ExecuteAsync(sql,
                        new { pedido_id = pedido_id });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task incluirItem(List<Item> items)
        {
            try
            {
                foreach (var item in items)
                {
                    await Criar(item);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task obterPorIdItem(int id)
        {
            try
            {
                string sql = "select * from item where id=@pedido_id";
                using (DbConnection conexao = GetConnection())
                {
                    await conexao.ExecuteAsync(sql, id);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}