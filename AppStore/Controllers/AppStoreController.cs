using AppStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Linq;
using AppStore.Models.Repository;
using AppStore.Models.UnitOfWork;

namespace AppStore.Controllers
{
    public class AppStoreController : Controller
    {

        private IUnitOfWork context;

        public AppStoreController(IUnitOfWork context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View(context.apps.GetAll().ToList());
        }


        [HttpGet]
        public IActionResult Buy(int id)
        {
            ViewBag.AppId = id;
            return View();
        }
        [HttpPost]
        public string Buy(Account account, int appId)
        {
            int id =context.accounts.GetAll().Count();
            account.AccountId=++id;
            context.accounts.Create(account);
            var app=context.apps.Get(appId);
            app.AccountId=account.AccountId;
            context.apps.Update(app);
            context.Save();
            return "Thanks, " + account.UserName + ",for purchase!";
        }

    }
}