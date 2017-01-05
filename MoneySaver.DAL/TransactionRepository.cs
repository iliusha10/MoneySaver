using MoneySaver.DAL.Interfaces;
using MoneySaver.Domain;
using MoneySaver.DTO.Objects;
using MoneySaver.Utils;
using NHibernate.Transform;
using System;
using System.Collections.Generic;

namespace MoneySaver.DAL
{
    public class TransactionRepository : Repository, ITransactionRepository
    {
        public TransactionRepository(ISessionManager sessionManager)
            : base(sessionManager)
        {
        }

        public IList<TransactionDto> GetUserTransactions(long accountID)
        {
            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    TransactionDto row = null;
                    Transaction trans = null;
                    TransactionCategory cat = null;
                    TransactionSubcategory sub = null;
                    TransactionCategoryType type = null;
                    Account acc = null;
                    Wallet wal = null;

                    var tranlist = _session.QueryOver(() => trans)
                        .JoinAlias(() => trans.Walllet, () => wal)
                        .JoinAlias(() => wal.Account, () => acc)
                        .JoinAlias(() => trans.TransactionCategory, () => cat)
                        .JoinAlias(() => cat.CategoryType, () => type)
                        .Left.JoinAlias(() => trans.TransactionSubcategory, () => sub)
                        .OrderBy(() => trans.CreateDate).Desc
                        .WhereRestrictionOn(() => acc.Id).IsLike(accountID)
                        .SelectList(list => list
                            .Select(() => trans.Id).WithAlias(() => row.TransactionID)
                            .Select(() => type.Name).WithAlias(() => row.CategoryTypeName)
                            .Select(() => wal.Name).WithAlias(() => row.WalletName)
                            .Select(() => cat.CategoryName).WithAlias(() => row.CategoryName)
                            .Select(() => sub.SubcategoryName).WithAlias(() => row.SubCategoryName)
                            .Select(() => trans.Value).WithAlias(() => row.Value)
                            .Select(() => trans.Comment).WithAlias(() => row.Comment)
                            .Select(() => trans.CreateDate).WithAlias(() => row.CreateDate))
                        .TransformUsing(Transformers.AliasToBean<TransactionDto>())
                        .List<TransactionDto>();

                    return tranlist;

                }
                catch (Exception ex)
                {
                    Logger.AddToLog("Failed to extract transaction list from repository", ex);
                    return null;
                }
            }
        }


        public IList<CategoryDto> GetCategoriesByType(long accountId, long typeId)
        {
            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    CategoryDto row = null;
                    TransactionCategory cat = null;
                    TransactionCategoryType type = null;
                    Account acc = null;


                    var catlist = _session.QueryOver(() => cat)
                        .JoinAlias(() => cat.Account, () => acc)
                        .JoinAlias(() => cat.CategoryType, () => type)
                        .WhereRestrictionOn(() => acc.Id).IsLike(accountId)
                        .WhereRestrictionOn(() => type.Id).IsLike(typeId)
                        .SelectList(list => list
                            .Select(() => cat.Id).WithAlias(() => row.ID)
                            .Select(() => cat.CategoryName).WithAlias(() => row.Name))
                        .TransformUsing(Transformers.AliasToBean<CategoryDto>())
                        .List<CategoryDto>();

                    return catlist;

                }
                catch (Exception ex)
                {
                    Logger.AddToLog("Failed to extract categories list from repository by acountid and type of category", ex);
                    return null;
                }
            }
        }


        public IList<SubcategoryDto> GetSubcategories(long categoryId)
        {
            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    SubcategoryDto row = null;
                    TransactionCategory cat = null;
                    TransactionSubcategory sub = null;


                    var subcatlist = _session.QueryOver(() => sub)
                        .JoinAlias(() => sub.Category , () => cat)
                        .WhereRestrictionOn(() => cat.Id).IsLike(categoryId)
                        .SelectList(list => list
                            .Select(() => sub.Id).WithAlias(() => row.ID)
                            .Select(() => sub.SubcategoryName).WithAlias(() => row.Name))
                        .TransformUsing(Transformers.AliasToBean<SubcategoryDto>())
                        .List<SubcategoryDto>();

                    return subcatlist;

                }
                catch (Exception ex)
                {
                    Logger.AddToLog("Failed to extract subcategories list from repository by category", ex);
                    return null;
                }
            }
        }
    }
}
