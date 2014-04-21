using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Webkit;
using System.IO;

namespace TenkiDemo.Android
{
	[Activity (Label = "TenkiMapActivity")]			
	public class TenkiMapActivity : Activity
	{
		WebView tenkiMap;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.TenkiMap);
			tenkiMap = FindViewById<WebView> (Resource.Id.webviewMain);
			tenkiMap.Settings.JavaScriptEnabled = true;
			//tenkiMap.LoadUrl ("file:///android_asset/TenkiMap.html");
			//tenkiMap.LoadDataWithBaseURL ("file:///android_asset/",somehtml, "text/html", "UTF-8",null);
			tenkiMap.LoadUrl ("http://www.baidu.com/");
			tenkiMap.SetWebViewClient (new CustWebViewClient());
		}
		private class CustWebViewClient : WebViewClient
		{
			public override bool ShouldOverrideUrlLoading(WebView view, string url)
			{
				view.LoadUrl (url);
				return true;
			}
		}
	
	}
}

