using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TenkiDemo.ViewModels;
using System.Net;
using System.IO;


	namespace TenkiDemo.Data {

    /// <summary>
    /// Default IService implementation
    /// - uses a fake sleep, to emulate network interaction
    /// </summary>
		public class HomeService : IHomeService {

        private const int Sleep = 1000;

		public void GetWeather (string strCityName){

//
//		    string contentType = "application/x-www-form-urlencoded";
//			string accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/x-silverlight, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, application/x-silverlight-2-b1, */*";
//			string userAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; WOW64; Trident/5.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E; Zune 4.7; BOIE9;ZHCN)";
//			string referer = "http://ui.ptlogin2.qq.com/cgi-bin/login?appid=1006102&s_url=http://id.qq.com/index.html";

		}

		private string Filter(string str) 
		{ 
			if (!(str.StartsWith("\"") && str.EndsWith("\""))) 
			{ 
				return str; 
			} else { 
				return str.Substring(1, str.Length - 2); 
			} 

		}


		public Task<bool> HomeAsync (string cityCode, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Factory.StartNew (() => {
#if NETFX_CORE
                new System.Threading.ManualResetEvent(false).WaitOne(Sleep);
#else
				string method = "GET";
				string url = "http://www.weather.com.cn/data/sk/"+cityCode+".html";
				//			CookieContainer cookieContainer ;

				HttpWebRequest httpWebRequest = null;
				HttpWebResponse httpWebResponse = null;
				try
				{
					httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
					//					httpWebRequest.CookieContainer = cookieContainer;
					//					httpWebRequest.ContentType = contentType;
					//					httpWebRequest.Referer = referer;
					//					httpWebRequest.Accept = accept;
					//					httpWebRequest.UserAgent = userAgent;
					httpWebRequest.Method = method;
					//					httpWebRequest.ServicePoint.ConnectionLimit = int.MaxValue;


					httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
					Stream responseStream = httpWebResponse.GetResponseStream();
					StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8);
					string jsonString = streamReader.ReadToEnd().ToString();

					streamReader.Close();
					responseStream.Close();

					httpWebRequest.Abort();
					httpWebResponse.Close();
					Console.Write("***********{0}************",jsonString);

					string myJson = jsonString.Substring(("{\"weatherinfo\":{").ToString().Count(),jsonString.Count()-3);
					Dictionary<string, string> dic = new Dictionary<string, string>(); 

					string[] fields = myJson.Split(',');

					for (int i = 0; i < fields.Length; i++ ) 

					{ 
						string[] keyvalue = fields[i].Split(':'); 
						dic.Add(Filter(keyvalue[0]), Filter(keyvalue[1])); 

					}  
					HomeViewModel homeViewModel = new HomeViewModel();
					homeViewModel.City = dic["city"];
					homeViewModel.Week = dic["week"];
					homeViewModel.Temp1 = dic["temp1"];
					homeViewModel.Date_y = dic["date_y"];



				}
				catch (Exception)
				{

				}
                Thread.Sleep (Sleep);
#endif

                return true;
            }, cancellationToken);
        }
    }
}