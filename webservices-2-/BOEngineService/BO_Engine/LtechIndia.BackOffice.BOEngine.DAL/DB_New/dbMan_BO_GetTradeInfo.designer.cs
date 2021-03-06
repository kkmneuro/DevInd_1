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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="OMSExchange")]
	public partial class dbMan_BO_GetTradeInfoDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public dbMan_BO_GetTradeInfoDataContext() : 
				base(global::LtechIndia.BackOffice.BOEngine.DAL.Properties.Settings.Default.OMSExchangeConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_GetTradeInfoDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_GetTradeInfoDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_GetTradeInfoDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_GetTradeInfoDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.OMS_GetTradesInfo")]
		public ISingleResult<OMS_GetTradesInfoResult> OMS_GetTradesInfo([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Date", DbType="DateTime")] System.Nullable<System.DateTime> date, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ToDate", DbType="DateTime")] System.Nullable<System.DateTime> toDate)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), date, toDate);
			return ((ISingleResult<OMS_GetTradesInfoResult>)(result.ReturnValue));
		}
	}
	
	public partial class OMS_GetTradesInfoResult
	{
		
		private int _FK_AccountID;
		
		private long _PK_OrderID;
		
		private string _TradeNo;
		
		private System.Nullable<System.DateTime> _OrderDateTimeRequested;
		
		private string _Side;
		
		private System.Nullable<long> _PositionSize;
		
		private string _ProviderName;
		
		private string _ExchangeName;
		
		private string _ContractName;
		
		private string _ProductName;
		
		private string _ProductType;
		
		private string _Name;
		
		private System.Nullable<long> _Price;
		
		private System.Nullable<long> _StopPx;
		
		private System.Nullable<int> _FilledQty;
		
		private System.Nullable<int> _LeaveQty;
		
		private System.Nullable<decimal> _AvgFillPRice;
		
		private string _Reason;
		
		private string _OrderStatus;
		
		private System.Nullable<System.DateTime> _GTD;
		
		private System.Nullable<long> _PositionSize1;
		
		private string _BrokerName;
		
		private System.Nullable<int> _AccountTypeID;
		
		private System.Nullable<int> _SettledQty;
		
		public OMS_GetTradesInfoResult()
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TradeNo", DbType="VarChar(20)")]
		public string TradeNo
		{
			get
			{
				return this._TradeNo;
			}
			set
			{
				if ((this._TradeNo != value))
				{
					this._TradeNo = value;
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProviderName", DbType="VarChar(50)")]
		public string ProviderName
		{
			get
			{
				return this._ProviderName;
			}
			set
			{
				if ((this._ProviderName != value))
				{
					this._ProviderName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ExchangeName", DbType="VarChar(50)")]
		public string ExchangeName
		{
			get
			{
				return this._ExchangeName;
			}
			set
			{
				if ((this._ExchangeName != value))
				{
					this._ExchangeName = value;
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProductName", DbType="VarChar(20)")]
		public string ProductName
		{
			get
			{
				return this._ProductName;
			}
			set
			{
				if ((this._ProductName != value))
				{
					this._ProductName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProductType", DbType="VarChar(10)")]
		public string ProductType
		{
			get
			{
				return this._ProductType;
			}
			set
			{
				if ((this._ProductType != value))
				{
					this._ProductType = value;
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StopPx", DbType="BigInt")]
		public System.Nullable<long> StopPx
		{
			get
			{
				return this._StopPx;
			}
			set
			{
				if ((this._StopPx != value))
				{
					this._StopPx = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FilledQty", DbType="Int")]
		public System.Nullable<int> FilledQty
		{
			get
			{
				return this._FilledQty;
			}
			set
			{
				if ((this._FilledQty != value))
				{
					this._FilledQty = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LeaveQty", DbType="Int")]
		public System.Nullable<int> LeaveQty
		{
			get
			{
				return this._LeaveQty;
			}
			set
			{
				if ((this._LeaveQty != value))
				{
					this._LeaveQty = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AvgFillPRice", DbType="Decimal(0,0)")]
		public System.Nullable<decimal> AvgFillPRice
		{
			get
			{
				return this._AvgFillPRice;
			}
			set
			{
				if ((this._AvgFillPRice != value))
				{
					this._AvgFillPRice = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Reason", DbType="VarChar(20)")]
		public string Reason
		{
			get
			{
				return this._Reason;
			}
			set
			{
				if ((this._Reason != value))
				{
					this._Reason = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OrderStatus", DbType="VarChar(25)")]
		public string OrderStatus
		{
			get
			{
				return this._OrderStatus;
			}
			set
			{
				if ((this._OrderStatus != value))
				{
					this._OrderStatus = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GTD", DbType="DateTime")]
		public System.Nullable<System.DateTime> GTD
		{
			get
			{
				return this._GTD;
			}
			set
			{
				if ((this._GTD != value))
				{
					this._GTD = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PositionSize1", DbType="BigInt")]
		public System.Nullable<long> PositionSize1
		{
			get
			{
				return this._PositionSize1;
			}
			set
			{
				if ((this._PositionSize1 != value))
				{
					this._PositionSize1 = value;
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AccountTypeID", DbType="Int")]
		public System.Nullable<int> AccountTypeID
		{
			get
			{
				return this._AccountTypeID;
			}
			set
			{
				if ((this._AccountTypeID != value))
				{
					this._AccountTypeID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SettledQty", DbType="Int")]
		public System.Nullable<int> SettledQty
		{
			get
			{
				return this._SettledQty;
			}
			set
			{
				if ((this._SettledQty != value))
				{
					this._SettledQty = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
