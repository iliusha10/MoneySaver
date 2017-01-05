using MoneySaver.BLL.Interfaces;
using MoneySaver.DTO.Objects;
using MoneySaver.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using MoneySaver.Utils;

namespace MoneySaver.Service
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionBll _transactionBll;

        public TransactionService(ITransactionBll transactionBll)
        {
            _transactionBll = transactionBll;
        }


        public IList<TransactionDto> GetUserTransactions(string user)
        {
            try
            {
                var transactions = _transactionBll.GetUserTransactions(user);
                return transactions;
            }
            catch (Exception ex)
            {
                Logger.AddToLog("Failed to extract transaction list from Service", ex);
                throw new FaultException(ex.Message);
            }
        }


        public IList<CategoryTypeDto> GetAllCategoryTypes()
        {
            try
            {
                var types = _transactionBll.GetAllCategoryTypes();
                return types;
            }
            catch (Exception ex)
            {
                Logger.AddToLog("Failed to GetAllCategoryTypes list from Service", ex);
                throw new FaultException(ex.Message);
            }
        }


        public void SubmitTransaction(TransactionDto dto)
        {
            try
            {
                _transactionBll.SubmitTransaction(dto);
            }
            catch (Exception ex)
            {
                Logger.AddToLog("Failed to Save transaction", ex);
                throw new FaultException(ex.Message);
            }
        }


        public IList<CategoryDto> GetCategoriesByType(string user, long type)
        {
            try
            {
                var categories = _transactionBll.GetCategoriesByType(user, type);
                return categories;
            }
            catch (Exception ex)
            {
                Logger.AddToLog("Failed to GetCategoriesByType list from Service", ex);
                throw new FaultException(ex.Message);
            }
        }


        public IList<SubcategoryDto> GetSubcategories(long category)
        {
            try
            {
                var subcategories = _transactionBll.GetSubcategories(category);
                return subcategories;
            }
            catch (Exception ex)
            {
                Logger.AddToLog("Failed to GetSubcategories list from Service", ex);
                throw new FaultException(ex.Message);
            }
        }


        public void DeleteTransaction(long id)
        {
            try
            {
                _transactionBll.DeleteTransaction(id);
            }
            catch (Exception ex)
            {
                Logger.AddToLog("Failed to Delete transaction", ex);
                throw new FaultException(ex.Message);
            }
        }


        public TransactionDto GetTransaction(long id)
        {
            try
            {
                var tran = _transactionBll.GetTransaction(id);
                return tran;
            }
            catch (Exception ex)
            {
                Logger.AddToLog("Failed to GetTransaction by id from Service", ex);
                throw new FaultException(ex.Message);
            }
        }
    }
}
