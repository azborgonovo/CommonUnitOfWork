using CommonUnitOfWork.EF6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUnitOfWork.Tests
{
    public class CrmUnitOfWork : EntityFrameworkUnitOfWork, ICrmUnitOfWork
    {
        public IClientsRepository Clients
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IProductsRepository Products
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
