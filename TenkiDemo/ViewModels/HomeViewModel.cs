﻿using System;
using System.Threading.Tasks;
using TenkiDemo.ViewModels;
using TenkiDemo.Utilities;
using System.Collections.Generic;
using System.Collections;

namespace TenkiDemo.ViewModels
{
	public class HomeViewModel : ViewModelBase
	{
		readonly IHomeService service;
		Hashtable hashTable = new Hashtable ();
		string cityCode;
		string city;                                 //city
		string weather;                              //weather
		string ptime;                                //weather_forecast_time
		string cityid;                               //cityid
		string temp1;                                //highest temperature	
		string temp2;                                //lowest temperature
		string img1;                                 //weather picture code1
		string img2;                                 //weather picture code2

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
		/// city property
		/// </summary>
		public string City
		{
			get { return city; }
			set
			{
				city = value;
				Validate ();
				OnPropertyChanged ("City");
			}
		}

		/// <summary>
		/// city property
		/// </summary>
		public string Weather
		{
			get { return weather; }
			set
			{
				weather = value;
				Validate ();
				OnPropertyChanged ("Weather");
			}
		}
		/// <summary>
		/// ptime property
		/// </summary>
		public string Ptime
		{
			get { return ptime; }
			set
			{
				ptime = value;
				Validate ();
				OnPropertyChanged ("Ptime");
			}
		}
		/// <summary>
		/// cityid property
		/// </summary>
		public string Cityid
		{
			get { return cityid; }
			set
			{
				cityid = value;
				Validate ();
				OnPropertyChanged ("Cityid");
			}
		}
		/// <summary>
		/// temp1 property
		/// </summary>
		public string Temp1
		{
			get { return temp1; }
			set
			{
				temp1 = value;
				Validate ();
				OnPropertyChanged ("Temp1");
			}
		}
		/// <summary>
		/// temp2 property
		/// </summary>
		public string Temp2
		{
			get { return temp2; }
			set
			{
				temp2 = value;
				Validate ();
				OnPropertyChanged ("Temp2");
			}
		}
		/// <summary>
		/// img1 property
		/// </summary>
		public string Img1
		{
			get { return img1; }
			set
			{
				img1 = value;
				Validate ();
				OnPropertyChanged ("Img1");
			}
		}
		/// <summary>
		/// img2 property
		/// </summary>
		public string Img2
		{
			get { return img2; }
			set
			{
				img2 = value;
				Validate ();
				OnPropertyChanged ("Img2");
			}
		}


		/// <summary>
		/// hashTable property
		/// </summary>
		public Hashtable HashTable
		{
			get { return hashTable; }
			set
			{
				hashTable = value;
				Validate ();
				OnPropertyChanged ("HashTable");
			}
		}

		/// <summary>
		/// Performs an asynchronous login
		/// </summary>
		/// <returns></returns>
		public Task<Hashtable> HomeAsync ()
		{
			IsBusy = true;

			return service
					.HomeAsync (cityCode)
					.ContinueOnCurrentThread (t => {
						//homeViewModel.City = dic["city"];
						//homeViewModel.Week = dic["week"];
						//homeViewModel.Temp1 = dic["temp1"];
						//homeViewModel.Date_y = dic["date_y"];
						IsBusy = false;
						hashTable = t.Result;
						return hashTable;
					});
		}
	}
}

