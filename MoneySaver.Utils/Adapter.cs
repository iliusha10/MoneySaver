using MoneySaver.Domain;
using MoneySaver.DTO.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MoneySaver.BLL
{
    public static class Adapter
    {
        //public static Currency AdaptCurrencyDtoToDomain(CurrencyDto src, Currency dst)
        //{
        //    //dst.Id = src.CurrencyID;
        //    dst.Abbreviation = src.Abbreviation;
        //    dst.Name = src.Name;
        //}

        //public static WalletType AdaptWalletTypeDtoToDomain(WalletTypeDto src, WalletType dst)
        //{
        //    //dst.Id = src.WalletTypeID;
        //    dst.Name = src.Name;
        //}

        public static IList<CurrencyDto> AdaptDomainListToCurrencyDtoList(IList<Currency> srcList)
        {
            var dtoList = new List<CurrencyDto>();

            foreach (var item in srcList)
            {
                dtoList.Add(new CurrencyDto() { CurrencyID = item.Id, Name = item.Name, Abbreviation = item.Abbreviation });
            }

            return dtoList;
        }

        public static IList<WalletTypeDto> AdaptDomainListToWalletTypeDto(IList<WalletType> srcList)
        {
            var dtoList = new List<WalletTypeDto>();

            foreach (var item in srcList)
            {
                dtoList.Add(new WalletTypeDto( item.Id, item.Name ));
            }

            return dtoList;
        }

        public static IList<CategoryTypeDto> AdaptDomainListToCategoryTypeDto(IList<TransactionCategoryType> srcList)
        {
            var dtoList = new List<CategoryTypeDto>();

            foreach (var item in srcList)
            {
                dtoList.Add(new CategoryTypeDto(item.Id, item.Name));
            }

            return dtoList;
        }

        public static TransactionListDto AdaptDomainToTransactionListDto(Transaction tran)
        {
            var tranDto = new TransactionListDto();
            tranDto.CategoryName = tran.TransactionCategory.CategoryName;
            tranDto.CategoryTypeName = tran.TransactionCategory.CategoryType.Name;
            tranDto.Comment = tran.Comment;
            tranDto.CreateDate= tran.CreateDate;
            tranDto.SubCategoryName = tran.TransactionSubcategory.SubcategoryName;
            tranDto.TransactionID = tran.Id;
            tranDto.Value = tran.Value;
            tranDto.WalletName = tran.Walllet.Name;

            return tranDto;
        }
    }
}
