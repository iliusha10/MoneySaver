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
        [HttpGet]
        public PartialViewResult Details(long id)
        {
            var walletDto = _walletService.GetWallet(id);
            var model = WalletAdaptercs.WalletDtoToWalletModel(walletDto);

            return PartialView(model);
        }

        // GET: Wallet/Create
        [HttpGet]
        public PartialViewResult Create()
        {
            var newWallet = new CreateWalletModel();

            FillWalletModel(newWallet);

            return PartialView(newWallet);
        }

        // POST: Wallet/Create
        [HttpPost]
        public JsonResult Create(CreateWalletModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var dto = WalletAdaptercs.CreateWalletModelToDto(model);
                    _walletService.SaveWallet(dto, User.Identity.Name);
                    return Json(new { success = true });
                }
                catch
                {
                    return Json(new { success = false });
                }
            }
            else
                return Json(new { success = false });
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

        public JsonResult GetCurrencies()
        {
            var list = _walletService.GetAllCurrencies();
            var currencies = list.Select(w => new
            {
                ID = w.CurrencyID,
                Text = w.Abbreviation
            });

            return Json(currencies, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetWalletTypes()
        {
            var list = _walletService.GetAllWalletTypes();
            var walletTypes = list.Select(w => new
            {
                ID = w.WalletTypeID,
                Text = w.Name
            });

            return Json(walletTypes, JsonRequestBehavior.AllowGet);
        }

        private void FillWalletModel(CreateWalletModel model)
        {
                model.AllCurrencys = new List<SelectListItem>() { new SelectListItem { Value = "0", Text = "" } };
                model.AllWalletTypes = new List<SelectListItem>() { new SelectListItem { Value = "0", Text = "" } };
        }
    }
}
