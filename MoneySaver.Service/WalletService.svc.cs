using MoneySaver.BLL.Interfaces;
using MoneySaver.DTO;
using MoneySaver.DTO.Objects;
using MoneySaver.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Web;

namespace MoneySaver.Service
{
    public class WalletService : IWalletService
    {
        private readonly IWalletBll _walletBll;

        public WalletService(IWalletBll walletBll)
        {
            _walletBll = walletBll;
        }


        public IList<CurrencyDto> GetAllCurrencies()
        {
            try
            {
                var currencies = _walletBll.GetAllCurrencies();
                return currencies;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public IList<WalletTypeDto> GetAllWalletTypes()
        {
            try
            {
                var types = _walletBll.GetAllWalletTypes();
                return types;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

    }
}
