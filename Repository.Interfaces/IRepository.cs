﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Repository.Interfaces
{
    public interface IRepository
    {
        void Save<TEntity>(TEntity entity) where TEntity : Entity;
        void SaveUpdate<TEntity>(TEntity entity) where TEntity : Entity;
        void Delete<TEntity>(long id);
        TEntity GetEntityById<TEntity>(long id) where TEntity : Entity;
    }
}