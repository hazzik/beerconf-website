namespace BeerConf.Domain.NHibernate
{
    using global::NHibernate.Cfg;

    public interface INHibernateConfigurer
    {
        Configuration Configure();
    }
}