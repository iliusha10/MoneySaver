using MoneySaver.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoneySaver.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IAccountService _accountService;

        [Obsolete]
        public HomeController()
        {
        }

        //public HomeController (IAccountRepository accountRepository)
        //{
        //    _accountService = accountRepository;
        //}

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Create()
        {
            //var account = AccountFactory.CreateAccount("ShaD", "iliusha10@gmail.com", "123456789", MoneySaver.Domain.CurrencyEnum.EUR);
            //_accountRepository.Save<Account>(account);

            return Redirect("Index");
        }
    }
}
