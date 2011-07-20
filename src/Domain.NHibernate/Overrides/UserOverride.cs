namespace BeerConf.Domain.NHibernate.Overrides
{
	using Entities;
	using FluentNHibernate.Automapping;
    using FluentNHibernate.Automapping.Alterations;

	public class UserOverride : IAutoMappingOverride<Event>
    {
        #region IAutoMappingOverride<Event> Members

        public void Override(AutoMapping<Event> mapping)
        {
            mapping.HasManyToMany(x => x.Participants)
                .Table("EVENT_PARTICIPANTS");
        }

        #endregion
    }
}
