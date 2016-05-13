﻿using Domain;
using Factory;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoneySaver.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        [Obsolete]
        public HomeController()
        {
        }

        public HomeController (IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

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
            var account = AccountFactory.CreateAccount("ShaD", "iliusha10@gmail.com", "123456789", Domain.CurrencyEnum.EUR);
            _accountRepository.Save<Account>(account);

            return Redirect("Index");
        }
    }
}
