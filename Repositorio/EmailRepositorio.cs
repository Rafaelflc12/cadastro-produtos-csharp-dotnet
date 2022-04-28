using System.Data.Common;
using Contratos;
using Dapper;
using Entidade;
using Entidade.configuracao;

namespace Repositorio
{
    public class EmailRepositorio : RepositorioBase<Email>, IEmailRepositorio
    {
        public                                               EmailRepositorio(MeuBanco meuBanco) : base(meuBanco) 
        {

        }
        protected override string nomeTabela => "email";

        protected override string sqlInsert
        {
            get
            {
                return string.Format("insert into {0}(email, referencia)values(@email, @referencia)", nomeTabela);
            }
        }
        protected override string sqlUpdate
        {
            get
            {
                return string.Format("update {0} set email=@email, referencia=@referencia where id=@id", nomeTabela);
            }
        }

        public async Task incluirEmail(List<Email> emails)
        {
            try
            {
                foreach (var email in emails)
                {
                    await Criar(email);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task excluirEmail(int fornecedor_id)
        {
            try
            {
                var sql = "delete from email where fornecedor_id = @fornecedor_id";
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

        public async Task alterarEmails(List<Email> emails)
        {
            try
            {
                string sql = "update email set email=@email, referencia=@referencia where fornecedor_id=@fornecedor_id";
                using (DbConnection conexao = GetConnection())
                {
                    await conexao.ExecuteAsync(sql, emails);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task obterPorIdEmails(int id)
        {
            try
            {
                string sql = "select * from email where id=@fornecedor_id";
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