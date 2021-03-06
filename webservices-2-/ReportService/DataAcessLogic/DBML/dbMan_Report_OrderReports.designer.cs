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
	public partial class dbMan_Report_OrderReportsDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public dbMan_Report_OrderReportsDataContext() : 
				base(global::DataAcessLogic.Properties.Settings.Default.BOExchangeConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_Report_OrderReportsDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_Report_OrderReportsDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_Report_OrderReportsDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_Report_OrderReportsDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.Report_OrderReports1")]
		public ISingleResult<Report_OrderReports1Result> Report_OrderReports1([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="BigInt")] System.Nullable<long> orderid, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="AccountID", DbType="Int")] System.Nullable<int> accountID, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="DateTime")] System.Nullable<System.DateTime> fromdate, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="DateTime")] System.Nullable<System.DateTime> todate, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="OrderType", DbType="VarChar(50)")] string orderType, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="OrderSide", DbType="Char(10)")] string orderSide, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="BrokerID", DbType="Int")] System.Nullable<int> brokerID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Symbol", DbType="VarChar(20)")] string symbol, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ParentBrokerID", DbType="Int")] System.Nullable<int> parentBrokerID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="TIF_ID", DbType="Int")] System.Nullable<int> tIF_ID)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), orderid, accountID, fromdate, todate, orderType, orderSide, brokerID, symbol, parentBrokerID, tIF_ID);
			return ((ISingleResult<Report_OrderReports1Result>)(result.ReturnValue));
		}
	}
	
	public partial class Report_OrderReports1Result
	{
		
		private int _AccountID;
		
		private string _BrokerName;
		
		private int _BrokerID;
		
		private long _OrderID;
		
		private int _SymbolID;
		
		private string _Symbol;
		
		private int _FK_OrderType;
		
		private string _OrderType;
		
		private string _Buy_Sell;
		
		private System.Nullable<long> _OrdQty;
		
		private int _ExecuQty;
		
		private System.Nullable<long> _Price;
		
		private System.Nullable<System.DateTime> _OrdDate_TimeRequested;
		
		private int _OrderStatusID;
		
		private string _OrderStatus;
		
		private System.Nullable<decimal> _AvgFillPrice;
		
		private System.Nullable<decimal> _Commission;
		
		private System.Nullable<decimal> _Tax;
		
		private string _Validity;
		
		public Report_OrderReports1Result()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AccountID", DbType="Int NOT NULL")]
		public int AccountID
		{
			get
			{
				return this._AccountID;
			}
			set
			{
				if ((this._AccountID != value))
				{
					this._AccountID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BrokerName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OrderID", DbType="BigInt NOT NULL")]
		public long OrderID
		{
			get
			{
				return this._OrderID;
			}
			set
			{
				if ((this._OrderID != value))
				{
					this._OrderID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SymbolID", DbType="Int NOT NULL")]
		public int SymbolID
		{
			get
			{
				return this._SymbolID;
			}
			set
			{
				if ((this._SymbolID != value))
				{
					this._SymbolID = value;
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FK_OrderType", DbType="Int NOT NULL")]
		public int FK_OrderType
		{
			get
			{
				return this._FK_OrderType;
			}
			set
			{
				if ((this._FK_OrderType != value))
				{
					this._FK_OrderType = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OrderType", DbType="VarChar(50)")]
		public string OrderType
		{
			get
			{
				return this._OrderType;
			}
			set
			{
				if ((this._OrderType != value))
				{
					this._OrderType = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Buy/Sell]", Storage="_Buy_Sell", DbType="VarChar(10)")]
		public string Buy_Sell
		{
			get
			{
				return this._Buy_Sell;
			}
			set
			{
				if ((this._Buy_Sell != value))
				{
					this._Buy_Sell = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OrdQty", DbType="BigInt")]
		public System.Nullable<long> OrdQty
		{
			get
			{
				return this._OrdQty;
			}
			set
			{
				if ((this._OrdQty != value))
				{
					this._OrdQty = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ExecuQty", DbType="Int NOT NULL")]
		public int ExecuQty
		{
			get
			{
				return this._ExecuQty;
			}
			set
			{
				if ((this._ExecuQty != value))
				{
					this._ExecuQty = value;
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[OrdDate/TimeRequested]", Storage="_OrdDate_TimeRequested", DbType="DateTime")]
		public System.Nullable<System.DateTime> OrdDate_TimeRequested
		{
			get
			{
				return this._OrdDate_TimeRequested;
			}
			set
			{
				if ((this._OrdDate_TimeRequested != value))
				{
					this._OrdDate_TimeRequested = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OrderStatusID", DbType="Int NOT NULL")]
		public int OrderStatusID
		{
			get
			{
				return this._OrderStatusID;
			}
			set
			{
				if ((this._OrderStatusID != value))
				{
					this._OrderStatusID = value;
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AvgFillPrice", DbType="Decimal(0,0)")]
		public System.Nullable<decimal> AvgFillPrice
		{
			get
			{
				return this._AvgFillPrice;
			}
			set
			{
				if ((this._AvgFillPrice != value))
				{
					this._AvgFillPrice = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Commission", DbType="Decimal(0,0)")]
		public System.Nullable<decimal> Commission
		{
			get
			{
				return this._Commission;
			}
			set
			{
				if ((this._Commission != value))
				{
					this._Commission = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Tax", DbType="Decimal(0,0)")]
		public System.Nullable<decimal> Tax
		{
			get
			{
				return this._Tax;
			}
			set
			{
				if ((this._Tax != value))
				{
					this._Tax = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Validity", DbType="VarChar(50)")]
		public string Validity
		{
			get
			{
				return this._Validity;
			}
			set
			{
				if ((this._Validity != value))
				{
					this._Validity = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
