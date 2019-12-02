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

namespace LtechIndia.BackOffice.BOEngine.DAL.DB_New
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
	public partial class dbMan_BO_BrokerTypesListDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public dbMan_BO_BrokerTypesListDataContext() : 
				base(global::LtechIndia.BackOffice.BOEngine.DAL.Properties.Settings.Default.BOExchangeConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_BrokerTypesListDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_BrokerTypesListDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_BrokerTypesListDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_BrokerTypesListDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[Function(Name="dbo.BO_BrokerTypesList")]
		public ISingleResult<BO_BrokerTypesListResult> BO_BrokerTypesList()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<BO_BrokerTypesListResult>)(result.ReturnValue));
		}
	}
	
	public partial class BO_BrokerTypesListResult
	{
		
		private System.Nullable<int> _PK_BrokerTypesID;
		
		private string _BrokerType;
		
		private string _Description;
		
		public BO_BrokerTypesListResult()
		{
		}
		
		[Column(Storage="_PK_BrokerTypesID", DbType="Int")]
		public System.Nullable<int> PK_BrokerTypesID
		{
			get
			{
				return this._PK_BrokerTypesID;
			}
			set
			{
				if ((this._PK_BrokerTypesID != value))
				{
					this._PK_BrokerTypesID = value;
				}
			}
		}
		
		[Column(Storage="_BrokerType", DbType="Char(10)")]
		public string BrokerType
		{
			get
			{
				return this._BrokerType;
			}
			set
			{
				if ((this._BrokerType != value))
				{
					this._BrokerType = value;
				}
			}
		}
		
		[Column(Storage="_Description", DbType="VarChar(50)")]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this._Description = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
