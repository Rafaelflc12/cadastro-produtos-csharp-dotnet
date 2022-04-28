using Contratos;
using Entidade;

namespace Services
{
    public class ServiceProduto : IProdutoRepositorio
    {
        public ServiceProduto(IRepositorioWrapper repositorioWrapper)
        {
            _repositorioWrapper = repositorioWrapper;
        }
        public IRepositorioWrapper _repositorioWrapper;

        public async Task Alterar(Produto produto)
        {
            try
            {

await _repositorioWrapper.Produto.Alterar(produto);
            
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        
        public async Task Criar(Produto produto)
        {
            try
            {
                await _repositorioWrapper.Produto.Criar(produto);
                

            }
            catch (Exception ex)
            {
                throw;

            }
        }

        public async Task Excluir(Produto produto)
        {
            try
            {
               
                await _repositorioWrapper.Produto.Excluir(produto);

            }
            catch (Exception ex)
            {
                throw;

            }
        }

        

       
        

        public async Task<Produto> ObterPorId(int Id)
        {
            try
            {
              var getID=  await _repositorioWrapper.Produto.ObterPorId(Id);
                return getID;
            }
            catch (Exception)
            {

                throw;
            }
        }

        
     

     public async Task<List<Produto>> ListarTodos()
        {
            try
            {
            var allgeted=   await  _repositorioWrapper.Produto.ListarTodos();
                return allgeted;
            }
            catch (Exception)
            {

                throw;
            }
  
        }
    }
}