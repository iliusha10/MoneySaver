using FluentNHibernate.Data;

namespace MoneySaver.DAL.Interfaces
{
    public interface IRepository
    {
        void Save<TEntity>(TEntity entity) where TEntity : Entity;
        void SaveUpdate<TEntity>(TEntity entity) where TEntity : Entity;
        void Delete<TEntity>(long id);
        TEntity GetById<TEntity>(long id) where TEntity : Entity;
    }
}