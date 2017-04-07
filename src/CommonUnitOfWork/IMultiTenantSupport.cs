namespace CommonUnitOfWork
{
    public interface IMultiTenantSupport<TUnitOfWork> where TUnitOfWork : IUnitOfWork
    {
        TUnitOfWork CreateUnitOfWork(string nameOrConnectionString = "DefaultConnection", string schema = "dbo");
    }
}
