using DataLayer.Entities;
using eShopWeb.Extensions;
using eShopWeb.Pages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using ServiceLayer.ProduktService.Dto;
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
            //var kunde = _eShopService.LoginCheck("niel862b@elevcampus.dk", "Qwerty123");
            List<ProduktDto> tempkurv = new List<ProduktDto>();
            var varekurv = HttpContext.Session.Get<List<ProduktDto>>("kurv");
            if (varekurv != null)
            {
                return View(varekurv);
            }
            return View(tempkurv);

        }
    }
}
