using MoneySaver.DAL.Interfaces;
using MoneySaver.Domain;
using MoneySaver.DTO.Objects;
using MoneySaver.Utils;
using NHibernate.Criterion;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySaver.DAL
{
    public class WalletRepository : Repository, IWalletRepository
    {
        public WalletRepository(ISessionManager sessionManager)
            : base(sessionManager)
        {
        }

        public IList<WalletDto> GetUserWallets(long accountId)
        {
            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    WalletDto row = null;
                    Wallet wal = null;
                    Currency curr = null;
                    WalletType wt = null;

                    var walletlist = _session.QueryOver(() => wal)
                        .JoinAlias(() => wal.Currency, () => curr)
                        .JoinAlias(() => wal.WalletType, () => wt)
                        .Where(x => x.Account.Id == accountId)
                        .OrderBy(() => wal.DefaultWallet).Desc
                        .SelectList(list => list
                            .Select(() => wal.Id).WithAlias(() => row.WalletID)
                            .Select(() => curr.Abbreviation).WithAlias(() => row.CurrencyAbbrviation)
                            .Select(() => wal.Amount).WithAlias(() => row.Amount)
                            .Select(() => wal.Name).WithAlias(() => row.Name)
                            .Select(() => wt.Name).WithAlias(() => row.WalletTypeName)
                            .Select(() => wal.DefaultWallet).WithAlias(() => row.DefaultWallet))
                        .TransformUsing(Transformers.AliasToBean<WalletDto>())
                        .List<WalletDto>();

                    return walletlist;

                }
                catch (Exception ex)
                {
                    Logger.AddToLog("Failed to extract wallet list from repository", ex);
                    tran.Rollback();
                    return null;
                }
            }
        }

        public WalletDto GetDefaultUserWallet(long accountId)
        {
            var defaultWallet = GetUserWallets(accountId).Where(x => x.DefaultWallet == true).FirstOrDefault();

            return defaultWallet;
        }


        public Wallet GetWalletByTransactionID(long tranID)
        {
            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    Transaction transaction = null;
                    Wallet wal = null;

                    var wallet = _session.QueryOver(() => transaction)
                        .JoinAlias(() => transaction.Walllet, () => wal)
                        .Where(x => x.Walllet.Id == tranID)
                        .SingleOrDefault<Wallet>();

                    return wallet;

                }
                catch (Exception ex)
                {
                    Logger.AddToLog("Failed to extract wallet from repository", ex);
                    tran.Rollback();
                    return null;
                }
            }
        }


        public IList<WalletNamesDto> GetUserWalletsName(long accountId)
        {
            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    WalletNamesDto row = null;
                    Wallet wal = null;

                    var walletlist = _session.QueryOver(() => wal)
                        .Where(x => x.Account.Id == accountId)
                        .OrderBy(() => wal.DefaultWallet).Desc
                        .SelectList(list => list
                            .Select(() => wal.Id).WithAlias(() => row.WalletID)
                            .Select(() => wal.Name).WithAlias(() => row.Name)
                            .Select(() => wal.DefaultWallet).WithAlias(() => row.DefaultWallet))
                        .TransformUsing(Transformers.AliasToBean<WalletNamesDto>())
                        .List<WalletNamesDto>();

                    return walletlist;

                }
                catch (Exception ex)
                {
                    Logger.AddToLog("Failed to extract wallet name list from repository", ex);
                    tran.Rollback();
                    return null;
                }
            }
        }
    }
}
