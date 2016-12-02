using FluentNHibernate.Mapping;
using MoneySaver.Domain;

namespace MoneySaver.Domain.Mapping
{
    public class FutureTransactionMap : SubclassMap<FutureTransaction>
    {
        public FutureTransactionMap()
        {
            Map(x => x.ApplyOnWallet).Not.Nullable();
            Map(x => x.ApplyDate).Not.Nullable();
        }
    }
}
