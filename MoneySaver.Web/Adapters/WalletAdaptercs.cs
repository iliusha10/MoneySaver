using MoneySaver.DTO.Objects;
using MoneySaver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneySaver.Adapters
{
    public static class WalletAdaptercs
    {
        public static IList<WalletModel> WalletDtoListToModelList(IList<WalletDto> dtolist)
        {
            var modellist = new List<WalletModel>();

            foreach (var dto in dtolist)
            {
                var model = WalletDtoToWalletModel(dto);

                modellist.Add(model);
            }

            return modellist;
        }

        public static WalletDto CreateWalletModelToDto (CreateWalletModel model)
        {
            var dto = new WalletDto();

            dto.Amount = model.Value;
            dto.CurrencyID = model.SelectedCurrency;
            dto.DefaultWallet = model.DefaultWallet;
            dto.Name = model.WalletName;
            dto.WalletTypeId = model.SelectedWalletType;

            return dto;
        }

        public static WalletModel WalletDtoToWalletModel (WalletDto dto)
        {
            var model = new WalletModel();

            model.Amount = dto.Amount;
            model.CurrencyAbbreviation = dto.CurrencyAbbrviation;
            model.DefaultWallet = dto.DefaultWallet;
            model.WalletID = dto.WalletID;
            model.WalletName = dto.Name;
            model.WalletTypeName = dto.WalletTypeName;

            return model;
        }
    }
}