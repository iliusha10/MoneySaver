using MoneySaver.DAL.Interfaces;
using MoneySaver.Domain;
using MoneySaver.DTO;
using NHibernate.Transform;
using System;

namespace MoneySaver.DAL
{
    public class AccountRepository : Repository, IAccountRepository
    {
        public AccountRepository(ISessionManager sessionManager)
            : base(sessionManager)
        {
        }

        public LoginDto GetCredentialsByEmail(string email)
        {
            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    Credentials credentials = null;
                    LoginDto row = null;

                    var result = _session.QueryOver(() => credentials)
                        .Where(() => credentials.Email == email)
                            .SelectList(l => l
                                .Select(() => credentials.Email).WithAlias(() => row.Email)
                                .Select(() => credentials.Password).WithAlias(() => row.Password)
                                .Select(() => credentials.UserName).WithAlias(() => row.Nickname));


                    return result.TransformUsing(Transformers.AliasToBean<LoginDto>())
                        .SingleOrDefault<LoginDto>();
                    tran.Commit();
                    //Logger.SaveMediaFileLog(playlist.PlaylistName);
                }
                catch (Exception ex)
                {
                    //Logger.AddToLog("Failed to add media file.", ex);
                    tran.Rollback();
                    return new LoginDto();
                }
            }
        }




        public long GetAcountIdByName(string name)
        {
            Account acc = null;

            var accountId = _session.QueryOver<Credentials>()
                .Where(c => c.UserName == name)
                .JoinAlias(c => c.Account, () => acc)
                .Select(x => acc.Id)
                .SingleOrDefault<long>();

            return accountId;
        }


        public Account GetAcountByName(string name)
        {
            //Account acc = null;

            //var account = _session.QueryOver<Credentials>()
            //    .Where(c => c.UserName == name)
            //    .JoinAlias(c => c.Account, () => acc)
            //    .SingleOrDefault<Account>();

            Account acc = null;
            Credentials cr = null;

            var account = _session.QueryOver<Account>(()=> acc)
                .JoinAlias(()=> acc.CredentialsList, () => cr)
                .Where(()=>cr.UserName == name) 
                .SingleOrDefault<Account>();

            return account;
        }
    }
}
