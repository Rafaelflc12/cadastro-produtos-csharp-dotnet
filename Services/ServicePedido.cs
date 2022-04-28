using Contratos;
using Entidade;

namespace Services
{
    public class ServicePedido : IPedidoRepositorio
    {
        public ServicePedido(IRepositorioWrapper repositorioWrapper)
        {
            _repositorioWrapper = repositorioWrapper;
        }
        public IRepositorioWrapper _repositorioWrapper;

        public async Task Alterar(Pedido pedido)
        {
            try
            {

await _repositorioWrapper.Pedido.Alterar(pedido);
            await _repositorioWrapper.Item.alterarItem(pedido.Item);
            
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        
        public async Task Criar(Pedido pedido)
        {
            try
            {
                await _repositorioWrapper.Pedido.Criar(pedido);
                await _repositorioWrapper.Item.incluirItem(pedido.Item) ;
                

            }
            catch (Exception ex)
            {
                throw;

            }
        }

        public async Task Excluir(Pedido pedido)
        {
            try
            {
                
                await _repositorioWrapper.Item.excluirItem(pedido.id) ;
                await _repositorioWrapper.Pedido.Excluir(pedido);

            }
            catch (Exception ex)
            {
                throw;

            }
        }

        

       
        

        public async Task<Pedido> ObterPorId(int Id)
        {
            try
            {
              var getID=  await _repositorioWrapper.Pedido.ObterPorId(Id);
                return getID;
            }
            catch (Exception)
            {

                throw;
            }
        }

        
     

      async Task<List<Pedido>> IRepositorioBase<Pedido>.ListarTodos()
        {
            try
            {
            var allgeted=   await  _repositorioWrapper.Pedido.ListarTodos();
                return allgeted;
            }
            catch (Exception)
            {

                throw;
            }
  
        }
    }
}