using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TenkiDemo.ViewModels;
using System.Net;
using System.IO;
using TenkiDemo.Utilities;
using System.Collections.Generic;


	namespace TenkiDemo.Data {

    /// <summary>
    /// Default IService implementation
    /// - uses a fake sleep, to emulate network interaction
    /// </summary>
		public class HomeService : IHomeService {

        private const int Sleep = 1000;

		public void GetWeather (string strCityName){
		}

		public Task<Hashtable> HomeAsync (string cityCode, CancellationToken cancellationToken = default(CancellationToken))
		{
			Hashtable weatherInfo = new Hashtable();
            return Task.Factory.StartNew (() => {
#if NETFX_CORE
                new System.Threading.ManualResetEvent(false).WaitOne(Sleep);
#else

				string method = "GET";
				string urlStr = "http://www.weather.com.cn/data/cityinfo/"+cityCode+".html";
				Uri url = new Uri(urlStr);
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
				
					Hashtable jsonObj = (Hashtable)JSON.JsonDecode(jsonString);
					Console.Write("***********{0}************",jsonObj["weatherinfo"]);
					try {
						Hashtable hashTable = (Hashtable)JSON.JsonDecode(jsonString);

						weatherInfo = (Hashtable)hashTable["weatherinfo"];

					} catch (Exception e) {
						Console.WriteLine("  Exception caught: {0}", e.Message);
					}
				} catch (Exception)
				{

				}
                Thread.Sleep (Sleep);
#endif

				return weatherInfo;
            }, cancellationToken);
        }
    }
}