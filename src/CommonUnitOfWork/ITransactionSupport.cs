namespace CommonUnitOfWork
{
    public interface ITransactionSupport<TUnitOfWork> where TUnitOfWork : IUnitOfWork
    {
        TUnitOfWork CreateUnitOfWork(bool beginTransaction);
    }
}
