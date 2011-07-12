namespace BeerConf.Domain.NHibernate.Conventions
{
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.Instances;

    public class EntityConvention : IClassConvention, IJoinedSubclassConvention
	{
        public void Apply(IClassInstance instance)
		{
			string tableName = NameConventions.GetTableName(instance.EntityType);

			instance.Table(tableName);
		    instance.BatchSize(25);
		}

        public void Apply(IJoinedSubclassInstance instance)
		{
			string tableName = NameConventions.GetTableName(instance.EntityType);

			instance.Table(tableName);
            instance.BatchSize(25);
		}
	}
}