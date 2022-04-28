using System.Data.Common;
using Contratos;
using Dapper;
using Entidade;
using Entidade.configuracao;

namespace Repositorio
{
    public class TelefoneRepositorio : RepositorioBase<Telefone>, ITelefoneRepositorio
    {
        public TelefoneRepositorio(MeuBanco meuBanco) : base(meuBanco) 
        {

        }
        protected override string nomeTabela => "telefone";

        protected override string sqlInsert
        {
            get
            {
                return string.Format("insert into {0}(ddd, numero, referencia)values(@ddd, @numero, @referencia)", nomeTabela);
            }
        }
        protected override string sqlUpdate
        {
            get
            {
                return string.Format("update {0} set ddd=@ddd, numero=@numero, referencia=@referencia where id=@id", nomeTabela);
            }
        }

        public async Task alterarTelefones(List<Telefone> telefone)
        {

            try
            {
                string sql = "update telefone set ddd=@ddd, numero=@numero, referencia=@referencia where fornecedor_id=@fornecedor_id";
                using (DbConnection conexao = GetConnection())
                {
                    await conexao.ExecuteAsync(sql, telefone);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task excluirTelefones(int fornecedor_id)
        {
            try
            {
                var sql = "delete from telefone where fornecedor_id = @fornecedor_id";
                using (DbConnection conexao = GetConnection())
                {
                    await conexao.ExecuteAsync(sql,
                        new { fornecedor_id = fornecedor_id });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task incluirTelefones(List<Telefone> telefones)
        {
            try
            {
                foreach (var telefone in telefones)
                {
                    await Criar(telefone);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task obterPorIdTelefones(int id)
        {
            try
            {

                string sql = "select * from telefone where id = @fornecedor_id";
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