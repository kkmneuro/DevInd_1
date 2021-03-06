﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="BOExchange")]
	public partial class dbMan_BO_GetIPAccessListDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public dbMan_BO_GetIPAccessListDataContext() : 
				base(global::LtechIndia.BackOffice.BOEngine.DAL.Properties.Settings.Default.BOExchangeConnectionString1, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_GetIPAccessListDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_GetIPAccessListDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_GetIPAccessListDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_GetIPAccessListDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.BO_GetIpAccessList")]
		public ISingleResult<BO_GetIpAccessListResult> BO_GetIpAccessList()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<BO_GetIpAccessListResult>)(result.ReturnValue));
		}
	}
	
	public partial class BO_GetIpAccessListResult
	{
		
		private int _PK_IPAccessListID;
		
		private string _From_IP;
		
		private string _To_IP;
		
		private string _Status;
		
		private string _Comment;
		
		public BO_GetIpAccessListResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PK_IPAccessListID", DbType="Int NOT NULL")]
		public int PK_IPAccessListID
		{
			get
			{
				return this._PK_IPAccessListID;
			}
			set
			{
				if ((this._PK_IPAccessListID != value))
				{
					this._PK_IPAccessListID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_From_IP", DbType="VarChar(50)")]
		public string From_IP
		{
			get
			{
				return this._From_IP;
			}
			set
			{
				if ((this._From_IP != value))
				{
					this._From_IP = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_To_IP", DbType="VarChar(50)")]
		public string To_IP
		{
			get
			{
				return this._To_IP;
			}
			set
			{
				if ((this._To_IP != value))
				{
					this._To_IP = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Status", DbType="VarChar(15)")]
		public string Status
		{
			get
			{
				return this._Status;
			}
			set
			{
				if ((this._Status != value))
				{
					this._Status = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Comment", DbType="VarChar(256)")]
		public string Comment
		{
			get
			{
				return this._Comment;
			}
			set
			{
				if ((this._Comment != value))
				{
					this._Comment = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
