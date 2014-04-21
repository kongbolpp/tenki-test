using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TenkiDemo.ViewModels;
using System.Collections;

namespace TenkiDemo {

	/// <summary>
	/// I home service
	/// </summary>
	public interface IHomeService {

		/// <summary>
		/// ホームデータ取得
		/// </summary>
		/// <returns>取得したデータ</returns>
		/// <param name="cityCode">地域コード</param>
		/// <param name="cancellationToken">キャンセルトークン</param>
		Task<Hashtable> HomeAsync (string cityCode, CancellationToken cancellationToken = default(CancellationToken));

		void GetWeather (string strCityName);
    }
}
