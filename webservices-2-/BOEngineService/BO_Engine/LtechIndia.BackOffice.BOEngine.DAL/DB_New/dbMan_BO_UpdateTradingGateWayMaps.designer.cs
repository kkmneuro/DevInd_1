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
	public partial class dbMan_BO_UpdateTradingGateWayMapsDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public dbMan_BO_UpdateTradingGateWayMapsDataContext() : 
				base(global::LtechIndia.BackOffice.BOEngine.DAL.Properties.Settings.Default.BOExchange_NGConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_UpdateTradingGateWayMapsDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_UpdateTradingGateWayMapsDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_UpdateTradingGateWayMapsDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_UpdateTradingGateWayMapsDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.BO_UpdateTradingGateWaySymbolMapsInfo")]
		public int BO_UpdateTradingGateWaySymbolMapsInfo([global::System.Data.Linq.Mapping.ParameterAttribute(Name="TradingGateWayID", DbType="Int")] System.Nullable<int> tradingGateWayID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Instrument", DbType="VarChar(50)")] string instrument, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="SymbolAlias", DbType="VarChar(50)")] string symbolAlias, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="SymbolConversionFormula", DbType="Decimal(18,2)")] System.Nullable<decimal> symbolConversionFormula, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="PoductName", DbType="VarChar(20)")] string poductName, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="PoductAlias", DbType="VarChar(20)")] string poductAlias)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), tradingGateWayID, instrument, symbolAlias, symbolConversionFormula, poductName, poductAlias);
			return ((int)(result.ReturnValue));
		}
	}
}
#pragma warning restore 1591