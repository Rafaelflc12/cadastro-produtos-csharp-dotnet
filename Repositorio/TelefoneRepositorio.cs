using Contratos;
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
                return string.Format("update {0} set ddd=@ddd, numero=@numero, referencia=@referenci where id={1}id", nomeTabela);
            }
        }
    }
}