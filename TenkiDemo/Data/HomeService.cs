//
//  Copyright 2012  Xamarin Inc.
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TenkiDemo.ViewModels;
using Newtonsoft.Json;

	namespace TenkiDemo.Data {

    /// <summary>
    /// Default IService implementation
    /// - uses a fake sleep, to emulate network interaction
    /// </summary>
		public class HomeService : IHomeService {

        private const int Sleep = 1000;
		public HomeViewModel GetWeather (string strCityName){

			var webClient = new System.Net.WebClient();
			// 101010100 
			var result = webClient.DownloadString("http://www.weather.com.cn/data/sk/"+strCityName+".html");
			//透过JSON.net 反序列化为HomeViewModel对象
			var weather = JsonConvert.DeserializeObject<HomeViewModel>(result);
			//印出 id and name

			Console.Write ("weather.city={0},weather.cityid={1}",weather.city,weather.cityid ); 
			return weather;
		}

			public Task<bool> HomeAsync (string username, string password, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Factory.StartNew (() => {
#if NETFX_CORE
                new System.Threading.ManualResetEvent(false).WaitOne(Sleep);
#else
                Thread.Sleep (Sleep);
#endif

                return true;
            }, cancellationToken);
        }
    }
}