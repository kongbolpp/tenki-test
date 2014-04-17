﻿using System;
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
		TextView temperature;
		TextView climate;
		TextView dateTime;

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

			View customNav = LayoutInflater.From(this).Inflate(Resource.Menu.HomeActionBarMenu, null);
			this.ActionBar.SetDisplayShowCustomEnabled(true);
			this.ActionBar.SetDisplayShowHomeEnabled(false); 
			this.ActionBar.SetDisplayShowTitleEnabled(false); 
			this.ActionBar.CustomView = customNav;

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
			temperature = FindViewById<TextView> (Resource.Id.temperature);
			climate = FindViewById<TextView> (Resource.Id.climate);
			dateTime = FindViewById<TextView> (Resource.Id.dateTime);
			cityCode = FindViewById<TextView> (Resource.Id.cityCode);
			homeViewModel.CityCode = "101070201";

			homeViewModel
				.HomeAsync ()
				.ContinueWith (_ => {
					RunOnUiThread (() => {
						//homeViewModel.dic["city"];
						Toast.MakeText (this,"******************"+homeViewModel.HashTable["city"]+"*****************",0).Show();
						Console.Write("**************{0}******************",homeViewModel.HashTable.ToString());
						//StartActivity (typeof (AssignmentTabActivity));
					});
				});
			// Get our button from the layout resource,
			// and attach an event to it
			//Button button = FindViewById<Button> (Resource.Id.myButton);
			
			//button.Click += delegate {
			//	userName.Text = string.Format (homeViewModel.GetApiData());
			//};
		}

		public override bool OnCreateOptionsMenu (IMenu menu)
		{
			//MenuInflater.Inflate (Resource.Menu.HomeActionBarMenu, menu);
			return base.OnCreateOptionsMenu(menu);
		}
	}
}


