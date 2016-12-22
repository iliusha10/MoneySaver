using NHibernate;
using MoneySaver.DAL.Interfaces;
using MoneySaver.Utils;
using FluentNHibernate.Data;
using System;
using System.Collections.Generic;


namespace MoneySaver.DAL
{
    public class Repository: IRepository
    {
        protected readonly ISession _session;
        private readonly ISessionManager _sessionManager;

        public Repository(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
            _session = _sessionManager.GetSession();
        }

        public void Save<TEntity>(TEntity entity) where TEntity : Entity
        { 
            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    _session.Save(entity);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    Logger.AddToLog(ex);
                    tran.Rollback();
                }
            }
        }


        public void SaveUpdate<TEntity>(TEntity entity) where TEntity : Entity
        {
            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    _session.SaveOrUpdate(entity);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    Logger.AddToLog(ex);
                    tran.Rollback();
                }
            }
        }

        public void Delete<TEntity>(long id)
        {
            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    var entity = _session.Get<TEntity>(id);
                    _session.Delete(entity);
                    tran.Commit();
                }
                catch(Exception ex)
                {
                    Logger.AddToLog(ex);
                    tran.Rollback();
                }
            }
        }

        public TEntity GetById<TEntity>(long id) where TEntity : Entity
        {
            using(var tran = _session.BeginTransaction())
            {
                try
                {
                    var res = _session.Get<TEntity>(id);
                    return res;
                }
                catch(Exception ex)
                {
                    Logger.AddToLog(ex);
                    return null;
                }
            }
        }


        public IList<TEntity> GetAll<TEntity>() where TEntity : Entity
        {
            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    var res = _session.QueryOver<TEntity>().List();
                    return res;
                }
                catch (Exception ex)
                {
                    Logger.AddToLog(ex);
                    return null;
                }
            }
        }
    }
}
