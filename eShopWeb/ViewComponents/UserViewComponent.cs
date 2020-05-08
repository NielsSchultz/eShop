using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopWeb.ViewComponents
{
    public class UserViewComponent : ViewComponent
    {
        private readonly IeShopService _eShopService;

        public UserViewComponent(IeShopService eShopService)
        {
            _eShopService = eShopService;
        }

        public IViewComponentResult Invoke()
        {
            var kunde = _eShopService.LoginCheck("niel862b@elevcampus.dk", "Qwerty123");
            return View(kunde);
        }
    }
}
