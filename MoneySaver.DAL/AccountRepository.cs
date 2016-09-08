using MoneySaver.DAL.Interfaces;
using MoneySaver.Domain;
using MoneySaver.DTO;
using NHibernate;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                                .Select(() => credentials.Password).WithAlias(() => row.Password));


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


    }
}
