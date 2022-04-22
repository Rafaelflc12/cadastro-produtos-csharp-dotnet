using Contratos;
using Entidade;
using Entidade.configuracao;

namespace Repositorio
{
    public class EmailRepositorio : RepositorioBase<Email>, IEmailRepositorio
    {
        public EmailRepositorio(MeuBanco meuBanco) : base(meuBanco) 
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
    }
}