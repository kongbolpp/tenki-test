using System;
using System.Threading.Tasks;
using TenkiDemo.ViewModels;
using TenkiDemo.Utilities;

namespace TenkiDemo.ViewModels
{
	public class HomeViewModel : ViewModelBase
	{
		readonly IHomeService service;
		string cityCode;
		string city;              //城市
		string date_y;           //日期 yyyy年MM月dd日
		string week;              //星期
		public string fchh{ get; set;}              //预报发布时间
		public string cityid{ get; set;}            //城市id
		string temp1;             //00:00-04:00 温度（摄氏度）
		public string temp2{ get; set;}             //
		public string temp3{ get; set;}             //
		public string temp4{ get; set;}             //
		public string temp5{ get; set;}             //
		public string temp6{ get; set;}             //
		public string tempF1{ get; set;}            //00:00-04:00 temperature(℉)
		public string tempF2{ get; set;}            //
		public string tempF3{ get; set;}            //
		public string tempF4{ get; set;}            //
		public string tempF5{ get; set;}            //
		public string tempF6{ get; set;}            //
		public string weather1{ get; set;}          //00:00-04:00 detail
		public string weather2{ get; set;}          //
		public string weather3{ get; set;}          //
		public string weather4{ get; set;}          //
		public string weather5{ get; set;}          //
		public string weather6{ get; set;}          //
		public string img1{ get; set;}              //00:00-01:00 weather picture code
		public string img2{ get; set;}              //
		public string img3{ get; set;}              //
		public string img4{ get; set;}              //
		public string img5{ get; set;}              //
		public string img6{ get; set;}              //
		public string img7{ get; set;}              //
		public string img8{ get; set;}              //
		public string img9{ get; set;}              //
		public string img10{ get; set;}             //
		public string img11{ get; set;}             //
		public string img12{ get; set;}             //
		public string img_single{ get; set;}        // ？？
		public string img_title1{ get; set;}        // 00:00-01:00 weather description
		public string img_title2{ get; set;}        //
		public string img_title3{ get; set;}        //
		public string img_title4{ get; set;}        //
		public string img_title5{ get; set;}        //
		public string img_title6{ get; set;}        //
		public string img_title7{ get; set;}        //
		public string img_title8{ get; set;}        //
		public string img_title9{ get; set;}        //
		public string img_title10{ get; set;}       //
		public string img_title11{ get; set;}       //
		public string img_title12{ get; set;}       //
		public string img_title_single{ get; set;}  // ??
		public string wind1{ get; set;}             //00:00-04:00 Wind direction and rank
		public string wind2{ get; set;}             //
		public string wind3{ get; set;}             //
		public string wind4{ get; set;}             //
		public string wind5{ get; set;}             //
		public string wind6{ get; set;}             //
		public string fx1{ get; set;}               //00:00-00:12 Wind direction
		public string fx2{ get; set;}               //00:12-00:24 Wind direction
		public string fl1{ get; set;}               //00:00-04:00 rank
		public string fl2{ get; set;}               //
		public string fl3{ get; set;}               //
		public string fl4{ get; set;}               //
		public string fl5{ get; set;}               //
		public string fl6{ get; set;}               //
		public string index{ get; set;}             // body feeling
		public string index_d{ get; set;}           // suggestions
		public string index48{ get; set;}           // body feeling
		public string ndex48_d{ get; set;}          // suggestions
		public string index_uv{ get; set;}          //
		public string index48_uv{ get; set;}        //
		public string index_xc{ get; set;}          //
		public string index_tr{ get; set;}          //
		public string index_co{ get; set;}          //
		public string st1{ get; set;}               //
		public string st2{ get; set;}               //
		public string st3{ get; set;}               //
		public string st4{ get; set;}               //
		public string st5{ get; set;}               //
		public string st6{ get; set;}               //
		public string index_cl{ get; set;}          //
		public string index_ls{ get; set;}          //
		public string index_ag{ get; set;}          //

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
		/// date_y property
		/// </summary>
		public string Date_y
		{
			get { return date_y; }
			set
			{
				date_y = value;
				Validate ();
				OnPropertyChanged ("Date_y");
			}
		}
		/// <summary>
		/// week property
		/// </summary>
		public string Week
		{
			get { return week; }
			set
			{
				week = value;
				Validate ();
				OnPropertyChanged ("Week");
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

