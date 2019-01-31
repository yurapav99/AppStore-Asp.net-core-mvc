using System;
using System.Collections.Generic;

namespace AppStore.Models
{
    public partial class Account
    {
        public Account()
        {
            App = new HashSet<App>();
        }

        public int AccountId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public decimal? Balance { get; set; }

        public virtual ICollection<App> App { get; set; }
    }
}
