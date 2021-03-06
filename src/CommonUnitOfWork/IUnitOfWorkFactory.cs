﻿namespace CommonUnitOfWork
{
    public interface IUnitOfWorkFactory<TUnitOfWork> where TUnitOfWork : IUnitOfWork
    {
        TUnitOfWork CreateUnitOfWork();
    }
}