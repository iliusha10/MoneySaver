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
        private readonly IWalletRepository _walletDal;
        private readonly IAccountRepository _accountDal;

        public WalletBll(IRepository dal, IWalletRepository walletDal, IAccountRepository accountDal)
        {
            _Dal = dal;
            _walletDal = walletDal;
            _accountDal = accountDal;
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


        public IList<WalletDto> GetUserWallets(string user)
        {
            var accountId = _accountDal.GetAcountIdByName(user);
            return _walletDal.GetUserWallets(accountId);
        }

        public WalletNamesDto GetDefaultUserWallet(string user)
        {
            var accountId = _accountDal.GetAcountIdByName(user);
            var wallet = _walletDal.GetDefaultUserWallet(accountId);
            var defWallet = new WalletNamesDto() { WalletID = wallet.WalletID, Name = wallet.Name, DefaultWallet = wallet.DefaultWallet };
            return defWallet;
        }

        public Wallet GetWalletByTransactionID(long tranID)
        {
            var wallet = _walletDal.GetWalletByTransactionID(tranID);

            return wallet;
        }

        IList<WalletNamesDto> IWalletBll.GetUserWalletsName(string username)
        {
            var accountId = _accountDal.GetAcountIdByName(username);
            return _walletDal.GetUserWalletsName(accountId);
        }

    }
}
