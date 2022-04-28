using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidade;

namespace Contratos
{
    public interface IItemRepositorio : IRepositorioBase<Item>
    {
        Task incluirItem(List<Item> items);
        Task excluirItem(int pedido_id);
        Task alterarItem(List<Item> items);
        Task obterPorIdItem(int id);
    }
}
