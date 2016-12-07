using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using MoneySaver.Domain;

namespace MoneySaver.Factory
{
    public static class CategoryFactory
    {
        public static void CreateDefault(Account account, IList<TransactionCategoryType> tranCatType)
        {
            //int catOrder;
            //int subCatOrder;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("http://localhost:81/MSService/Data/DefaultCategoryList.xml");

            foreach (XmlNode type in xmlDoc.DocumentElement.ChildNodes)
            {
                var catTypeId = Convert.ToInt64(type.Attributes["id"].Value);

                foreach (XmlNode cat in type.ChildNodes)
                {
                    var category = CreateCategory(account, tranCatType.Where(x => x.Id == catTypeId).FirstOrDefault(), cat.Name);

                    foreach (XmlNode scat in cat.ChildNodes)
                    {
                        var subCategory = CreateSubCategory(scat.Name, category);
                        category.AddSubCategory(subCategory);
                    }

                    account.AddTransactionCategory(category);
                }
            }
        }

        private static TransactionSubcategory CreateSubCategory(string name, TransactionCategory category)
        {
            var subcat = new TransactionSubcategory(name, category);
            return subcat;
        }

        private static TransactionCategory CreateCategory(Account account, TransactionCategoryType catType, string name)
        {
            var cat = new TransactionCategory(name, account, catType);
            return cat;
        }
    }
}
