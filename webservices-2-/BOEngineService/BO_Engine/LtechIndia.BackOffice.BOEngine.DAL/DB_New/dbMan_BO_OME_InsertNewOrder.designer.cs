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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="OME_ORDER")]
	public partial class dbMan_BO_OME_InsertNewOrderDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public dbMan_BO_OME_InsertNewOrderDataContext() : 
				base(global::LtechIndia.BackOffice.BOEngine.DAL.Properties.Settings.Default.OME_ORDERConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_OME_InsertNewOrderDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_OME_InsertNewOrderDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_OME_InsertNewOrderDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_OME_InsertNewOrderDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.BO_OME_InsertNewOrder")]
		public int BO_OME_InsertNewOrder([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ClOrdID", DbType="VarChar(20)")] string clOrdID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="AccountID", DbType="Int")] System.Nullable<int> accountID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="PositionSize", DbType="BigInt")] System.Nullable<long> positionSize, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Price", DbType="BigInt")] System.Nullable<long> price, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="OrderType", DbType="Char(1)")] System.Nullable<char> orderType, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="OrderStatusID", DbType="Char(1)")] System.Nullable<char> orderStatusID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Side", DbType="Char(1)")] System.Nullable<char> side, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Symbol", DbType="VarChar(20)")] string symbol, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="TIF", DbType="Char(1)")] System.Nullable<char> tIF, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IPAddress", DbType="VarChar(15)")] string iPAddress, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ExpireDate", DbType="DateTime")] System.Nullable<System.DateTime> expireDate)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), clOrdID, accountID, positionSize, price, orderType, orderStatusID, side, symbol, tIF, iPAddress, expireDate);
			return ((int)(result.ReturnValue));
		}
	}
}
#pragma warning restore 1591
