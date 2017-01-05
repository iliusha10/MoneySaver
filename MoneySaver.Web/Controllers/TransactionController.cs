using MoneySaver.Adapters;
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
            var modelList = TransactionAdapters.TransactionDtoListToModelList(dtolist);

            return View(modelList);
        }

        // GET: Transaction/Details/5
        [HttpGet]
        public PartialViewResult Details(long id)
        {
            var tran = _tranService.GetTransaction(id);
            var model = TransactionAdapters.TransactionDtoToModel(tran);

            return PartialView(model);
        }

        // GET: Transaction/Create
        [HttpGet]
        public PartialViewResult Create()
        {
            var newTransaction = new CreateTransactionModel();

            FillModel(newTransaction);

            return PartialView(newTransaction);
        }

        // POST: Transaction/Create
        [HttpPost]
        public ActionResult Create(CreateTransactionModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var dto = TransactionAdapters.CreateTransactionModelToDto(model);
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
        public PartialViewResult Edit(long id)
        {
            var tran = _tranService.GetTransaction(id);
            var model = TransactionAdapters.CreateTransactionDtoToModel(tran);
            FillModel(model, tran);
            return PartialView(model);
        }

        // POST: Transaction/Edit/5
        [HttpPost]
        public ActionResult Edit(long id, FormCollection collection)
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

        // POST: Transaction/Delete/5
        [HttpPost]
        public JsonResult Delete(long id)
        {
            try
            {
                _tranService.DeleteTransaction(id);
                return Json(new { success = true });
                //return RedirectToAction("Index");
            }
            catch
            {
                return Json(new { success = false });
                //return View();
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

        private void FillModel(CreateTransactionModel model, TransactionDto tran = null)
        {
            if (tran == null)
            {
                var defWallet = _walletService.GetDefaultUserWallet(User.Identity.Name);
                model.SelectedWallet = defWallet.WalletID;
                model.AllUsersWallets = new List<SelectListItem>() { new SelectListItem { Value = defWallet.WalletID.ToString(), Text = defWallet.Name } };
                model.AllUsersWallets.First(x => x.Selected = true);

                model.AllCategoriesTypes = GetCategoryTypes();
                model.SelectedCategoryType = 2;
                model.AllCategoriesTypes.Last(x => x.Selected = true);

                model.AllCategories = new List<SelectListItem>() { new SelectListItem { Value = "0", Text = "" } };
                model.AllSubCategories = new List<SelectListItem>() { new SelectListItem { Value = "0", Text = "Select Category First" } };

                model.CreateDate = DateTime.Now;
            }
            else
            {
                model.AllUsersWallets = new List<SelectListItem>() { new SelectListItem { Value = "0", Text = "" } };
                model.SelectedWallet = tran.WalletID;

                model.AllCategoriesTypes = new List<SelectListItem>() { new SelectListItem { Value = "0", Text = "" } };
                model.AllCategories = new List<SelectListItem>() { new SelectListItem { Value = "0", Text = "" } };
                model.AllSubCategories = new List<SelectListItem>() { new SelectListItem { Value = "0", Text = "" } };

            }

        }
    }
}
