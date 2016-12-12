using MoneySaver.DTO.Objects;
using System.Collections.Generic;
using System.ServiceModel;

namespace MoneySaver.Service.Interfaces
{
    [ServiceContract]
    public interface ITransactionService
    {
        [OperationContract]
        IList<TransactionListDto> GetUserTransactions(string user);

        [OperationContract]
        IList<CategoryTypeDto> GetAllCategoryTypes();

        [OperationContract]
        void SubmitTransaction(TransactionDto dto);

        [OperationContract]
        IList<CategoryDto> GetCategoriesByType(string user, long type);

        [OperationContract]
        IList<SubcategoryDto> GetSubcategories(long category);
    }
}
