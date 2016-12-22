using MoneySaver.Adapters;
using MoneySaver.Models;
using MoneySaver.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoneySaver.Controllers
{
    [Authorize]
    public class WalletController : Controller
    {
        private readonly IWalletService _walletService;

        public WalletController(IWalletService walletService)
        {
            _walletService = walletService;
        }

        // GET: Wallet
        [HttpGet]
        public PartialViewResult TransactionDisplay()
        {
            var walletsModelList = WalletAdaptercs.WalletDtoListToModelList(
                                                _walletService.GetUserWallets(User.Identity.Name));
            return PartialView(walletsModelList);
        }

        [HttpGet]
        public ViewResult WalletList()
        {
            var walletsModelList = WalletAdaptercs.WalletDtoListToModelList(
                                                _walletService.GetUserWallets(User.Identity.Name));
            return View(walletsModelList);
        }

        // GET: Wallet/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Wallet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Wallet/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Wallet/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Wallet/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Wallet/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
