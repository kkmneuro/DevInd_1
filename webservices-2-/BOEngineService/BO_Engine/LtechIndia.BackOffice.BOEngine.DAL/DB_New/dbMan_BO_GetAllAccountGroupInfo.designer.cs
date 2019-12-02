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
	public partial class dbMan_BO_GetAllAccountGroupInfoDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public dbMan_BO_GetAllAccountGroupInfoDataContext() : 
				base(global::LtechIndia.BackOffice.BOEngine.DAL.Properties.Settings.Default.BOExchange_NGConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_GetAllAccountGroupInfoDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_GetAllAccountGroupInfoDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_GetAllAccountGroupInfoDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_GetAllAccountGroupInfoDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.BO_GetAllAccountGroupInfo")]
		public ISingleResult<BO_GetAllAccountGroupInfoResult> BO_GetAllAccountGroupInfo()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<BO_GetAllAccountGroupInfoResult>)(result.ReturnValue));
		}
	}
	
	public partial class BO_GetAllAccountGroupInfoResult
	{
		
		private int _AccountGroupID;
		
		private string _AccountGroupName;
		
		private string _Owner;
		
		private int _FK_LeverageID;
		
		private System.Nullable<decimal> _Charges;
		
		private System.Nullable<bool> _IsEnable;
		
		private System.Nullable<int> _FK_BrokerTypeID;
		
		private string _BrokerAddress;
		
		private string _BrokerCity;
		
		private string _BrokerState;
		
		private string _BrokerPhone1;
		
		private string _BrokerPhone2;
		
		private string _BrokerFax;
		
		private string _BrokerEmail;
		
		private System.Nullable<int> _ParentAccountGroupID;
		
		private string _Password;
		
		public BO_GetAllAccountGroupInfoResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AccountGroupID", DbType="Int NOT NULL")]
		public int AccountGroupID
		{
			get
			{
				return this._AccountGroupID;
			}
			set
			{
				if ((this._AccountGroupID != value))
				{
					this._AccountGroupID = value;
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FK_LeverageID", DbType="Int NOT NULL")]
		public int FK_LeverageID
		{
			get
			{
				return this._FK_LeverageID;
			}
			set
			{
				if ((this._FK_LeverageID != value))
				{
					this._FK_LeverageID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Charges", DbType="Decimal(18,5)")]
		public System.Nullable<decimal> Charges
		{
			get
			{
				return this._Charges;
			}
			set
			{
				if ((this._Charges != value))
				{
					this._Charges = value;
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BrokerAddress", DbType="VarChar(256)")]
		public string BrokerAddress
		{
			get
			{
				return this._BrokerAddress;
			}
			set
			{
				if ((this._BrokerAddress != value))
				{
					this._BrokerAddress = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BrokerCity", DbType="VarChar(50)")]
		public string BrokerCity
		{
			get
			{
				return this._BrokerCity;
			}
			set
			{
				if ((this._BrokerCity != value))
				{
					this._BrokerCity = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BrokerState", DbType="VarChar(50)")]
		public string BrokerState
		{
			get
			{
				return this._BrokerState;
			}
			set
			{
				if ((this._BrokerState != value))
				{
					this._BrokerState = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BrokerPhone1", DbType="VarChar(20)")]
		public string BrokerPhone1
		{
			get
			{
				return this._BrokerPhone1;
			}
			set
			{
				if ((this._BrokerPhone1 != value))
				{
					this._BrokerPhone1 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BrokerPhone2", DbType="VarChar(20)")]
		public string BrokerPhone2
		{
			get
			{
				return this._BrokerPhone2;
			}
			set
			{
				if ((this._BrokerPhone2 != value))
				{
					this._BrokerPhone2 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BrokerFax", DbType="VarChar(20)")]
		public string BrokerFax
		{
			get
			{
				return this._BrokerFax;
			}
			set
			{
				if ((this._BrokerFax != value))
				{
					this._BrokerFax = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BrokerEmail", DbType="VarChar(50)")]
		public string BrokerEmail
		{
			get
			{
				return this._BrokerEmail;
			}
			set
			{
				if ((this._BrokerEmail != value))
				{
					this._BrokerEmail = value;
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="VarChar(50)")]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this._Password = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
