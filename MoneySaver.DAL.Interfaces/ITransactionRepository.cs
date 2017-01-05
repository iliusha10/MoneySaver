using MoneySaver.DTO.Objects;
using System.Collections.Generic;

namespace MoneySaver.DAL.Interfaces
{
    public interface ITransactionRepository
    {
        IList<TransactionDto> GetUserTransactions(long accountID);

        IList<CategoryDto> GetCategoriesByType(long accountId, long type);

        IList<SubcategoryDto> GetSubcategories(long category);
    }
}
