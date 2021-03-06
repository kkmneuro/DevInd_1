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
	public partial class dbMan_Report_AccountTransReportDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public dbMan_Report_AccountTransReportDataContext() : 
				base(global::DataAcessLogic.Properties.Settings.Default.BOExchangeConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_Report_AccountTransReportDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_Report_AccountTransReportDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_Report_AccountTransReportDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_Report_AccountTransReportDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.Report_AccountTransaction")]
		public ISingleResult<Report_AccountTransactionResult> Report_AccountTransaction([global::System.Data.Linq.Mapping.ParameterAttribute(Name="FromDate", DbType="DateTime")] System.Nullable<System.DateTime> fromDate, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ToDate", DbType="DateTime")] System.Nullable<System.DateTime> toDate, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="AccountID", DbType="Int")] System.Nullable<int> accountID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="BrokerID", DbType="Int")] System.Nullable<int> brokerID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ParentBrokerID", DbType="Int")] System.Nullable<int> parentBrokerID)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), fromDate, toDate, accountID, brokerID, parentBrokerID);
			return ((ISingleResult<Report_AccountTransactionResult>)(result.ReturnValue));
		}
	}
	
	public partial class Report_AccountTransactionResult
	{
		
		private System.Nullable<int> _Account_ID;
		
		private System.Nullable<decimal> _Amount;
		
		private string _PaymentType;
		
		private string _PaymentMode;
		
		private System.Nullable<System.DateTime> _PaymentDate;
		
		private string _Cheque_FD_No;
		
		private string _Remark;
		
		public Report_AccountTransactionResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Account_ID", DbType="Int")]
		public System.Nullable<int> Account_ID
		{
			get
			{
				return this._Account_ID;
			}
			set
			{
				if ((this._Account_ID != value))
				{
					this._Account_ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Amount", DbType="Decimal(0,0)")]
		public System.Nullable<decimal> Amount
		{
			get
			{
				return this._Amount;
			}
			set
			{
				if ((this._Amount != value))
				{
					this._Amount = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PaymentType", DbType="VarChar(50)")]
		public string PaymentType
		{
			get
			{
				return this._PaymentType;
			}
			set
			{
				if ((this._PaymentType != value))
				{
					this._PaymentType = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PaymentMode", DbType="VarChar(50)")]
		public string PaymentMode
		{
			get
			{
				return this._PaymentMode;
			}
			set
			{
				if ((this._PaymentMode != value))
				{
					this._PaymentMode = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PaymentDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> PaymentDate
		{
			get
			{
				return this._PaymentDate;
			}
			set
			{
				if ((this._PaymentDate != value))
				{
					this._PaymentDate = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cheque_FD_No", DbType="VarChar(17)")]
		public string Cheque_FD_No
		{
			get
			{
				return this._Cheque_FD_No;
			}
			set
			{
				if ((this._Cheque_FD_No != value))
				{
					this._Cheque_FD_No = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Remark", DbType="VarChar(256)")]
		public string Remark
		{
			get
			{
				return this._Remark;
			}
			set
			{
				if ((this._Remark != value))
				{
					this._Remark = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
