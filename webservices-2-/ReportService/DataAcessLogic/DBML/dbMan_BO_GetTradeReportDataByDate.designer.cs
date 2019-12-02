﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAcessLogic.DBML
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="OMSExchange")]
	public partial class dbMan_BO_GetTradeReportDataByDateDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public dbMan_BO_GetTradeReportDataByDateDataContext() : 
				base(global::DataAcessLogic.Properties.Settings.Default.OMSExchangeConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_GetTradeReportDataByDateDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_GetTradeReportDataByDateDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_GetTradeReportDataByDateDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_GetTradeReportDataByDateDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.OMS_GetTradeReportDataByDate")]
		public ISingleResult<OMS_GetTradeReportDataByDateResult> OMS_GetTradeReportDataByDate([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Date", DbType="DateTime")] System.Nullable<System.DateTime> date, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ToDate", DbType="DateTime")] System.Nullable<System.DateTime> toDate, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="BrokerID", DbType="Int")] System.Nullable<int> brokerID)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), date, toDate, brokerID);
			return ((ISingleResult<OMS_GetTradeReportDataByDateResult>)(result.ReturnValue));
		}
	}
	
	public partial class OMS_GetTradeReportDataByDateResult
	{
		
		private int _FK_AccountID;
		
		private long _PK_OrderID;
		
		private System.Nullable<System.DateTime> _OrderDateTimeRequested;
		
		private string _Side;
		
		private System.Nullable<long> _PositionSize;
		
		private string _ContractName;
		
		private string _Name;
		
		private System.Nullable<long> _Price;
		
		private System.Nullable<decimal> _TradePrice;
		
		private System.Nullable<int> _BrokerID;
		
		private System.Nullable<System.DateTime> _TradeTime;
		
		private string _TradeNumber;
		
		public OMS_GetTradeReportDataByDateResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FK_AccountID", DbType="Int NOT NULL")]
		public int FK_AccountID
		{
			get
			{
				return this._FK_AccountID;
			}
			set
			{
				if ((this._FK_AccountID != value))
				{
					this._FK_AccountID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PK_OrderID", DbType="BigInt NOT NULL")]
		public long PK_OrderID
		{
			get
			{
				return this._PK_OrderID;
			}
			set
			{
				if ((this._PK_OrderID != value))
				{
					this._PK_OrderID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OrderDateTimeRequested", DbType="DateTime")]
		public System.Nullable<System.DateTime> OrderDateTimeRequested
		{
			get
			{
				return this._OrderDateTimeRequested;
			}
			set
			{
				if ((this._OrderDateTimeRequested != value))
				{
					this._OrderDateTimeRequested = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Side", DbType="Char(10)")]
		public string Side
		{
			get
			{
				return this._Side;
			}
			set
			{
				if ((this._Side != value))
				{
					this._Side = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PositionSize", DbType="BigInt")]
		public System.Nullable<long> PositionSize
		{
			get
			{
				return this._PositionSize;
			}
			set
			{
				if ((this._PositionSize != value))
				{
					this._PositionSize = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ContractName", DbType="VarChar(20)")]
		public string ContractName
		{
			get
			{
				return this._ContractName;
			}
			set
			{
				if ((this._ContractName != value))
				{
					this._ContractName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="VarChar(50)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this._Name = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Price", DbType="BigInt")]
		public System.Nullable<long> Price
		{
			get
			{
				return this._Price;
			}
			set
			{
				if ((this._Price != value))
				{
					this._Price = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TradePrice", DbType="Decimal(0,0)")]
		public System.Nullable<decimal> TradePrice
		{
			get
			{
				return this._TradePrice;
			}
			set
			{
				if ((this._TradePrice != value))
				{
					this._TradePrice = value;
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TradeTime", DbType="DateTime")]
		public System.Nullable<System.DateTime> TradeTime
		{
			get
			{
				return this._TradeTime;
			}
			set
			{
				if ((this._TradeTime != value))
				{
					this._TradeTime = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TradeNumber", DbType="VarChar(40)")]
		public string TradeNumber
		{
			get
			{
				return this._TradeNumber;
			}
			set
			{
				if ((this._TradeNumber != value))
				{
					this._TradeNumber = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
