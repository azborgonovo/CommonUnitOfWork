using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUnitOfWork.Tests
{
    public class ClientsApplicationService
    {
        readonly ICrmUnitOfWork crmUnitOfWork;

        public ClientsApplicationService(ICrmUnitOfWork crmUnitOfWork)
        {
            this.crmUnitOfWork = crmUnitOfWork;
        }

        public void AddClient(object client)
        {
            try
            {
                crmUnitOfWork.Clients.Add(client);
                crmUnitOfWork.Commit();
            }
            catch (Exception)
            {
                // TODO: handle exception
                throw;
            }
        }

        public async Task AddClientAsync(object client)
        {
            try
            {
                crmUnitOfWork.Clients.Add(client);
                await crmUnitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                // TODO: handle exception
                throw;
            }
        }
    }
}
