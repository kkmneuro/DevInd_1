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
	public partial class dbMan_BO_InsertTGAccountConnectionSettingsDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public dbMan_BO_InsertTGAccountConnectionSettingsDataContext() : 
				base(global::LtechIndia.BackOffice.BOEngine.DAL.Properties.Settings.Default.BOExchangeConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_InsertTGAccountConnectionSettingsDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_InsertTGAccountConnectionSettingsDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_InsertTGAccountConnectionSettingsDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_InsertTGAccountConnectionSettingsDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.BO_InsertTGAccountConnectionSettings")]
		public int BO_InsertTGAccountConnectionSettings([global::System.Data.Linq.Mapping.ParameterAttribute(Name="TradingGatewayID", DbType="Int")] System.Nullable<int> tradingGatewayID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="AccountID", DbType="VarChar(50)")] string accountID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Password", DbType="VarChar(50)")] string password, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IsEnable", DbType="Bit")] System.Nullable<bool> isEnable)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), tradingGatewayID, accountID, password, isEnable);
			return ((int)(result.ReturnValue));
		}
	}
}
#pragma warning restore 1591
