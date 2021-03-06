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
	public partial class dbMan_BO_GetBrokersCollateralInfoDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public dbMan_BO_GetBrokersCollateralInfoDataContext() : 
				base(global::LtechIndia.BackOffice.BOEngine.DAL.Properties.Settings.Default.BOExchangeConnectionString1, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_GetBrokersCollateralInfoDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_GetBrokersCollateralInfoDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_GetBrokersCollateralInfoDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_GetBrokersCollateralInfoDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.BO_GetBrokersCollateralInfo")]
		public ISingleResult<BO_GetBrokersCollateralInfoResult> BO_GetBrokersCollateralInfo()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<BO_GetBrokersCollateralInfoResult>)(result.ReturnValue));
		}
	}
	
	public partial class BO_GetBrokersCollateralInfoResult
	{
		
		private int _PK_AccountGroupID;
		
		private string _AccountGroupName;
		
		private string _Owner;
		
		private string _Leverage;
		
		private System.Nullable<int> _ParentAccountGroupID;
		
		private string _ParentOwner;
		
		private System.Nullable<decimal> _TotalCollateral;
		
		private System.Nullable<decimal> _Unallocated;
		
		private System.Nullable<decimal> _Utilized;
		
		private System.Nullable<decimal> _PayInShortage;
		
		private System.Nullable<decimal> _PayOutShortage;
		
		private System.Nullable<decimal> _CollateralforTrading;
		
		private System.Nullable<bool> _IsEnable;
		
		private string _BrokerType;
		
		private System.Nullable<int> _FK_BrokerTypeID;
		
		public BO_GetBrokersCollateralInfoResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PK_AccountGroupID", DbType="Int NOT NULL")]
		public int PK_AccountGroupID
		{
			get
			{
				return this._PK_AccountGroupID;
			}
			set
			{
				if ((this._PK_AccountGroupID != value))
				{
					this._PK_AccountGroupID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AccountGroupName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string AccountGroupName
		{
			get
			{
				return this._AccountGroupName;
			}
			set
			{
				if ((this._AccountGroupName != value))
				{
					this._AccountGroupName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Owner", DbType="VarChar(50)")]
		public string Owner
		{
			get
			{
				return this._Owner;
			}
			set
			{
				if ((this._Owner != value))
				{
					this._Owner = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Leverage", DbType="VarChar(20)")]
		public string Leverage
		{
			get
			{
				return this._Leverage;
			}
			set
			{
				if ((this._Leverage != value))
				{
					this._Leverage = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ParentAccountGroupID", DbType="Int")]
		public System.Nullable<int> ParentAccountGroupID
		{
			get
			{
				return this._ParentAccountGroupID;
			}
			set
			{
				if ((this._ParentAccountGroupID != value))
				{
					this._ParentAccountGroupID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ParentOwner", DbType="VarChar(50)")]
		public string ParentOwner
		{
			get
			{
				return this._ParentOwner;
			}
			set
			{
				if ((this._ParentOwner != value))
				{
					this._ParentOwner = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TotalCollateral", DbType="Decimal(0,0)")]
		public System.Nullable<decimal> TotalCollateral
		{
			get
			{
				return this._TotalCollateral;
			}
			set
			{
				if ((this._TotalCollateral != value))
				{
					this._TotalCollateral = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Unallocated", DbType="Decimal(0,0)")]
		public System.Nullable<decimal> Unallocated
		{
			get
			{
				return this._Unallocated;
			}
			set
			{
				if ((this._Unallocated != value))
				{
					this._Unallocated = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Utilized", DbType="Decimal(0,0)")]
		public System.Nullable<decimal> Utilized
		{
			get
			{
				return this._Utilized;
			}
			set
			{
				if ((this._Utilized != value))
				{
					this._Utilized = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PayInShortage", DbType="Decimal(0,0)")]
		public System.Nullable<decimal> PayInShortage
		{
			get
			{
				return this._PayInShortage;
			}
			set
			{
				if ((this._PayInShortage != value))
				{
					this._PayInShortage = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PayOutShortage", DbType="Decimal(0,0)")]
		public System.Nullable<decimal> PayOutShortage
		{
			get
			{
				return this._PayOutShortage;
			}
			set
			{
				if ((this._PayOutShortage != value))
				{
					this._PayOutShortage = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CollateralforTrading", DbType="Decimal(0,0)")]
		public System.Nullable<decimal> CollateralforTrading
		{
			get
			{
				return this._CollateralforTrading;
			}
			set
			{
				if ((this._CollateralforTrading != value))
				{
					this._CollateralforTrading = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsEnable", DbType="Bit")]
		public System.Nullable<bool> IsEnable
		{
			get
			{
				return this._IsEnable;
			}
			set
			{
				if ((this._IsEnable != value))
				{
					this._IsEnable = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BrokerType", DbType="Char(10)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FK_BrokerTypeID", DbType="Int")]
		public System.Nullable<int> FK_BrokerTypeID
		{
			get
			{
				return this._FK_BrokerTypeID;
			}
			set
			{
				if ((this._FK_BrokerTypeID != value))
				{
					this._FK_BrokerTypeID = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
