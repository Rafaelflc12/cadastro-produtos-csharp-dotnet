using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidade;

namespace Contratos
{
    public interface ITelefoneRepositorio : IRepositorioBase<Telefone>
    {
        Task incluirTelefones(List<Telefone> telefones);
        Task excluirTelefones(int fornecedor_id);
        Task alterarTelefones(List<Telefone> telefone);
    }
}
