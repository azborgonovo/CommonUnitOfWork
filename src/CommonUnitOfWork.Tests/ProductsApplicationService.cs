using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUnitOfWork.Tests
{
    public class ProductsApplicationService
    {
        ICrmUnitOfWorkFactory crmContext;

        public ProductsApplicationService(ICrmUnitOfWorkFactory crmContext)
        {
            this.crmContext = crmContext;
        }

        public void AddProduct(object product)
        {
            try
            {
                using (var unitOfWork = crmContext.CreateUnitOfWork())
                {
                    unitOfWork.Products.Add(product);
                    unitOfWork.Commit();
                }
            }
            catch (Exception)
            {
                // TODO: handle exception
                throw;
            }
        }

        public void AddProductWithTransaction(object product)
        {
            try
            {
                using (var unitOfWork = crmContext.CreateUnitOfWork(true))
                {
                    try
                    {
                        unitOfWork.Products.Add(product);
                        unitOfWork.Commit();
                    }
                    catch
                    {
                        unitOfWork.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception)
            {
                // TODO: handle exception
                throw;
            }
        }

        public void AddProductWithTenantInDifferentDatabase(string tenantConnection, object product)
        {
            try
            {
                using (var unitOfWork = crmContext.CreateUnitOfWork(nameOrConnectionString: tenantConnection))
                {
                    unitOfWork.Products.Add(product);
                    unitOfWork.Commit();
                }
            }
            catch (Exception)
            {
                // TODO: handle exception
                throw;
            }
        }

        public void AddProductWithTenantInDifferentSchema(string tenantSchema, object product)
        {
            try
            {
                using (var unitOfWork = crmContext.CreateUnitOfWork(schema: tenantSchema))
                {
                    unitOfWork.Products.Add(product);
                    unitOfWork.Commit();
                }
            }
            catch (Exception)
            {
                // TODO: handle exception
                throw;
            }
        }
    }
}
