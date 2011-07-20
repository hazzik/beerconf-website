namespace BeerConf.Web.Application.Metadata
{
	using System.Web.Mvc;
	using MvcExtensions;

	public static class ModelMetadateExtensions
	{
		public static TAdditionalSetting GetAdditionalSettingOrCreateNew<TAdditionalSetting>(this ModelMetadata modelMetadata) 
			where TAdditionalSetting : class, IModelMetadataAdditionalSetting, new()
		{
			var metadata = modelMetadata as ExtendedModelMetadata;
			if (metadata != null) 
				return metadata.Metadata.GetAdditionalSettingOrCreateNew<TAdditionalSetting>();
			return new TAdditionalSetting();
		}
	}
}