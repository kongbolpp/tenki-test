﻿using System;

namespace TenkiDemo.ViewModels
{
	public class HomeViewModel : ViewModelBase
	{
		//public HomeViewModel ()
		//{
		//}
		public string city{ get; set;}              //城市
		public string date_y{ get; set;}            //日期 yyyy年MM月dd日
		public string week{ get; set;}              //星期
		public string fchh{ get; set;}              //预报发布时间
		public string cityid{ get; set;}            //城市id
		public string temp1{ get; set;}             //00:00-04:00 温度（摄氏度）
		public string temp2{ get; set;}             //
		public string temp3{ get; set;}             //
		public string temp4{ get; set;}             //
		public string temp5{ get; set;}             //
		public string temp6{ get; set;}             //
		public string tempF1{ get; set;}            //00:00-04:00 温度（华氏度）
		public string tempF2{ get; set;}            //
		public string tempF3{ get; set;}            //
		public string tempF4{ get; set;}            //
		public string tempF5{ get; set;}            //
		public string tempF6{ get; set;}            //
		public string weather1{ get; set;}          //00:00-04:00 描述（晴转多云...）
		public string weather2{ get; set;}          //
		public string weather3{ get; set;}          //
		public string weather4{ get; set;}          //
		public string weather5{ get; set;}          //
		public string weather6{ get; set;}          //
		public string img1{ get; set;}              //00:00-01:00 气象图编号
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
		public string img_title1{ get; set;}        // 00:00-01:00 气象简述（多云...）
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
		public string wind1{ get; set;}             //00:00-04:00 风向和级数（南风转北风小于3级..）
		public string wind2{ get; set;}             //
		public string wind3{ get; set;}             //
		public string wind4{ get; set;}             //
		public string wind5{ get; set;}             //
		public string wind6{ get; set;}             //
		public string fx1{ get; set;}               //00:00-00:12 风向
		public string fx2{ get; set;}               //00:12-00:24 风向
		public string fl1{ get; set;}               //00:00-04:00 级数（小于三级..）
		public string fl2{ get; set;}               //
		public string fl3{ get; set;}               //
		public string fl4{ get; set;}               //
		public string fl5{ get; set;}               //
		public string fl6{ get; set;}               //
		public string index{ get; set;}             // （"舒适。"）
		public string index_d{ get; set;}           // （"建议着薄型套装或牛仔衫裤等春秋过渡装。年老体弱者宜着套装、夹克衫等。"）
		public string index48{ get; set;}           // （"舒适。"）
		public string ndex48_d{ get; set;}          // （"建议着薄型套装或牛仔衫裤等春秋过渡装。年老体弱者宜着套装、夹克衫等。"）
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



		public string GetApiData ()        
		{                              
			return "Hello World!~";                  
		}                          

	}

}

