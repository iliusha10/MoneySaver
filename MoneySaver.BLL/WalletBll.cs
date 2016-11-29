using MoneySaver.DAL.Interfaces;
using MoneySaver.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneySaver.DTO.Objects;
using MoneySaver.Domain;

namespace MoneySaver.BLL
{
    public class WalletBll : IWalletBll
    {
        private readonly IRepository _Dal;

        public WalletBll(IRepository dal)
        {
            _Dal = dal;
        }

        public IList<CurrencyDto> GetAllCurrencies()
        {
            var currencies = _Dal.GetAll<Currency>();
            var currencyDtoList = Adapter.AdaptDomainListToCurrencyDtoList(currencies);

            return currencyDtoList;
        }

        public IList<WalletTypeDto> GetAllWalletTypes()
        {
            var types = _Dal.GetAll<WalletType>();
            var typesDtoList = Adapter.AdaptDomainListToWalletTypeDto(types);

            return typesDtoList;
        }
    }
}
