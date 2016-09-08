using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MoneySaver.Domain.Mapping;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace MoneySaver.DAL
{
    public class SessionGenerator
    {
        private static readonly ISessionFactory SessionFactory = CreateSessionFactory();
        private static readonly SessionGenerator _sessionGenerator = new SessionGenerator();

        private SessionGenerator()
        { 
        }

        public static SessionGenerator Instance
        {
            get { return _sessionGenerator; }
        }

        public ISessionFactory GetSessionFactory()
        {
            return SessionFactory;
        }

        private static ISessionFactory CreateSessionFactory()
        {
            var configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                .ConnectionString(builder => builder.Database("MoneySaver")
                .Server(@"MDDSK40107")
                .Username("sqlUser").Password("MoneySaverDBlogin001")
                //.TrustedConnection()
                ))
                .Mappings(x => x.FluentMappings.AddFromAssembly(typeof(EntityMap<>).Assembly))
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true));

            return configuration.BuildSessionFactory();
        }
    }
}
