﻿using MoneySaver.DAL.Interfaces;
using NHibernate;


namespace MoneySaver.DAL
{
    public class SessionManager : ISessionManager
    {
        private readonly ISession _session;
        private readonly ISessionFactory _sessionFactory = SessionGenerator.Instance.GetSessionFactory();

        public SessionManager()
        {
            _session = _sessionFactory.OpenSession();
        }

        public ISession GetSession()
        {
            return _session;
        }
    }
}
