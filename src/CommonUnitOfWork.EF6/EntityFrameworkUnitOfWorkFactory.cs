using System;

namespace CommonUnitOfWork.EF6
{
    public class EntityFrameworkUnitOfWorkFactory<TUnitOfWork>
        : IUnitOfWorkFactory<TUnitOfWork>, ITransactionSupport<TUnitOfWork>, IMultiTenantSupport<TUnitOfWork>
        where TUnitOfWork : EntityFrameworkUnitOfWork, new()
    {
        public TUnitOfWork CreateUnitOfWork()
        {
            return new TUnitOfWork();
        }

        public TUnitOfWork CreateUnitOfWork(bool beginTransaction)
        {
            return (TUnitOfWork)Activator.CreateInstance(typeof(TUnitOfWork), new object[] { beginTransaction });
        }

        public TUnitOfWork CreateUnitOfWork(string nameOrConnectionString, string schema)
        {
            return (TUnitOfWork)Activator.CreateInstance(typeof(TUnitOfWork), new object[] { nameOrConnectionString, schema });
        }
    }
}
