using MoneySaver.DAL.Interfaces;
using MoneySaver.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneySaver.DTO.Objects;
using MoneySaver.Domain;
using MoneySaver.Factory;

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

        public void SaveWallet(WalletDto dto, string username)
        {
            var account = _accountDal.GetAcountByName(username);
            if (dto.DefaultWallet)
            {
                var defWalletDto = _walletDal.GetDefaultUserWallet(account.Id);
                var defWallet = _Dal.GetById<Wallet>(defWalletDto.WalletID);
                defWallet.AmendDefaultBit(false);
                _Dal.Save<Wallet>(defWallet);
            }
            
            var currency = _Dal.GetById<Currency>(dto.CurrencyID);
            var walletType = _Dal.GetById<WalletType>(dto.WalletTypeId);
            var wallet = WalletFactory.CreateWallet(account, currency, dto.Name, walletType, dto.DefaultWallet, dto.Amount);
            _Dal.Save<Wallet>(wallet);
        }


        public WalletDto GetWallet(long id)
        {
            var wallet = _Dal.GetById<Wallet>(id);
            var walletDto = Adapter.AdaptDomainToWalletDto(wallet);

            return walletDto;
        }
    }
}
