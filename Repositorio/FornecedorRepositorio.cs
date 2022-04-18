using Contratos;
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
                return string.Format("update {0} set nome=@nome, descricao=@descricao, cidade=@cidade, endereco=@endereco, bairro=@bairro,    numero=@numero where id={1}id", nomeTabela);
            }
        }
    }
}