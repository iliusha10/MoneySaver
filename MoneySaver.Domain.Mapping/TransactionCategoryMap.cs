﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySaver.Domain.Mapping
{
    public class TransactionCategoryMap: EntityMap<TransactionCategory>
    {
        public TransactionCategoryMap()
        {
            Map(x => x.CategoryName).Not.Nullable();
            Map(x => x.OrderNumber);
            HasMany(x => x.TransactionSubcategoryList).LazyLoad().Cascade.All().Inverse();
            References(x => x.Account).Not.Nullable();
            References(x => x.CategoryType).Not.Nullable();

        }
    }
}
