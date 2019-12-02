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
	public partial class dbMan_BO_GetVirtualDealerInfoDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public dbMan_BO_GetVirtualDealerInfoDataContext() : 
				base(global::LtechIndia.BackOffice.BOEngine.DAL.Properties.Settings.Default.BOExchange_NGConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_GetVirtualDealerInfoDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_GetVirtualDealerInfoDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_GetVirtualDealerInfoDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbMan_BO_GetVirtualDealerInfoDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.BO_GetVirtualDealers")]
		public ISingleResult<BO_GetVirtualDealersResult> BO_GetVirtualDealers()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<BO_GetVirtualDealersResult>)(result.ReturnValue));
		}
	}
	
	public partial class BO_GetVirtualDealersResult
	{
		
		private int _PK_VirtualDealerID;
		
		private System.Nullable<int> _Delay;
		
		private string _Virtual_Manager_Account;
		
		private string _Groups;
		
		private string _Symbols;
		
		private System.Nullable<decimal> _Max_Volume;
		
		private System.Nullable<int> _Max_Losing_Slippage;
		
		private System.Nullable<int> _Max_Profit_Slippage;
		
		private System.Nullable<int> _Max_Profit_Slippage_Volume;
		
		private System.Nullable<int> _Gap_Level;
		
		private System.Nullable<int> _Gap_Safe_Level;
		
		private System.Nullable<int> _Gap_Tick_Counter;
		
		private System.Nullable<int> _Gap_Pendings_Cancel;
		
		private System.Nullable<int> _Gap_Take_Profit_Slide;
		
		private System.Nullable<int> _Gap_Stop_Loss_Slide;
		
		private System.Nullable<int> _News_Stops_Freezes;
		
		private System.Nullable<int> _Allow_Pendings_On_News;
		
		public BO_GetVirtualDealersResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PK_VirtualDealerID", DbType="Int NOT NULL")]
		public int PK_VirtualDealerID
		{
			get
			{
				return this._PK_VirtualDealerID;
			}
			set
			{
				if ((this._PK_VirtualDealerID != value))
				{
					this._PK_VirtualDealerID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Delay", DbType="Int")]
		public System.Nullable<int> Delay
		{
			get
			{
				return this._Delay;
			}
			set
			{
				if ((this._Delay != value))
				{
					this._Delay = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Virtual_Manager_Account", DbType="VarChar(20)")]
		public string Virtual_Manager_Account
		{
			get
			{
				return this._Virtual_Manager_Account;
			}
			set
			{
				if ((this._Virtual_Manager_Account != value))
				{
					this._Virtual_Manager_Account = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Groups", DbType="VarChar(20)")]
		public string Groups
		{
			get
			{
				return this._Groups;
			}
			set
			{
				if ((this._Groups != value))
				{
					this._Groups = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Symbols", DbType="VarChar(20)")]
		public string Symbols
		{
			get
			{
				return this._Symbols;
			}
			set
			{
				if ((this._Symbols != value))
				{
					this._Symbols = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Max_Volume", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> Max_Volume
		{
			get
			{
				return this._Max_Volume;
			}
			set
			{
				if ((this._Max_Volume != value))
				{
					this._Max_Volume = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Max_Losing_Slippage", DbType="Int")]
		public System.Nullable<int> Max_Losing_Slippage
		{
			get
			{
				return this._Max_Losing_Slippage;
			}
			set
			{
				if ((this._Max_Losing_Slippage != value))
				{
					this._Max_Losing_Slippage = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Max_Profit_Slippage", DbType="Int")]
		public System.Nullable<int> Max_Profit_Slippage
		{
			get
			{
				return this._Max_Profit_Slippage;
			}
			set
			{
				if ((this._Max_Profit_Slippage != value))
				{
					this._Max_Profit_Slippage = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Max_Profit_Slippage_Volume", DbType="Int")]
		public System.Nullable<int> Max_Profit_Slippage_Volume
		{
			get
			{
				return this._Max_Profit_Slippage_Volume;
			}
			set
			{
				if ((this._Max_Profit_Slippage_Volume != value))
				{
					this._Max_Profit_Slippage_Volume = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Gap_Level", DbType="Int")]
		public System.Nullable<int> Gap_Level
		{
			get
			{
				return this._Gap_Level;
			}
			set
			{
				if ((this._Gap_Level != value))
				{
					this._Gap_Level = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Gap_Safe_Level", DbType="Int")]
		public System.Nullable<int> Gap_Safe_Level
		{
			get
			{
				return this._Gap_Safe_Level;
			}
			set
			{
				if ((this._Gap_Safe_Level != value))
				{
					this._Gap_Safe_Level = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Gap_Tick_Counter", DbType="Int")]
		public System.Nullable<int> Gap_Tick_Counter
		{
			get
			{
				return this._Gap_Tick_Counter;
			}
			set
			{
				if ((this._Gap_Tick_Counter != value))
				{
					this._Gap_Tick_Counter = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Gap_Pendings_Cancel", DbType="Int")]
		public System.Nullable<int> Gap_Pendings_Cancel
		{
			get
			{
				return this._Gap_Pendings_Cancel;
			}
			set
			{
				if ((this._Gap_Pendings_Cancel != value))
				{
					this._Gap_Pendings_Cancel = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Gap_Take_Profit_Slide", DbType="Int")]
		public System.Nullable<int> Gap_Take_Profit_Slide
		{
			get
			{
				return this._Gap_Take_Profit_Slide;
			}
			set
			{
				if ((this._Gap_Take_Profit_Slide != value))
				{
					this._Gap_Take_Profit_Slide = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Gap_Stop_Loss_Slide", DbType="Int")]
		public System.Nullable<int> Gap_Stop_Loss_Slide
		{
			get
			{
				return this._Gap_Stop_Loss_Slide;
			}
			set
			{
				if ((this._Gap_Stop_Loss_Slide != value))
				{
					this._Gap_Stop_Loss_Slide = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_News_Stops_Freezes", DbType="Int")]
		public System.Nullable<int> News_Stops_Freezes
		{
			get
			{
				return this._News_Stops_Freezes;
			}
			set
			{
				if ((this._News_Stops_Freezes != value))
				{
					this._News_Stops_Freezes = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Allow_Pendings_On_News", DbType="Int")]
		public System.Nullable<int> Allow_Pendings_On_News
		{
			get
			{
				return this._Allow_Pendings_On_News;
			}
			set
			{
				if ((this._Allow_Pendings_On_News != value))
				{
					this._Allow_Pendings_On_News = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
