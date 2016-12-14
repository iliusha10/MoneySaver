using MoneySaver.DTO.Objects;
using System.Collections.Generic;

namespace MoneySaver.BLL.Interfaces
{
    public interface ITransactionBll
    {
        /// <summary>
        /// Getting list of transactions from Db for a accountID
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns>list of TransactionListDto</returns>
        IList<TransactionListDto> GetUserTransactions(string user);

        /// <summary>
        /// Getting list of category types from Db
        /// </summary>
        /// <returns>list of CategoryTypeDto</returns>
        IList<CategoryTypeDto> GetAllCategoryTypes();

        /// <summary>
        /// Saving a transaction
        /// </summary>
        /// <param name="dto"></param>
        void SubmitTransaction(TransactionDto dto);

        /// <summary>
        /// Getting list of categories for specified user and type of category from Db
        /// </summary>
        /// <param name="user"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        IList<CategoryDto> GetCategoriesByType(string user, long type);

        /// <summary>
        /// Getting list of subcategories for specified category from Db
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        IList<SubcategoryDto> GetSubcategories(long category);

        /// <summary>
        /// Deleting a transaction
        /// </summary>
        /// <param name="id"></param>
        void DeleteTransaction(long id);

        /// <summary>
        /// Getting transaction by id from Db
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TransactionListDto GetTransaction(long id);
    }
}
