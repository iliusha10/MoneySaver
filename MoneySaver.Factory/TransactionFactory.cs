using MoneySaver.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySaver.Factory
{
    public static class TransactionFactory
    {
        public static Transaction CreateSimpleTransaction(double value, string comment, TransactionCategory category, TransactionSubcategory subCategory, Wallet wallet, DateTime date)
        {
            var transaction = new Transaction(value, comment, category, subCategory, wallet, date);
            
            return transaction;
                
        }
    }
}
