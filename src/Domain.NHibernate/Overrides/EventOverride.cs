namespace BeerConf.Domain.NHibernate.Overrides
{
    using Entities;
    using FluentNHibernate.Automapping;
    using FluentNHibernate.Automapping.Alterations;

    public class EventOverride : IAutoMappingOverride<Event>
    {
        public void Override(AutoMapping<Event> mapping)
        {
            mapping.Map(x => x.Begin)
                .Column("BEGIN_DATE");

            mapping.Map(x => x.End)
                .Column("END_DATE");
        }
    }
}