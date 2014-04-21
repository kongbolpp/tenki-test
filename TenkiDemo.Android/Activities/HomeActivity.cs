using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using TenkiDemo.ViewModels;
using TenkiDemo.Utilities;
using System.Collections.Generic;

namespace TenkiDemo.Android
{
	[Activity (Label = "TenkiDemo", Theme = "@android:style/Theme.Holo.Light", MainLauncher = true)]
	public class HomeActivity : Activity
	{
		readonly HomeViewModel homeViewModel;
		TextView temperature_from;
		TextView temperature_to;
		ImageView wheather;
		TextView wind;
		TextView humidity;
		TextView dateTime;

		/// <summary>
		/// ホーム画面の構造メソッド
		/// </summary>
		public HomeActivity ()
		{
			homeViewModel = ServiceContainer.Resolve<HomeViewModel> ();
		}

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);

			View customNav = LayoutInflater.From(this).Inflate(Resource.Layout.HomeActionBarMenu, null);
			ImageView img_merchant = FindViewById<ImageView> (Resource.Id.img_merchant);
			this.ActionBar.SetDisplayShowCustomEnabled(true);
			this.ActionBar.SetDisplayShowHomeEnabled(false); 
			this.ActionBar.SetDisplayShowTitleEnabled(false); 

			/// TODO
//			img_merchant.Click += delegate {
//				var second = new Intent(this, typeof(TenkiMapActivity));
//				StartActivity(second);
//			};
			this.ActionBar.CustomView = customNav;

			/// 
			temperature_from = FindViewById<TextView> (Resource.Id.temperature_from);
			temperature_to = FindViewById<TextView> (Resource.Id.temperature_to);
			wheather = FindViewById<ImageView> (Resource.Id.wheather);
			wind = FindViewById<TextView> (Resource.Id.wind);
			humidity = FindViewById<TextView> (Resource.Id.humidity);
			dateTime = FindViewById<TextView> (Resource.Id.dateTime);

			homeViewModel.CityCode = "101070201";

			// 
			homeViewModel
				.HomeAsync ()
				.ContinueWith (_ => {
					RunOnUiThread (() => {
						temperature_from.Text = homeViewModel.Temp2;
						temperature_to.Text = homeViewModel.Temp1;
						dateTime.Text = homeViewModel.Today;
					});
				});
//			img_merchant.Click += delegate {
//				var second = new Intent(this, typeof(TenkiMapActivity));
//
//				StartActivity(second);
//			};
		}
	}
}


