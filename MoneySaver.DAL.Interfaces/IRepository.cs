﻿using FluentNHibernate.Data;
using System.Collections.Generic;

namespace MoneySaver.DAL.Interfaces
{
    public interface IRepository
    {
        void Save<TEntity>(TEntity entity) where TEntity : Entity;
        void SaveUpdate<TEntity>(TEntity entity) where TEntity : Entity;
        void Delete<TEntity>(long id) where TEntity : Entity;
        TEntity GetById<TEntity>(long id) where TEntity : Entity;
        IList<TEntity> GetAll<TEntity>() where TEntity : Entity;
    }
}