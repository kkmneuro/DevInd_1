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
	public partial class dbMan_BO_UpdateInstrumentSwapDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public dbMan_BO_UpdateInstrumentSwapDataContext() : 
				base(global::LtechIndia.BackOffice.BOEngine.DAL.Properties.Settings.Default.BOExchange_NGConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_UpdateInstrumentSwapDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_UpdateInstrumentSwapDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_UpdateInstrumentSwapDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_UpdateInstrumentSwapDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.BO_UpdateInstrumentSwaps")]
		public int BO_UpdateInstrumentSwaps([global::System.Data.Linq.Mapping.ParameterAttribute(Name="InstrumentId", DbType="Int")] System.Nullable<int> instrumentId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="LongPosition", DbType="Decimal(18,5)")] System.Nullable<decimal> longPosition, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ShortPosition", DbType="Decimal(18,5)")] System.Nullable<decimal> shortPosition, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IsEnable", DbType="Bit")] System.Nullable<bool> isEnable)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), instrumentId, longPosition, shortPosition, isEnable);
			return ((int)(result.ReturnValue));
		}
	}
}
#pragma warning restore 1591
