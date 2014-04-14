using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using TenkiDemo.ViewModels;
using TenkiDemo.Utilities;

namespace TenkiDemo.Android
{
	[Activity (Label = "TenkiDemo.Android", MainLauncher = true)]
	public class HomeActivity : Activity
	{
		readonly HomeViewModel homeViewModel;
		TextView cityCode;

		/// <summary>
		/// Class constructor
		/// </summary>
		public HomeActivity ()
		{
			homeViewModel = ServiceContainer.Resolve<HomeViewModel> ();

			//sets valid changed to show the login button.
			//homeViewModel.IsValidChanged += (sender, e) => {
			//	if (login != null) {
			//		login.Enabled = loginViewModel.IsValid ? true : false;
			//	}
			//};
		}

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
			cityCode = FindViewById<TextView> (Resource.Id.cityCode);

			//cityCode.TextChanged += (sender, e) => {
			//		homeViewModel.CityCode = userName.Text;
			//	editsTest.Text = homeViewModel.Username;
			//};

			homeViewModel.CityCode = cityCode.Text;

			homeViewModel
				.HomeAsync ()
				.ContinueWith (_ => {
					RunOnUiThread (() => {

						//StartActivity (typeof (AssignmentTabActivity));
					});
				});

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			//button.Click += delegate {
			//	userName.Text = string.Format (homeViewModel.GetApiData());
			//};
		}
	}
}


