using MoneySaver.DTO.Objects;
using MoneySaver.Models;
using MoneySaver.Service.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoneySaver.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        private readonly ITransactionService _tranService;
        private readonly IWalletService _walletService;

        public TransactionController(ITransactionService tranService, IWalletService walletService)
        {
            _tranService = tranService;
            _walletService = walletService;
        }
        // GET: Transaction
        [HttpGet]
        public ActionResult Index()
        {
            var dtolist = _tranService.GetUserTransactions(User.Identity.Name);
            var modelList = new List<TransactionListModel>();

            foreach (var item in dtolist)
            {
                var model = new TransactionListModel();
                model.ConvertDtoListToModelList(item);
                modelList.Add(model);
            }

            return View(modelList);
        }

        // GET: Transaction/Details/5
        [HttpGet]
        public PartialViewResult Details(long id)
        {
            var tran = _tranService.GetTransaction(id);
            var model = new TransactionListModel();
            model.ConvertDtoListToModelList(tran);

            return PartialView(model);
        }

        // GET: Transaction/Create
        [HttpGet]
        public PartialViewResult Create()
        {
            var newTransaction = new TransactionModel();

            var defWallet = _walletService.GetDefaultUserWallet(User.Identity.Name);
            newTransaction.SelectedWallet = defWallet.WalletID;

            newTransaction.AllUsersWallets = new List<SelectListItem>() { new SelectListItem { Value = defWallet.WalletID.ToString(), Text = defWallet.Name } };
            newTransaction.AllUsersWallets.First(x => x.Selected = true);

            newTransaction.AllCategoriesTypes = GetCategoryTypes();
            newTransaction.SelectedCategoryType = 2;
            newTransaction.AllCategoriesTypes.Last(x => x.Selected = true);

            newTransaction.AllCategories = new List<SelectListItem>() { new SelectListItem { Value = "0", Text = "" } };
            newTransaction.AllSubCategories = new List<SelectListItem>() { new SelectListItem { Value = "0", Text = "Select Category First" } };

            newTransaction.CreateDate = DateTime.Now;
            newTransaction.AllCategoriesTypes = GetCategoryTypes();

            return PartialView(newTransaction);
        }

        // POST: Transaction/Create
        [HttpPost]
        public ActionResult Create(TransactionModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var dto = model.ConvertModelToDto();
                    _tranService.SubmitTransaction(dto);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else
                return View();
        }

        // GET: Transaction/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Transaction/Edit/5
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

        // GET: Transaction/Delete/5
        [HttpGet]
        public ActionResult Delete(long id)
        {
            _tranService.DeleteTransaction(id);
            return RedirectToAction("Index");
        }

        // POST: Transaction/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
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

        public JsonResult GetCategories(long type)
        {
            var username = User.Identity.Name;
            var allCategories = _tranService.GetCategoriesByType(username, type);

            var categories = allCategories
                        .Select(c => new
                        {
                            ID = c.ID,
                            Text = c.Name
                        });

            return Json(categories, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSubcategories(long category)
        {
            var list = _tranService.GetSubcategories(category);
            var subcategories = list.Select(c => new
            {
                ID = c.ID,
                Text = c.Name
            });

            return Json(subcategories, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetWallets()
        {
            var username = User.Identity.Name;
            var list = _walletService.GetUserWalletsName(username);
            var wallets = list.Select(w => new
            {
                ID = w.WalletID,
                Text = w.Name
            });

            return Json(wallets, JsonRequestBehavior.AllowGet);
        }

        private IEnumerable<SelectListItem> GetCategoryTypes()
        {
            var allCategoryTypes = _tranService.GetAllCategoryTypes();

            var categoryTypes = allCategoryTypes
                        .Select(x =>
                                new SelectListItem
                                {
                                    Value = x.CategoryTypeID.ToString(),
                                    Text = x.Name
                                });

            return new SelectList(categoryTypes, "Value", "Text");
        }

        //private IEnumerable<SelectListItem> WalletsList(IList<WalletDto> wallets)
        //{
        //    var walletslist = wallets
        //                .Select(x =>
        //                        new SelectListItem
        //                        {
        //                            Value = x.WalletID.ToString(),
        //                            Text = x.Name
        //                        });

        //    return new SelectList(walletslist, "Value", "Text");
        //}
    }
}
