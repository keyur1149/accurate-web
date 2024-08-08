namespace accurate_data_access.interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository Product {  get; }
        ICategoryRepository Category { get; }
        Task SaveChangesAsync();
    }
}
