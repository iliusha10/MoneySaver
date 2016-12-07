 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySaver.Domain
{
    public class TransactionCategory: Entity
    {
        public TransactionCategory(string name, Account account, TransactionCategoryType categoryType)
        {
            CategoryName = name;
            Account = account;
            CategoryType = categoryType;
            TransactionSubcategoryList = new List<TransactionSubcategory>();
            OrderNumber = account.TransactionCategoryList.Count();
        }

        [Obsolete]
        protected TransactionCategory()
        {
        }

        public virtual string CategoryName { get; protected set; }
        public virtual int OrderNumber { get; protected set; }
        public virtual Account Account { get; protected set; }
        public virtual TransactionCategoryType CategoryType { get; protected set; }
        public virtual IList<TransactionSubcategory> TransactionSubcategoryList { get; protected set; }

        public virtual void AddSubCategory(TransactionSubcategory subcat)
        {
            TransactionSubcategoryList.Add(subcat);
        }

    }
}
