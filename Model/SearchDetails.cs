﻿/**  版本信息模板在安装目录下，可自行修改。
* SearchDetails.cs
*
* 功 能： N/A
* 类 名： SearchDetails
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/08/27 21:47:11   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace BookShop.Model
{
	/// <summary>
	/// SearchDetails:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SearchDetails
	{
		public SearchDetails()
		{}
		#region Model
		private Guid _id;
		private string _keywords;
		private DateTime _datetime;
		/// <summary>
		/// 
		/// </summary>
		public Guid Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string KeyWords
		{
			set{ _keywords=value;}
			get{return _keywords;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime DateTime
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		#endregion Model

	}
}

