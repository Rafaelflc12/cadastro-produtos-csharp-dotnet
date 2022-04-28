using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidade;

namespace Contratos
{
    public interface IEmailRepositorio : IRepositorioBase<Email>
    {
        Task incluirEmail(List<Email> emails);
        Task excluirEmail(int fornecedor_id);
        Task alterarEmails(List<Email> emails);
        Task obterPorIdEmails(int id);

    }
}
