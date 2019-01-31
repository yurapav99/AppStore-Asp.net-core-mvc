using System;
using System.Collections.Generic;

namespace AppStore.Models
{
    public partial class App
    {
        public int AppId { get; set; }
        public string AppName { get; set; }
        public decimal? AppPrice { get; set; }
        public int? AccountId { get; set; }
        public double? AppRating { get; set; }

        public virtual Account Account { get; set; }
    }
}
