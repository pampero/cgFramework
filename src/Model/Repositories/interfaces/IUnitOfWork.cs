
namespace Model.Repositories.interfaces
{
    public interface IUnitOfWork
    {
        IRoutesRepository RoutesRepository { get; }

        void Save();
    }
}
