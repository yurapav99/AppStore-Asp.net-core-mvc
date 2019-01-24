using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using AppStore.Models;

namespace AppStore.Models.Repository
{
    public class AccountRepository : IRepository<Account>
    {
        private AppStoreContext db;

        public AccountRepository(AppStoreContext context)
        {
            this.db = context;
        }   

        public IEnumerable<Account> GetAll()
        {
            return db.Account;
        }

        public Account Get(int id)
        {
            return db.Account.Find(id);
        }

        public void Create(Account acc)
        {
            db.Account.Add(acc);
        }

        public void Update(Account acc)
        {
            db.Entry(acc).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Account acc = db.Account.Find(id);
            if (acc != null)
                db.Account.Remove(acc);
        }

        public Account GetWithApp(int id)
        {
            var result = db.Account.Find(id);
            if (result.App == null)
                return null;

            return result;
        }

        public IEnumerable<Account> GetAllWithApp()
        {
           var result = db.Account.Where(a=>a.App!=null);

           return result;
        }
    }

}