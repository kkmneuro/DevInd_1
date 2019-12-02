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
	public partial class dbMan_BO_FeesMasterSelectDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public dbMan_BO_FeesMasterSelectDataContext() : 
				base(global::LtechIndia.BackOffice.BOEngine.DAL.Properties.Settings.Default.BOExchange_NGConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_FeesMasterSelectDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_FeesMasterSelectDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_FeesMasterSelectDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_FeesMasterSelectDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.BO_FeesMasterSelect")]
		public ISingleResult<BO_FeesMasterSelectResult> BO_FeesMasterSelect()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<BO_FeesMasterSelectResult>)(result.ReturnValue));
		}
	}
	
	public partial class BO_FeesMasterSelectResult
	{
		
		private int _PK_FeeID;
		
		private string _FeeName;
		
		private System.Nullable<decimal> _MinimumFeeValue;
		
		private System.Nullable<decimal> _MaximunFeeValue;
		
		private string _Interval;
		
		private System.Nullable<bool> _IsTaxable;
		
		private string _Description;
		
		private string _FeesMode;
		
		private string _LevyOn;
		
		private string _Days;
		
		public BO_FeesMasterSelectResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PK_FeeID", DbType="Int NOT NULL")]
		public int PK_FeeID
		{
			get
			{
				return this._PK_FeeID;
			}
			set
			{
				if ((this._PK_FeeID != value))
				{
					this._PK_FeeID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FeeName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string FeeName
		{
			get
			{
				return this._FeeName;
			}
			set
			{
				if ((this._FeeName != value))
				{
					this._FeeName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MinimumFeeValue", DbType="Decimal(18,5)")]
		public System.Nullable<decimal> MinimumFeeValue
		{
			get
			{
				return this._MinimumFeeValue;
			}
			set
			{
				if ((this._MinimumFeeValue != value))
				{
					this._MinimumFeeValue = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaximunFeeValue", DbType="Decimal(18,5)")]
		public System.Nullable<decimal> MaximunFeeValue
		{
			get
			{
				return this._MaximunFeeValue;
			}
			set
			{
				if ((this._MaximunFeeValue != value))
				{
					this._MaximunFeeValue = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Interval", DbType="VarChar(50)")]
		public string Interval
		{
			get
			{
				return this._Interval;
			}
			set
			{
				if ((this._Interval != value))
				{
					this._Interval = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsTaxable", DbType="Bit")]
		public System.Nullable<bool> IsTaxable
		{
			get
			{
				return this._IsTaxable;
			}
			set
			{
				if ((this._IsTaxable != value))
				{
					this._IsTaxable = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="VarChar(256)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FeesMode", DbType="VarChar(20)")]
		public string FeesMode
		{
			get
			{
				return this._FeesMode;
			}
			set
			{
				if ((this._FeesMode != value))
				{
					this._FeesMode = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LevyOn", DbType="VarChar(50)")]
		public string LevyOn
		{
			get
			{
				return this._LevyOn;
			}
			set
			{
				if ((this._LevyOn != value))
				{
					this._LevyOn = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Days", DbType="VarChar(15)")]
		public string Days
		{
			get
			{
				return this._Days;
			}
			set
			{
				if ((this._Days != value))
				{
					this._Days = value;
				}
			}
		}
	}
}
#pragma warning restore 1591