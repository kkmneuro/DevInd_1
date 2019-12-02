﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3625
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LtechIndia.BackOffice.BOEngine.DAL.Rohit
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[System.Data.Linq.Mapping.DatabaseAttribute(Name="BOExchange")]
	public partial class dbMan_BO_GetCurrencyListDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public dbMan_BO_GetCurrencyListDataContext() : 
				base(global::LtechIndia.BackOffice.BOEngine.DAL.Properties.Settings.Default.BOExchangeConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_GetCurrencyListDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_GetCurrencyListDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_GetCurrencyListDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_GetCurrencyListDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[Function(Name="dbo.BO_GetCurrencyList")]
		public ISingleResult<BO_GetCurrencyListResult> BO_GetCurrencyList()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<BO_GetCurrencyListResult>)(result.ReturnValue));
		}
	}
	
	public partial class BO_GetCurrencyListResult
	{
		
		private int _Currency_ID;
		
		private string _CurrencyName;
		
		private string _CurrencyDescription;
		
		private System.Nullable<int> _FK_CountryID;
		
		public BO_GetCurrencyListResult()
		{
		}
		
		[Column(Storage="_Currency_ID", DbType="Int NOT NULL")]
		public int Currency_ID
		{
			get
			{
				return this._Currency_ID;
			}
			set
			{
				if ((this._Currency_ID != value))
				{
					this._Currency_ID = value;
				}
			}
		}
		
		[Column(Storage="_CurrencyName", DbType="VarChar(50)")]
		public string CurrencyName
		{
			get
			{
				return this._CurrencyName;
			}
			set
			{
				if ((this._CurrencyName != value))
				{
					this._CurrencyName = value;
				}
			}
		}
		
		[Column(Storage="_CurrencyDescription", DbType="VarChar(50)")]
		public string CurrencyDescription
		{
			get
			{
				return this._CurrencyDescription;
			}
			set
			{
				if ((this._CurrencyDescription != value))
				{
					this._CurrencyDescription = value;
				}
			}
		}
		
		[Column(Storage="_FK_CountryID", DbType="Int")]
		public System.Nullable<int> FK_CountryID
		{
			get
			{
				return this._FK_CountryID;
			}
			set
			{
				if ((this._FK_CountryID != value))
				{
					this._FK_CountryID = value;
				}
			}
		}
	}
}
#pragma warning restore 1591