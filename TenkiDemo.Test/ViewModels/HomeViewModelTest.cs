using NUnit.Framework;
using System;
using TenkiDemo.ViewModels;

namespace TenkiDemo.Test
{
	[TestFixture ()]
	public class HomeViewModelTest
	{
		private HomeViewModel target;

		[SetUp ()]
		public void SetUp ()
		{
			target = new HomeViewModel ();
		}

		[TearDown ()]
		public void TearDown ()
		{
		}

		[Test ()]
		public void GetApiDataTest01 ()
		{
			Assert.AreEqual ("Hello World!!", target.GetApiData ());
		}
	}
}

