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
	public partial class dbMan_BO_HolidayUpdateDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public dbMan_BO_HolidayUpdateDataContext() : 
				base(global::LtechIndia.BackOffice.BOEngine.DAL.Properties.Settings.Default.BOExchangeConnectionString1, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_HolidayUpdateDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_HolidayUpdateDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_HolidayUpdateDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_HolidayUpdateDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.BO_HolidayUpdate")]
		public int BO_HolidayUpdate([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ID", DbType="Int")] System.Nullable<int> iD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Date")] System.Nullable<System.DateTime> date, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="FromTime", DbType="VarChar(50)")] string fromTime, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ToTime", DbType="VarChar(50)")] string toTime, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Instrument", DbType="VarChar(50)")] string instrument, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IsEnable", DbType="Bit")] System.Nullable<bool> isEnable, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IsEveryYear", DbType="Bit")] System.Nullable<bool> isEveryYear, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(256)")] string descp)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iD, date, fromTime, toTime, instrument, isEnable, isEveryYear, descp);
			return ((int)(result.ReturnValue));
		}
	}
}
#pragma warning restore 1591