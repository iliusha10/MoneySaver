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
                var model = new WalletModel();

                model.Amount = dto.Amount;
                model.CurrencyAbbreviation = dto.CurrencyAbbrviation;
                model.DefaultWallet = dto.DefaultWallet;
                model.WalletID = dto.WalletID;
                model.WalletName = dto.Name;
                model.WalletTypeName = dto.WalletTypeName;

                modellist.Add(model);
            }

            return modellist;
        }
    }
}