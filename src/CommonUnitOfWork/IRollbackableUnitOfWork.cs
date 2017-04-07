namespace CommonUnitOfWork
{
    public interface IRollbackableUnitOfWork
    {
        void Rollback();
    }
}