namespace BeerConf.Domain.NHibernate.Conventions
{
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.Instances;

    public class ColumnNameUpperCaseConvention : IPropertyConvention
	{
		public void Apply(IPropertyInstance instance)
		{
			var name = NameConventions.ReplaceCamelCaseWithUnderscore(instance.Name);

			instance.Column(name.ToUpper());
		}
	}
}