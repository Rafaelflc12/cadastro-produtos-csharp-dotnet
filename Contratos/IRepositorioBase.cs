namespace Contratos
{
    public interface IRepositorioBase<T>
    {
        Task Criar(T entity);
        Task Alterar(T entity);
        Task Excluir(T entity);
        Task<List<T>> ListarTodos();

        Task<T> ObterPorId(int Id);
    }
   
}