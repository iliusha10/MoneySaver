using MoneySaver.DTO.Objects;
using MoneySaver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneySaver.Adapters
{
    public static class TransactionAdapters
    {
        public static IList<TransactionListModel> TransactionDtoListToModelList(IList<TransactionDto> dtolist)
        {
            var modellist = new List<TransactionListModel>();

            foreach (var dto in dtolist)
            {
                var model = TransactionDtoToModel(dto);

                modellist.Add(model);
            }

            return modellist;
        }

        public static TransactionListModel TransactionDtoToModel(TransactionDto dto)
        {
            var model = new TransactionListModel();

            model.TransactionID = dto.TransactionID;
            model.Value = dto.Value;
            model.WalletName = dto.WalletName;
            model.Comment = dto.Comment;
            model.CreateDate = dto.CreateDate;
            model.CategoryTypeName = dto.CategoryTypeName;
            model.CategoryNameConcat = String.Format("{0}/{1}", dto.CategoryName, dto.SubCategoryName);

            return model;
        }

        public static CreateTransactionModel CreateTransactionDtoToModel(TransactionDto dto)
        {
            var model = new CreateTransactionModel();

            model.SelectedCategoryType = dto.CategoryTypeID;
            model.SelectedWallet = dto.WalletID;
            model.SelectedCategory = dto.CategoryID;
            model.SelectedSubCategory = dto.SubCategoryID;
            model.Value = dto.Value;
            model.Comment = dto.Comment;
            model.CreateDate = dto.CreateDate;

            return model;
        }

        public static TransactionDto CreateTransactionModelToDto(CreateTransactionModel model)
        {
            var dto = new TransactionDto();

            dto.CategoryTypeID = model.SelectedCategoryType;
            dto.WalletID = model.SelectedWallet;
            dto.CategoryID = model.SelectedCategory;
            dto.SubCategoryID = model.SelectedSubCategory;
            dto.Value = model.Value;
            dto.Comment = model.Comment;
            dto.CreateDate = model.CreateDate;

            return dto;
        }
    }
}