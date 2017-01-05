using MoneySaver.DTO.Objects;
using System.Collections.Generic;
using System.ServiceModel;

namespace MoneySaver.Service.Interfaces
{
    [ServiceContract]
    public interface ITransactionService
    {
        [OperationContract]
        IList<TransactionDto> GetUserTransactions(string user);

        [OperationContract]
        IList<CategoryTypeDto> GetAllCategoryTypes();

        [OperationContract]
        void SubmitTransaction(TransactionDto dto);

        [OperationContract]
        IList<CategoryDto> GetCategoriesByType(string user, long type);

        [OperationContract]
        IList<SubcategoryDto> GetSubcategories(long category);

        [OperationContract]
        void DeleteTransaction(long id);

        [OperationContract]
        TransactionDto GetTransaction(long id);
    }
}
