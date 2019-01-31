using System;
using System.Collections.Generic;
using AppStore.Models.Repository;

namespace AppStore.Models.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
      IRepository<Account> accounts { get; }
      IRepository<App> apps { get; }
        IEnumerable<App> GetApps { get; }
        void Save();
    }

}
