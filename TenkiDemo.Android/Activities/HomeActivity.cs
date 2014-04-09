using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace TenkiDemo.Android
{
	[Activity (Label = "TenkiDemo.Android", MainLauncher = true)]
	public class HomeActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += delegate {
				var homeViewModel = new TenkiDemo.ViewModels.HomeViewModel();
				button.Text = string.Format (homeViewModel.GetApiData());
			};
		}
	}
}


