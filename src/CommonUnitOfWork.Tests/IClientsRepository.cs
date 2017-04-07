using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUnitOfWork.Tests
{
    public interface IClientsRepository
    {
        void Add(object client);
        Task AddAsync(object client);
    }
}
