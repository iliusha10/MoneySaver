using MoneySaver.BLL.Interfaces;
using MoneySaver.DTO.Objects;
using MoneySaver.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using MoneySaver.Utils;

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
                Logger.AddToLog("Failed to GetAllCurrencies list from Service", ex);
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
                Logger.AddToLog("Failed to GetAllWalletTypes list from Service", ex);
                throw new FaultException(ex.Message);
            }
        }

        public IList<WalletDto> GetUserWallets(string user)
        {
            try
            {
                var wallets = _walletBll.GetUserWallets(user);
                return wallets;
            }
            catch (Exception ex)
            {
                Logger.AddToLog("Failed to GetUserWallets list from Service", ex);
                throw new FaultException(ex.Message);
            }
        }

        public WalletNamesDto GetDefaultUserWallet(string user)
        {
            try
            {
                var defaultWallet = _walletBll.GetDefaultUserWallet(user);
                return defaultWallet;
            }
            catch (Exception ex)
            {
                Logger.AddToLog("Failed to GetDefaultUserWallet from Service", ex);
                throw new FaultException(ex.Message);
            }
        }


        public IList<WalletNamesDto> GetUserWalletsName(string username)
        {
            try
            {
                var names = _walletBll.GetUserWalletsName(username);
                return names;
            }
            catch (Exception ex)
            {
                Logger.AddToLog("Failed to GetUserWalletsName from Service", ex);
                throw new FaultException(ex.Message);
            }
        }


        public void SaveWallet(WalletDto dto, string username)
        {
            try
            {
                _walletBll.SaveWallet(dto, username);
            }
            catch (Exception ex)
            {
                Logger.AddToLog("Failed to save wallet", ex);
                throw new FaultException(ex.Message);
            }
        }


        public WalletDto GetWallet(long id)
        {
            try
            {
                return _walletBll.GetWallet(id);
            }
            catch (Exception ex)
            {
                Logger.AddToLog("Failed to save wallet", ex);
                throw new FaultException(ex.Message);
            }
        }
    }
}
