using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySaver.Domain
{
    public class Account: Entity
    {
        public Account(DateTime date)
        {
            CreatedDate = date;
            WalletsList = new List<Wallet>();
            CredentialsList = new List<Credentials>();
            TransactionCategoryList = new List<TransactionCategory>();
        }

        [Obsolete]
        protected Account()
        {
        }

        public virtual IList<Credentials> CredentialsList { get; protected set; }
        public virtual DateTime CreatedDate { get; protected set; }
        public virtual IList<Wallet> WalletsList { get; protected set; }
        public virtual IList<TransactionCategory> TransactionCategoryList { get; protected set; }

        public virtual void AddWallet(Wallet wallet)
        {
            WalletsList.Add(wallet);
        }

        public virtual void AddUser(Credentials user)
        {
            CredentialsList.Add(user);
        }

        public virtual void AddTransactionCategory(TransactionCategory transactionCategory)
        {
            TransactionCategoryList.Add(transactionCategory);
        }
    }
}
