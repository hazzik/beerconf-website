namespace BeerConf.Web.Application.Forms
{
	public interface IFormHandlerFactory
	{
		IFormHandler<TForm> Create<TForm>() where TForm : IForm;
	}
}