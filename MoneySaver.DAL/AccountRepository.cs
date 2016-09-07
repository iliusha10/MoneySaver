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
    public class AccountRepository : IAccountRepository
    {
        protected readonly ISession _session;
        private readonly ISessionManager _sessionManager;

        public AccountRepository(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
            _session = _sessionManager.GetSession();
        }

        public LoginDto GetCredentialsByEmail(string email)
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
        }


    }
}
