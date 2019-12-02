﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ProtocolStructs;
using clsInterface4OME.DSBO;
using clsInterface4OME;
using BOADMIN_NEW.Cls;
using ProtocolStructs.NewPS;

namespace BOADMIN_NEW.Uctl
{

    public partial class uctlOrder : uctlGeneric, Interfaces.IUserCtrl
    {

        #region MEMBERS

        public DialogType currentyDialogType;
        int OrderId;

        #region UI_DATA

        public DS4OrderNew.dtOrdersRow _row = null;
        public Cls.clsEnums.FRM_MODE _mode = clsEnums.FRM_MODE.NA;

        #endregion UI_DATA

        #endregion MEMBERS

        public uctlOrder()
        {
            InitializeComponent();

        }



        #region IUserCtrl Members

        public void Init()
        {
            throw new NotImplementedException();
        }

        public void InitControls()
        {
            if (_row == null)
                return;
            try
            {
                ui_ntxtAccountID.Text = _row.AccountID.ToString();
                ui_ntxtQuantity.Text = _row.Quantity.ToString();
                ui_nnudOrderPrice.Text = _row.OrderPrice.ToString();
                ui_ndtpValidity.Text = _row.Validity.ToString();
                ui_ndtpTime.Text = _row.Time.ToString();
                ui_ncmbSymbol.SelectedItem = _row.Symbol;
                ui_nnudTriggerPrice.Text = _row.TriggerPrice;
                ui_ntxtComment.Text = _row.Comment;
                ui_ncmbType.SelectedItem = _row.Type;
                ui_ncmbFilling.SelectedItem = _row.OrderType;
                ui_ntxtStatus.Text = _row.Status;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void SaveMe()
        {
            throw new NotImplementedException();
        }

        #endregion

        protected void EditOrder()
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("uctlOrder : Enter EditOrder()");
                OrdersPS objOrderPS = new OrdersPS();
                if (_mode == clsEnums.FRM_MODE.EDIT)
                {
                    objOrderPS._Order._OrderID = _row.OrderID;
                }
                else
                {
                    objOrderPS._Order._OrderID = ProtocolStructIDS.DBInsert;
                }

                objOrderPS._Order._AccountID = clsUtility.GetInt(ui_ntxtAccountID.Text);
                objOrderPS._Order._Time = Convert.ToDateTime(ui_ndtpTime.Text);
                objOrderPS._Order._Type = ui_ncmbType.SelectedItem.ToString();
                objOrderPS._Order._Quantity = clsUtility.GetInt(ui_ntxtQuantity.Text);
                objOrderPS._Order._SymbolID = clsSymbolManager.INSTANCE.GetSymbolId(ui_ncmbSymbol.SelectedItem.ToString()).ToString();
                objOrderPS._Order._OrderType = ui_ncmbFilling.SelectedItem.ToString();
                objOrderPS._Order._OrderPrice = ui_nnudOrderPrice.Text;
                objOrderPS._Order._TriggerPrice = ui_nnudTriggerPrice.Text;
                objOrderPS._Order._Comment = ui_ntxtComment.Text;
                objOrderPS._Order._Status = ui_ntxtStatus.Text;
                objOrderPS._Order._Validity = Convert.ToDateTime(ui_ndtpValidity.Text);

                if (objOrderPS.ValidateData())
                {
                    string outString = string.Empty;
                }
                else
                {
                    MessageBox.Show(objOrderPS.GetInValidlist());
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :uctlOrder =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in EditOrder()");
            }

        }
        private void ui_btnUpdate_Click(object sender, EventArgs e)
        {
            EditOrder();
            _frmCommonContainer.Close();
        }

        private void uctlOrder_Load(object sender, EventArgs e)
        {
            InitControls();
        }

        private void ui_btn_cancel_Click(object sender, EventArgs e)
        {
            _frmCommonContainer.Close();
        }

        public void SetValues(DS4OrderNew DS4Order, DS4OrderNew.dtOrdersRow OrderRow, DialogType dialogType)
        {
            currentyDialogType = dialogType;

            if (dialogType == DialogType.Edit)
            {

                ui_ncmbSymbol.Items.AddRange(Cls.clsSymbolManager.INSTANCE.GetSymbolNameArray());
                ui_ncmbType.Items.AddRange(Cls.clsOrdersManager.INSTANCE.GetTypeArray());
                ui_ncmbFilling.Items.AddRange(Cls.clsOrdersManager.INSTANCE.GetOrderTypeArray());
                try
                {
                    //Logging.FileHandling.WriteAllLog("uctlOrder : Enter SetValues()");
                    OrderId = OrderRow.OrderID;
                    ui_ntxtAccountID.Text = OrderRow.AccountID.ToString();
                    ui_ndtpTime.Text = OrderRow.Time.ToString();
                    ui_ncmbType.SelectedIndex = ui_ncmbType.Items.IndexOf(OrderRow.Type);
                    ui_ntxtQuantity.Text = OrderRow.Quantity.ToString();
                    ui_ncmbSymbol.SelectedIndex = ui_ncmbSymbol.Items.IndexOf(OrderRow.Symbol);
                    ui_ncmbFilling.SelectedIndex = ui_ncmbFilling.Items.IndexOf(OrderRow.OrderType);
                    ui_nnudOrderPrice.Text = OrderRow.OrderPrice;
                    ui_nnudTriggerPrice.Text = OrderRow.TriggerPrice;
                    ui_ntxtComment.Text = OrderRow.Comment;
                    ui_ntxtStatus.Text = OrderRow.Status;
                    ui_ndtpValidity.Text = OrderRow.Validity.ToString();
                }
                catch (Exception)
                {
                    //Logging.FileHandling.WriteAllLog("Exception :uctlOrder =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in SetValues()");
                }

            }

        }


        #region IUserCtrl Members

        void BOADMIN_NEW.Interfaces.IUserCtrl.Init()
        {
            throw new NotImplementedException();
        }

        void BOADMIN_NEW.Interfaces.IUserCtrl.InitControls()
        {
            throw new NotImplementedException();
        }

        void BOADMIN_NEW.Interfaces.IUserCtrl.SaveMe()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void ui_btn_restore_Click(object sender, EventArgs e)
        {

        }
    }
}
