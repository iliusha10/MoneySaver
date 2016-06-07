using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySaver.DAL.Interfaces
{
    public interface ISessionManager
    {
        ISession GetSession();
    }
}
