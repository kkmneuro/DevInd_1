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
	public partial class dbMan_BO_UpdateSymbolDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public dbMan_BO_UpdateSymbolDataContext() : 
				base(global::LtechIndia.BackOffice.BOEngine.DAL.Properties.Settings.Default.BOExchange_NGConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_UpdateSymbolDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_UpdateSymbolDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_UpdateSymbolDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_UpdateSymbolDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.BO_UpdateSymbol")]
		public int BO_UpdateSymbol(
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="Instruementid", DbType="Int")] System.Nullable<int> instruementid, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="SymbolName", DbType="VarChar(50)")] string symbolName, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="Description", DbType="VarChar(100)")] string description, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="Source", DbType="VarChar(50)")] string source, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="Digits", DbType="Int")] System.Nullable<int> digits, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="TradingCurrency", DbType="Int")] System.Nullable<int> tradingCurrency, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="SettlingCurrency", DbType="Int")] System.Nullable<int> settlingCurrency, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="MarginCurrency", DbType="Int")] System.Nullable<int> marginCurrency, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="Spread", DbType="Int")] System.Nullable<int> spread, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="MaximumLots", DbType="Int")] System.Nullable<int> maximumLots, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="MaximumOrderValue", DbType="Int")] System.Nullable<int> maximumOrderValue, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="BuySideTurnover", DbType="Decimal")] System.Nullable<decimal> buySideTurnover, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="SellSideTurnover", DbType="Decimal")] System.Nullable<decimal> sellSideTurnover, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="MaximumAllowablePosition", DbType="Int")] System.Nullable<int> maximumAllowablePosition, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="Hedged", DbType="Int")] System.Nullable<int> hedged, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="LimitandStopLevel", DbType="Int")] System.Nullable<int> limitandStopLevel, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="TickSize", DbType="Int")] System.Nullable<int> tickSize, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="TickPrice", DbType="Int")] System.Nullable<int> tickPrice, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="ContractSize", DbType="Int")] System.Nullable<int> contractSize, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="QuotationBaseValue", DbType="Int")] System.Nullable<int> quotationBaseValue, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="Maintenance", DbType="Int")] System.Nullable<int> maintenance, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="DeliveryType", DbType="Int")] System.Nullable<int> deliveryType, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="DeliveryUnit", DbType="Int")] System.Nullable<int> deliveryUnit, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="DeliveryQuantity", DbType="Int")] System.Nullable<int> deliveryQuantity, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="MarketLot", DbType="Int")] System.Nullable<int> marketLot, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="Expirydatetime", DbType="DateTime")] System.Nullable<System.DateTime> expirydatetime, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="Startdatetime", DbType="DateTime")] System.Nullable<System.DateTime> startdatetime, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="Enddatetime", DbType="DateTime")] System.Nullable<System.DateTime> enddatetime, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="TenderStartdatetime", DbType="DateTime")] System.Nullable<System.DateTime> tenderStartdatetime, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="TenderEnddatetime", DbType="DateTime")] System.Nullable<System.DateTime> tenderEnddatetime, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="DeliveryStartdatetime", DbType="DateTime")] System.Nullable<System.DateTime> deliveryStartdatetime, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="DeliveryEnddatetime", DbType="DateTime")] System.Nullable<System.DateTime> deliveryEnddatetime, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="DPRInitialPercentage", DbType="Int")] System.Nullable<int> dPRInitialPercentage, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="DPRInterval", DbType="Int")] System.Nullable<int> dPRInterval, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="InitialBuyMargin", DbType="Int")] System.Nullable<int> initialBuyMargin, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="InitialSellMargin", DbType="Int")] System.Nullable<int> initialSellMargin, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="MaintenanceBuyMargin", DbType="Int")] System.Nullable<int> maintenanceBuyMargin, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="MaintenanceSellMargin", DbType="Int")] System.Nullable<int> maintenanceSellMargin, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="ULAssest", DbType="VarChar(20)")] string uLAssest, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="DPRRangeHigher", DbType="Int")] System.Nullable<int> dPRRangeHigher, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="FKSecurityTypeID", DbType="Int")] System.Nullable<int> fKSecurityTypeID, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="OffQuoteTimeLimitInSec", DbType="Int")] System.Nullable<int> offQuoteTimeLimitInSec, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="MarketLostUnit", DbType="Int")] System.Nullable<int> marketLostUnit, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="MaximumLostUnit", DbType="Int")] System.Nullable<int> maximumLostUnit, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="QuotationBaseValueUnit", DbType="Int")] System.Nullable<int> quotationBaseValueUnit)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), instruementid, symbolName, description, source, digits, tradingCurrency, settlingCurrency, marginCurrency, spread, maximumLots, maximumOrderValue, buySideTurnover, sellSideTurnover, maximumAllowablePosition, hedged, limitandStopLevel, tickSize, tickPrice, contractSize, quotationBaseValue, maintenance, deliveryType, deliveryUnit, deliveryQuantity, marketLot, expirydatetime, startdatetime, enddatetime, tenderStartdatetime, tenderEnddatetime, deliveryStartdatetime, deliveryEnddatetime, dPRInitialPercentage, dPRInterval, initialBuyMargin, initialSellMargin, maintenanceBuyMargin, maintenanceSellMargin, uLAssest, dPRRangeHigher, fKSecurityTypeID, offQuoteTimeLimitInSec, marketLostUnit, maximumLostUnit, quotationBaseValueUnit);
			return ((int)(result.ReturnValue));
		}
	}
}
#pragma warning restore 1591
