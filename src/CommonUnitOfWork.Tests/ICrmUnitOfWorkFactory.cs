using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUnitOfWork.Tests
{
    public interface ICrmUnitOfWorkFactory : IUnitOfWorkFactory<ICrmUnitOfWork>, ITransactionSupport<ICrmUnitOfWork>, IMultiTenantSupport<ICrmUnitOfWork>
    {
    }
}
