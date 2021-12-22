using Proje.Infrastructure;
using Proje.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Components
{
    public class CartSummaryViewComponent:ViewComponent
    {
        public string Invoke()
        {
            return HttpContext.Session.GetJson<Cart>("Cart")?.Products.Count().ToString() ?? "0";
            //nesne nin null olup olmadığıma bakması gerekiyor. null ise 0 döndürecek.
        }
    }
}
