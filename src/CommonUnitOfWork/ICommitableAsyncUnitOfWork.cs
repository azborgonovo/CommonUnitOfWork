using System.Threading.Tasks;

namespace CommonUnitOfWork
{
    public interface ICommitableAsyncUnitOfWork
    {
        Task CommitAsync();
    }
}
