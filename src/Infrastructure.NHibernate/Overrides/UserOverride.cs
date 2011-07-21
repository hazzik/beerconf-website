namespace BeerConf.Infrastructure.NHibernate.Overrides
{
    using Domain.Entities;
    using FluentNHibernate.Automapping;
    using FluentNHibernate.Automapping.Alterations;

    public class UserOverride : IAutoMappingOverride<User>
    {
        public void Override(AutoMapping<User> mapping)
        {
            mapping.Table("USERS");

            mapping.Component(x => x.Password,
                              x =>
                                  {
                                      x.Map(p => p.Hash)
                                          .Column("PASSWORD_HASH");
                                      x.Map(p => p.Salt)
                                          .Column("PASSWORD_SALT");
                                  });
        }
    }
}
