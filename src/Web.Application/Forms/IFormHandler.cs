namespace BeerConf.Web.Application.Forms
{
	public interface IFormHandler<in TForm> where TForm : IForm
	{
		void Handle(TForm form);
	}
}