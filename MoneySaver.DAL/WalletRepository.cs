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

                    var walletlist = _session.QueryOver(() => wal)
                        .Where(x => x.Account.Id == accountId)
                        .OrderBy(() => wal.DefaultWallet).Desc
                        .SelectList(list => list
                            .Select(() => wal.Id).WithAlias(() => row.WalletID)
                            .Select(() => wal.Amount).WithAlias(() => row.Amount)
                            .Select(() => wal.Name).WithAlias(() => row.Name)
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
    }
}
