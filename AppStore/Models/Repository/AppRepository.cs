using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Apptore.Models;
using AppStore.Models;
using AppStore.Models.Repository;

namespace Apptore.Models.Repository
{
   public class AppRepository : IRepository<App>
    {
       
        private  AppStoreContext db;

        public AppRepository(AppStoreContext context)
        {
            this.db = context;
        }

        public IEnumerable<App> GetAll()
        {
            return db.App;
        }

        public App Get(int id)
        {
            return db.App.Find(id);
        }

        public void Create(App app)
        {
            db.App.Add(app);
        }

        public void Update(App app)
        {
            db.Entry(app).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            App app = db.App.Find(id);
            if (app != null)
                db.App .Remove(app);
        }
    }
}
