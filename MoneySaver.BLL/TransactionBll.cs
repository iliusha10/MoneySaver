using MoneySaver.BLL.Interfaces;
using MoneySaver.DAL.Interfaces;
using MoneySaver.Domain;
using MoneySaver.DTO.Objects;
using MoneySaver.Factory;
using System.Collections.Generic;

namespace MoneySaver.BLL
{
    public class TransactionBll : ITransactionBll
    {
        private readonly IRepository _Dal;
        private readonly ITransactionRepository _transactionDal;
        private readonly IAccountRepository _accountDal;

        public TransactionBll(ITransactionRepository transactionDal, IRepository dal, IAccountRepository accountDal)
        {
            _transactionDal = transactionDal;
            _Dal = dal;
            _accountDal = accountDal;
        }

        public IList<TransactionListDto> GetUserTransactions(string user)
        {
            var accountId = _accountDal.GetAcountIdByName(user);
            var list = _transactionDal.GetUserTransactions(accountId);

            return list;
        }


        public IList<CategoryTypeDto> GetAllCategoryTypes()
        {
            var types = _Dal.GetAll<TransactionCategoryType>();
            var typesDtoList = Adapter.AdaptDomainListToCategoryTypeDto(types);

            return typesDtoList;
        }


        public void SubmitTransaction(TransactionDto dto)
        {
            var category = _Dal.GetById<TransactionCategory>(dto.CategoryID);
            var subCategory = _Dal.GetById<TransactionSubcategory>(dto.SubCategoryID);
            var wallet = _Dal.GetById<Wallet>(dto.WalletID);
            var transaction = TransactionFactory.CreateSimpleTransaction(dto.Value, dto.Comment, category, subCategory, wallet, dto.CreateDate);
            if (category.CategoryType.Name == TransactionCategoryTypeEnumDto.Income.ToString())
            {
                wallet.Add(dto.Value);
            }
            else
            {
                wallet.Spend(dto.Value);
            }

            _Dal.SaveUpdate<Wallet>(wallet);
            _Dal.Save<Transaction>(transaction);
        }


        public IList<CategoryDto> GetCategoriesByType(string user, long type)
        {
            var accountId = _accountDal.GetAcountIdByName(user);
            var categories = _transactionDal.GetCategoriesByType(accountId, type);

            return categories;
        }


        public IList<SubcategoryDto> GetSubcategories(long category)
        {
            var subcategories = _transactionDal.GetSubcategories(category);

            return subcategories;
        }


        public void DeleteTransaction(long id)
        {
            _Dal.Delete<Transaction>(id);
        }


        public TransactionListDto GetTransaction(long id)
        {
            var tran = _Dal.GetById<Transaction>(id);
            var dto = Adapter.AdaptDomainToTransactionListDto(tran);
            return dto;
        }
    }

}
