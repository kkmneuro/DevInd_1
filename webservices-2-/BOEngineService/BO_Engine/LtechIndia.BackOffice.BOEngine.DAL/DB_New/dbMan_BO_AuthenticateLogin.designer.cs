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
	public partial class dbMan_BO_AuthenticateLoginDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public dbMan_BO_AuthenticateLoginDataContext() : 
				base(global::LtechIndia.BackOffice.BOEngine.DAL.Properties.Settings.Default.BOExchange_NGConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_AuthenticateLoginDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_AuthenticateLoginDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_AuthenticateLoginDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_AuthenticateLoginDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.BO_AuthenticateLogin")]
		public int BO_AuthenticateLogin([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(50)")] string loginId, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(50)")] string pwd, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] ref System.Nullable<int> brokerid, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(64)")] ref string role, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="AccountGroupName", DbType="VarChar(50)")] ref string accountGroupName, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="AccountGroupID", DbType="Int")] ref System.Nullable<int> accountGroupID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="BrokerCompany", DbType="VarChar(50)")] ref string brokerCompany, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IsEnable", DbType="Bit")] ref System.Nullable<bool> isEnable)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), loginId, pwd, brokerid, role, accountGroupName, accountGroupID, brokerCompany, isEnable);
			brokerid = ((System.Nullable<int>)(result.GetParameterValue(2)));
			role = ((string)(result.GetParameterValue(3)));
			accountGroupName = ((string)(result.GetParameterValue(4)));
			accountGroupID = ((System.Nullable<int>)(result.GetParameterValue(5)));
			brokerCompany = ((string)(result.GetParameterValue(6)));
			isEnable = ((System.Nullable<bool>)(result.GetParameterValue(7)));
			return ((int)(result.ReturnValue));
		}
	}
}
#pragma warning restore 1591