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
	public partial class dbMan_BO_GetDeliveryUnitDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public dbMan_BO_GetDeliveryUnitDataContext() : 
				base(global::LtechIndia.BackOffice.BOEngine.DAL.Properties.Settings.Default.BOExchangeConnectionString1, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_GetDeliveryUnitDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_GetDeliveryUnitDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_GetDeliveryUnitDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_GetDeliveryUnitDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.BO_GetDeliveryUnit")]
		public ISingleResult<BO_GetDeliveryUnitResult> BO_GetDeliveryUnit()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<BO_GetDeliveryUnitResult>)(result.ReturnValue));
		}
	}
	
	public partial class BO_GetDeliveryUnitResult
	{
		
		private string _Unit;
		
		public BO_GetDeliveryUnitResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Unit", DbType="VarChar(3)")]
		public string Unit
		{
			get
			{
				return this._Unit;
			}
			set
			{
				if ((this._Unit != value))
				{
					this._Unit = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
