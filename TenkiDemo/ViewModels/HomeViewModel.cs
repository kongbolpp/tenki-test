using System;
using TenkiDemo.Utilities;
using System.Threading.Tasks;

namespace TenkiDemo.ViewModels
{
	public class HomeViewModel : ViewModelBase
	{
		readonly IHomeService service;
		string cityCode;

		public HomeViewModel ()
		{
			service = ServiceContainer.Resolve<IHomeService> ();
		}

		/// <summary>
		/// cityCode property
		/// </summary>
		public string CityCode
		{
			get { return cityCode; }
			set
			{
				cityCode = value;
				Validate ();
				OnPropertyChanged ("CityCode");
			}
		}

		/// <summary>
		/// Performs an asynchronous login
		/// </summary>
		/// <returns></returns>
		public Task<bool> HomeAsync ()
		{
			IsBusy = true;
			return service
					.HomeAsync (cityCode)
					.ContinueOnCurrentThread (t => {
						IsBusy = false; 
						return t.Result;
					});
		}
	}
}

