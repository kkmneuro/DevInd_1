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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="OMSExchange")]
	public partial class dbMan_OMS_OrderUpdateDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public dbMan_OMS_OrderUpdateDataContext() : 
				base(global::LtechIndia.BackOffice.BOEngine.DAL.Properties.Settings.Default.OMSExchangeConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_OMS_OrderUpdateDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_OMS_OrderUpdateDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_OMS_OrderUpdateDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_OMS_OrderUpdateDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.OMS_OrdersUpdate")]
		public int OMS_OrdersUpdate([global::System.Data.Linq.Mapping.ParameterAttribute(Name="OrderID", DbType="Int")] System.Nullable<int> orderID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="AccountID", DbType="Int")] System.Nullable<int> accountID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="OrderTime", DbType="DateTime")] System.Nullable<System.DateTime> orderTime, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Side", DbType="VarChar(10)")] string side, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="PositionSize", DbType="Int")] System.Nullable<int> positionSize, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="SymbolID", DbType="Int")] System.Nullable<int> symbolID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="OrderType", DbType="VarChar(20)")] string orderType, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="OrderPrice", DbType="Int")] System.Nullable<int> orderPrice, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="TriggerPrice", DbType="Int")] System.Nullable<int> triggerPrice, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Comment", DbType="VarChar(20)")] string comment, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="OrderStatus", DbType="VarChar(20)")] string orderStatus, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Validity", DbType="DateTime")] System.Nullable<System.DateTime> validity)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), orderID, accountID, orderTime, side, positionSize, symbolID, orderType, orderPrice, triggerPrice, comment, orderStatus, validity);
			return ((int)(result.ReturnValue));
		}
	}
}
#pragma warning restore 1591
