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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="BOExchange_NG")]
	public partial class dbMan_BO_GetBrokersLogDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public dbMan_BO_GetBrokersLogDataContext() : 
				base(global::LtechIndia.BackOffice.BOEngine.DAL.Properties.Settings.Default.BOExchange_NGConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_GetBrokersLogDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_GetBrokersLogDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_GetBrokersLogDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_GetBrokersLogDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.BO_GetBrokersLogNew")]
		public ISingleResult<BO_GetBrokersLogNewResult> BO_GetBrokersLogNew([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> brokerGroupId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Startdate", DbType="DateTime")] System.Nullable<System.DateTime> startdate, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Enddate", DbType="DateTime")] System.Nullable<System.DateTime> enddate)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), brokerGroupId, startdate, enddate);
			return ((ISingleResult<BO_GetBrokersLogNewResult>)(result.ReturnValue));
		}
	}
	
	public partial class BO_GetBrokersLogNewResult
	{
		
		private int _SNo;
		
		private string _BrokerName;
		
		private System.Nullable<int> _BrokerID;
		
		private string _OperationName;
		
		private System.Nullable<System.DateTime> _DateTime;
		
		private string _Message;
		
		private string _IPAddress;
		
		public BO_GetBrokersLogNewResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SNo", DbType="Int NOT NULL")]
		public int SNo
		{
			get
			{
				return this._SNo;
			}
			set
			{
				if ((this._SNo != value))
				{
					this._SNo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BrokerName", DbType="VarChar(50)")]
		public string BrokerName
		{
			get
			{
				return this._BrokerName;
			}
			set
			{
				if ((this._BrokerName != value))
				{
					this._BrokerName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BrokerID", DbType="Int")]
		public System.Nullable<int> BrokerID
		{
			get
			{
				return this._BrokerID;
			}
			set
			{
				if ((this._BrokerID != value))
				{
					this._BrokerID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OperationName", DbType="VarChar(50)")]
		public string OperationName
		{
			get
			{
				return this._OperationName;
			}
			set
			{
				if ((this._OperationName != value))
				{
					this._OperationName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateTime", DbType="DateTime")]
		public System.Nullable<System.DateTime> DateTime
		{
			get
			{
				return this._DateTime;
			}
			set
			{
				if ((this._DateTime != value))
				{
					this._DateTime = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Message", DbType="VarChar(256)")]
		public string Message
		{
			get
			{
				return this._Message;
			}
			set
			{
				if ((this._Message != value))
				{
					this._Message = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IPAddress", DbType="VarChar(50)")]
		public string IPAddress
		{
			get
			{
				return this._IPAddress;
			}
			set
			{
				if ((this._IPAddress != value))
				{
					this._IPAddress = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
