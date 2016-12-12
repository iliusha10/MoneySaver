using MoneySaver.DTO.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySaver.DAL.Interfaces
{
    public interface IWalletRepository
    {
        IList<WalletDto> GetUserWallets(long accountId);

        WalletDto GetDefaultUserWallet(long accountId);
    }
}
