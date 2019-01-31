using System;
using System.Collections.Generic;
using AppStore.Models.Repository;
using Apptore.Models.Repository;

namespace AppStore.Models.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        private AppStoreContext db;
        private IRepository<Account> accountRepository;
        private IRepository<App> appRepository;

       public  UnitOfWork(AppStoreContext db, IRepository<Account> accountRepository, IRepository<App> appRepository)
        {
            this.db=db;
            this.accountRepository = accountRepository;
            this.appRepository = appRepository;

        }

        public IRepository<Account> accounts
        {
            get
            {
                if (accountRepository == null)
                    accountRepository = new AccountRepository(db);
                return accountRepository;
            }
        }

        public IRepository<App> apps
        {
            get
            {
                if (appRepository == null)
                    appRepository = new AppRepository(db);
                return appRepository;
            }
        }

        public IEnumerable<App> GetApps => appRepository.GetAll();

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
