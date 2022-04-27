using Contratos;
using Entidade;

namespace Services
{
    public class ServiceFornecedor : IFornecedorRepositorio
    {
        public ServiceFornecedor(IRepositorioWrapper repositorioWrapper)
        {
            _repositorioWrapper = repositorioWrapper;
        }
        public IRepositorioWrapper _repositorioWrapper;

        public async Task Alterar(Fornecedor fornecedor)
        {
            try
            {

await _repositorioWrapper.Fornecedor.Alterar(fornecedor);
            await _repositorioWrapper.Telefone.alterarTelefones(fornecedor.Telefone);
            await _repositorioWrapper.Email.alterarEmails(fornecedor.Email);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        
        public async Task Criar(Fornecedor fornecedor)
        {
            try
            {
                await _repositorioWrapper.Fornecedor.Criar(fornecedor);
                await _repositorioWrapper.Telefone.incluirTelefones(fornecedor.Telefone) ;
                await _repositorioWrapper.Email.incluirEmail(fornecedor.Email);

            }
            catch (Exception ex)
            {
                throw;

            }
        }

        public async Task Excluir(Fornecedor fornecedor)
        {
            try
            {
                await _repositorioWrapper.Email.excluirEmail(fornecedor.id);
                await _repositorioWrapper.Telefone.excluirTelefones(fornecedor.id) ;
                await _repositorioWrapper.Fornecedor.Excluir(fornecedor);

            }
            catch (Exception ex)
            {
                throw;

            }
        }

        

       
        

        public Task<Fornecedor> ObterPorId(int Id)
        {
            throw new NotImplementedException();
        }

        

       

      

     

      async Task<List<Fornecedor>> IRepositorioBase<Fornecedor>.ListarTodos()
        {
            try
            {
            var allgeted=   await  _repositorioWrapper.Fornecedor.ListarTodos();
                return allgeted;
            }
            catch (Exception)
            {

                throw;
            }
  
        }
    }
}