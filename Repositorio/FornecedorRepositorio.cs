using System.Data.Common;
using Contratos;
using Dapper;
using Entidade;
using Entidade.configuracao;

namespace Repositorio
{
    public class FornecedorRepositorio : RepositorioBase<Fornecedor>, IFornecedorRepositorio
    {
        public FornecedorRepositorio(MeuBanco meuBanco) : base(meuBanco) 
        {

        }
        protected override string nomeTabela => "fornecedor";

        protected override string sqlInsert
        {
            get
            {
                return string.Format("insert into {0}(nome, descricao, cidade, endereco, bairro, numero)values(@nome, @descricao, @cidade, @endereco, @bairro, @numero)", nomeTabela);
            }
        }
        protected override string sqlUpdate
        {
            get
            {
                return string.Format("update {0} set nome=@nome, descricao=@descricao, cidade=@cidade, endereco=@endereco, bairro=@bairro,    numero=@numero where id=@id", nomeTabela);
            }
        }

        public async Task<List<Fornecedor>> ListarTodos()
        {
            try
            {
                
                using (DbConnection conexao = GetConnection())
                {
                    var sql = "select * from fornecedor ";
                 var geteds = await conexao.QueryAsync<Fornecedor>(string.Format(sql));
                    foreach (var geted in geteds)
                    {
                        
                          await toTelefone(geted.id);
                          await toEmail(geted.id);
                        
                    }
                }
                    
            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task toTelefone(int id)
        {
            try
            {

                using (DbConnection conexao = GetConnection())
                {
                    string sqltel = @"Select * from telefone where id = fornecedor_id";
                    await conexao.QueryAsync<Telefone>(string.Format(sqltel, id));
                    
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task toEmail(int id)
        {
            try
            {

                using (DbConnection conexao = GetConnection())
                {
                    string sqlEmail = @"Select * from Email where id = fornecedor_id";
                    await conexao.QueryAsync<Email>(string.Format(sqlEmail, id));

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}