using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contratos
{
    public interface IRepositorioWrapper 
    {
        IFornecedorRepositorio Fornecedor { get; }
        IEmailRepositorio Email { get; }
        ITelefoneRepositorio Telefone { get; }
        IProdutoRepositorio Produto { get; }
        IItemRepositorio Item { get; }
        IPedidoRepositorio Pedido { get; }
        ITransportadoraRepositorio Transportadora { get; }
    }
}
