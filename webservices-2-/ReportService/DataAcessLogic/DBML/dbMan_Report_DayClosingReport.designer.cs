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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="BOExchange")]
	public partial class dbMan_Report_DayClosingReportDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public dbMan_Report_DayClosingReportDataContext() : 
				base(global::DataAcessLogic.Properties.Settings.Default.BOExchangeConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_Report_DayClosingReportDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_Report_DayClosingReportDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_Report_DayClosingReportDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_Report_DayClosingReportDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.Report_DayClosingReport")]
		public ISingleResult<Report_DayClosingReportResult> Report_DayClosingReport([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Symbol", DbType="VarChar(20)")] string symbol, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="DateTime")] System.Nullable<System.DateTime> datetime, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="BrokerID", DbType="Int")] System.Nullable<int> brokerID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ParentBrokerID", DbType="Int")] System.Nullable<int> parentBrokerID)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), symbol, datetime, brokerID, parentBrokerID);
			return ((ISingleResult<Report_DayClosingReportResult>)(result.ReturnValue));
		}
	}
	
	public partial class Report_DayClosingReportResult
	{
		
		private System.Nullable<System.DateTime> _TradeDate;
		
		private string _Symbol;
		
		private System.Nullable<int> _TradeBuyUnit;
		
		private System.Nullable<int> _TradeSellUnit;
		
		private System.Nullable<decimal> _TradeBuyCapital;
		
		private System.Nullable<decimal> _TradeSellCapital;
		
		private System.Nullable<int> _OpenBuyQty;
		
		private System.Nullable<int> _OpenSellQty;
		
		private int _BrokerID;
		
		public Report_DayClosingReportResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TradeDate", DbType="Date")]
		public System.Nullable<System.DateTime> TradeDate
		{
			get
			{
				return this._TradeDate;
			}
			set
			{
				if ((this._TradeDate != value))
				{
					this._TradeDate = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Symbol", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string Symbol
		{
			get
			{
				return this._Symbol;
			}
			set
			{
				if ((this._Symbol != value))
				{
					this._Symbol = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TradeBuyUnit", DbType="Int")]
		public System.Nullable<int> TradeBuyUnit
		{
			get
			{
				return this._TradeBuyUnit;
			}
			set
			{
				if ((this._TradeBuyUnit != value))
				{
					this._TradeBuyUnit = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TradeSellUnit", DbType="Int")]
		public System.Nullable<int> TradeSellUnit
		{
			get
			{
				return this._TradeSellUnit;
			}
			set
			{
				if ((this._TradeSellUnit != value))
				{
					this._TradeSellUnit = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TradeBuyCapital", DbType="Decimal(0,0)")]
		public System.Nullable<decimal> TradeBuyCapital
		{
			get
			{
				return this._TradeBuyCapital;
			}
			set
			{
				if ((this._TradeBuyCapital != value))
				{
					this._TradeBuyCapital = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TradeSellCapital", DbType="Decimal(0,0)")]
		public System.Nullable<decimal> TradeSellCapital
		{
			get
			{
				return this._TradeSellCapital;
			}
			set
			{
				if ((this._TradeSellCapital != value))
				{
					this._TradeSellCapital = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OpenBuyQty", DbType="Int")]
		public System.Nullable<int> OpenBuyQty
		{
			get
			{
				return this._OpenBuyQty;
			}
			set
			{
				if ((this._OpenBuyQty != value))
				{
					this._OpenBuyQty = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OpenSellQty", DbType="Int")]
		public System.Nullable<int> OpenSellQty
		{
			get
			{
				return this._OpenSellQty;
			}
			set
			{
				if ((this._OpenSellQty != value))
				{
					this._OpenSellQty = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BrokerID", DbType="Int NOT NULL")]
		public int BrokerID
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
	}
}
#pragma warning restore 1591
