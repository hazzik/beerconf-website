namespace Web.Application.Tests
{
	using System;
	using System.Linq;
	using System.Reflection;
	using System.Web;
	using Xunit;

    
    public class CheckFormsAndHandlersIntegration
	{
		[Fact]
		public void AllFormsShouldHaveOneAndOnlyOneHandler()
		{
			Type[] types = Assembly.Load("BeerConf.Web.Application")
				.GetTypes();

			Type[] forms = types
				.Where(x => x.GetInterface("IForm") != null)
				.Where(x => x.IsPublic && x.IsAbstract == false)
				.ToArray();

			Type[] handlers = types
				.Where(x => x.GetInterface("IFormHandler`1") != null)
				.Where(x => x.IsPublic && x.IsAbstract == false)
				.ToArray();

			foreach (Type form in forms)
			{
				var concreteHandlers = handlers
					.Where(x => x.GetInterface("IFormHandler`1").GetGenericArguments().First() == form)
					.ToArray();
				Console.WriteLine("{0}", form);
				foreach (var concreteHandler in concreteHandlers)
					Console.WriteLine("\thandled by {0}", concreteHandler);
				Assert.Equal(concreteHandlers.Length, 1);
			}
		}
	}
}
