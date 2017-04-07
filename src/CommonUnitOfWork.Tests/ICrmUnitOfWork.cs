using CommonUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUnitOfWork.Tests
{
    public interface ICrmUnitOfWork : IUnitOfWork, ICommitableAsyncUnitOfWork, IRollbackableUnitOfWork
    {
        IClientsRepository Clients { get; }
        IProductsRepository Products { get; }
    }
}
