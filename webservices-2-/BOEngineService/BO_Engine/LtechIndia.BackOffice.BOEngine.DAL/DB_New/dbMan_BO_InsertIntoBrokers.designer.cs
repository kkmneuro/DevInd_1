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
	public partial class dbMan_BO_InsertIntoBrokersDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public dbMan_BO_InsertIntoBrokersDataContext() : 
				base(global::LtechIndia.BackOffice.BOEngine.DAL.Properties.Settings.Default.BOExchangeConnectionString1, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_InsertIntoBrokersDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_InsertIntoBrokersDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_InsertIntoBrokersDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_InsertIntoBrokersDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.BO_InsertInToBrokers")]
		public int BO_InsertInToBrokers(
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="Name", DbType="VarChar(50)")] string name, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="Owner", DbType="VarChar(50)")] string owner, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="Leverage", DbType="VarChar(20)")] string leverage, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="State", DbType="VarChar(50)")] string state, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="IsEnable", DbType="Bit")] System.Nullable<bool> isEnable, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="BrokerType", DbType="Char(10)")] string brokerType, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="Address", DbType="VarChar(256)")] string address, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="City", DbType="VarChar(50)")] string city, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="Phone1", DbType="VarChar(20)")] string phone1, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="Phone2", DbType="VarChar(20)")] string phone2, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="Fax", DbType="VarChar(20)")] string fax, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="EMail", DbType="VarChar(50)")] string eMail, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="MarginCallLevel1", DbType="Int")] System.Nullable<int> marginCallLevel1, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="MarginCallLevel2", DbType="Int")] System.Nullable<int> marginCallLevel2, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="MarginCallLevel3", DbType="Int")] System.Nullable<int> marginCallLevel3, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="News", DbType="VarChar(50)")] string news, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="MaximumOrders", DbType="VarChar(256)")] string maximumOrders, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="Maximumsymbols", DbType="VarChar(256)")] string maximumsymbols, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="ParentBrokerID", DbType="Int")] System.Nullable<int> parentBrokerID, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="RoleName", DbType="VarChar(50)")] string roleName, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="Roles", DbType="VarChar(64)")] string roles, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="LoginId", DbType="VarChar(50)")] ref string loginId, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="ReturnRoleId", DbType="Int")] ref System.Nullable<int> returnRoleId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), name, owner, leverage, state, isEnable, brokerType, address, city, phone1, phone2, fax, eMail, marginCallLevel1, marginCallLevel2, marginCallLevel3, news, maximumOrders, maximumsymbols, parentBrokerID, roleName, roles, loginId, returnRoleId);
			loginId = ((string)(result.GetParameterValue(21)));
			returnRoleId = ((System.Nullable<int>)(result.GetParameterValue(22)));
			return ((int)(result.ReturnValue));
		}
	}
}
#pragma warning restore 1591
