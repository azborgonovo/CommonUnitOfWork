using System.Data.Entity;
using System.Threading.Tasks;

namespace CommonUnitOfWork.EF6
{
    public class EntityFrameworkUnitOfWork : DbContext, IUnitOfWork, ICommitableAsyncUnitOfWork, IRollbackableUnitOfWork
    {
        string schema;
        DbContextTransaction dbContextTransaction;

        public EntityFrameworkUnitOfWork() : this(false) { }

        public EntityFrameworkUnitOfWork(bool beginTransaction) : this("DefaultConnection", null, false) { }

        public EntityFrameworkUnitOfWork(string nameOrConnectionString) : this(nameOrConnectionString, null, false) { }

        public EntityFrameworkUnitOfWork(string nameOrConnectionString, string schema) : this(nameOrConnectionString, schema, false) { }

        public EntityFrameworkUnitOfWork(string nameOrConnectionString, string schema, bool beginTransaction)
            : base(nameOrConnectionString)
        {
            this.schema = schema;
            if (beginTransaction)
                dbContextTransaction = Database.BeginTransaction();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (schema != null)
            {
                // Configure default schema
                modelBuilder.HasDefaultSchema(schema);
            }
        }

        public virtual void Commit()
        {
            SaveChanges();
            if (dbContextTransaction != null)
                dbContextTransaction.Commit();
        }

        public virtual async Task CommitAsync()
        {
            await SaveChangesAsync();
            if (dbContextTransaction != null)
                dbContextTransaction.Commit();
        }

        public virtual void Rollback()
        {
            if (dbContextTransaction != null)
                dbContextTransaction.Rollback();
        }

        public new void Dispose()
        {
            if (dbContextTransaction != null)
                dbContextTransaction.Dispose();

            base.Dispose();
        }
    }
}