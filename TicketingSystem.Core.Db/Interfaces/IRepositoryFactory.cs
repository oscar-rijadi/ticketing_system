namespace TicketingSystem.Core.Db.Interfaces
{
    public interface IRepositoryFactory
    {
        IRepository<T> CreateReadable<T>() where T : class;
        IWritableRepository<T> CreateWritable<T>() where T : class;
        IDbCommandReader CreateCommandReader();
    }
}
