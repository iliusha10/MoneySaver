using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySaver.Domain
{
    public class Transaction: Entity
    {
        public Transaction(double value, string comment, TransactionCategory category, TransactionSubcategory subCategory, Wallet wallet, DateTime date)
        {
            Value = value;
            Comment = comment;
            TransactionCategory = category;
            TransactionSubcategory = subCategory;
            Walllet = wallet;
            if (date != null) CreateDate = date;
            else
                CreateDate = DateTime.Now;
        }

        [Obsolete]
        protected Transaction()
        {

        }

        public virtual double Value { get; protected set; }
        public virtual string Comment { get; protected set; }
        public virtual TransactionType TransactionType { get; protected set; }
        public virtual TransactionCategory TransactionCategory { get; protected set; }
        public virtual TransactionSubcategory TransactionSubcategory { get; protected set; }
        public virtual Wallet Walllet { get; protected set; }
        public virtual DateTime CreateDate { get; protected set; }
        public virtual bool DoNotExtractFromWallet { get; protected set; }
        public virtual DateTime LoanReturnDate { get; protected set; }
    }
}
