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
	public partial class dbMan_BO_UpdateTradingGateWayInfoDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public dbMan_BO_UpdateTradingGateWayInfoDataContext() : 
				base(global::LtechIndia.BackOffice.BOEngine.DAL.Properties.Settings.Default.BOExchange_NGConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_UpdateTradingGateWayInfoDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_UpdateTradingGateWayInfoDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_UpdateTradingGateWayInfoDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_UpdateTradingGateWayInfoDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.BO_UpdateTradingGateWayInfo")]
		public int BO_UpdateTradingGateWayInfo(
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="PKTradingGateWaysID", DbType="Int")] System.Nullable<int> pKTradingGateWaysID, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="Name", DbType="VarChar(50)")] string name, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="Description", DbType="VarChar(256)")] string description, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="ServerIP", DbType="VarChar(20)")] string serverIP, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="Port", DbType="Int")] System.Nullable<int> port, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="DataTypes", DbType="VarChar(50)")] string dataTypes, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(50)")] string login, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(50)")] string password, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="IdleTimeOut", DbType="Int")] System.Nullable<int> idleTimeOut, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> reconnectAfter, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="SleepFor", DbType="Int")] System.Nullable<int> sleepFor, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> attempts, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="IsEnable", DbType="Bit")] System.Nullable<bool> isEnable, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="Enable_RMS", DbType="Bit")] System.Nullable<bool> enable_RMS, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="Order_Port", DbType="Int")] System.Nullable<int> order_Port, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="Order_IP", DbType="VarChar(50)")] string order_IP)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), pKTradingGateWaysID, name, description, serverIP, port, dataTypes, login, password, idleTimeOut, reconnectAfter, sleepFor, attempts, isEnable, enable_RMS, order_Port, order_IP);
			return ((int)(result.ReturnValue));
		}
	}
}
#pragma warning restore 1591
