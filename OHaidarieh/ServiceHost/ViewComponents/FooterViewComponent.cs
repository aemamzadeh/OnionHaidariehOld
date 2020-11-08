using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceHost.ViewComponents
{
    public class FooterViewComponent:ViewComponent
    {
        //private readonly  
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
