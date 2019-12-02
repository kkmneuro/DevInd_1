﻿using System;
using System.Media;
using System.Windows.Forms;
using CommonLibrary.Cls;

namespace TWS.Frm
{
    public partial class AlertTestForm : frmBase
    {
        public AlertTestForm()
        {
            InitializeComponent();
        }

        public void AlertSound()
        {
            var objSoundPlayer = new SoundPlayer(Application.StartupPath + "\\Resx\\Alert.wav");
            objSoundPlayer.Play();
        }

        public void FreshOrderAlert()
        {
            if (Properties.Settings.Default.IsFrshOrder)
            {
                AlertSound();
                ClsCommonMethods.ShowInformation("Fresh order");
            }
        }

        public void OrderModificationAlert()
        {
            if (Properties.Settings.Default.IsOrderModification)
            {
                AlertSound();
                ClsCommonMethods.ShowInformation("Order Modification");
            }
        }

        public void MarketOrderAlert()
        {
            if (Properties.Settings.Default.IsMarketOrder)
            {
                AlertSound();
                ClsCommonMethods.ShowInformation("Market Order");
            }
        }

        public void OrderCancellationAlert()
        {
            if (Properties.Settings.Default.IsOrderCancellation)
            {
                AlertSound();
                ClsCommonMethods.ShowInformation("Order Cancellation");
            }
        }

        public void TradeModificationAlert()
        {
            if (Properties.Settings.Default.IsTradeModification)
            {
                AlertSound();
                ClsCommonMethods.ShowInformation("Trade Modification");
            }
        }

        public void DifferentProductOrderAlert()
        {
            if (Properties.Settings.Default.IsDifferentProductOrder)
            {
                AlertSound();
                ClsCommonMethods.ShowInformation("Different product order");
            }
        }

        public void OutsideDPROrderAlert()
        {
            if (Properties.Settings.Default.IsOutsideDPROrder)
            {
                AlertSound();
                ClsCommonMethods.ShowInformation("Outside DPR order");
            }
        }

        public void OpenPositionAlertOnLogoffAlert()
        {
            if (Properties.Settings.Default.IsOpenPositionAlertOnLogoff)
            {
                AlertSound();
                ClsCommonMethods.ShowInformation("Open position Alert on Log Off");
            }
        }

        public void PendingOrdersAlertOnLogoffAlert()
        {
            if (Properties.Settings.Default.IsPendingOrdersAlertOnLogoff)
            {
                AlertSound();
                ClsCommonMethods.ShowInformation("Pending Orders Alert OnLogoff");
            }
        }

        public void ValueAlert(int vle)
        {
            if (Properties.Settings.Default.ValueAlerts == vle)
            {
                AlertSound();
                ClsCommonMethods.ShowInformation("Value Alert" + vle);
            }
        }

        public void PriceAlert(double price)
        {
            if (Properties.Settings.Default.PriceAlerts == price)
            {
                AlertSound();
                ClsCommonMethods.ShowInformation("Price Alert" + price);
            }
        }

        public void QuantityAlert(int qty)
        {
            if (Properties.Settings.Default.QuantityAlerts == qty)
            {
                AlertSound();
                ClsCommonMethods.ShowInformation("Quantity Alert" + qty);
            }
        }

        public void SpreadIOCPriceAlert(int ioc)
        {
            if (Properties.Settings.Default.SpreadIOCPriceAlerts == ioc)
            {
                AlertSound();
                ClsCommonMethods.ShowInformation("SpreadIOC Price Alert");
            }
        }

        public void TradingCurrencyAlert(string tcry)
        {
            if (Properties.Settings.Default.TradingCurrencyAlerts == tcry)
            {
                AlertSound();
                ClsCommonMethods.ShowInformation("Trading Currency Alert");
            }
        }

        private void ui_nbtnFreshOrder_Click(object sender, EventArgs e)
        {
            FreshOrderAlert();
        }


        private void ui_nbtnOrderModification_Click(object sender, EventArgs e)
        {
            OrderModificationAlert();
        }

        private void ui_nbtnMarketOrder_Click(object sender, EventArgs e)
        {
            MarketOrderAlert();
        }

        private void ui_nbtnOrderCancellation_Click(object sender, EventArgs e)
        {
            OrderCancellationAlert();
        }

        private void ui_nbtnTradeModification_Click(object sender, EventArgs e)
        {
            TradeModificationAlert();
        }

        private void ui_nbtnDiffProductOrder_Click(object sender, EventArgs e)
        {
            DifferentProductOrderAlert();
        }

        private void ui_nbtnOutsideDPROrder_Click(object sender, EventArgs e)
        {
            OutsideDPROrderAlert();
        }

        private void ui_nbtnQtyAlerts_Click(object sender, EventArgs e)
        {
            QuantityAlert(30);
        }

        private void ui_nbtnPriceAlerts_Click(object sender, EventArgs e)
        {
            PriceAlert(34.12);
        }

        private void ui_nbtnV_Click(object sender, EventArgs e)
        {
            ValueAlert(33);
        }


        private void ui_nbtnSpreadAlerts_Click(object sender, EventArgs e)
        {
            SpreadIOCPriceAlert(30);
        }

        private void ui_nbtnOpenPostionAlerts_Click(object sender, EventArgs e)
        {
            OpenPositionAlertOnLogoffAlert();
        }

        private void ui_nbtnPendingOrderAlerts_Click(object sender, EventArgs e)
        {
            PendingOrdersAlertOnLogoffAlert();
        }

        private void ui_nbtnTradingCurrencyAlerts_Click(object sender, EventArgs e)
        {
            TradingCurrencyAlert("INR");
        }

        //public event Action FreshOrder;
        //public event Action OrderModification;
        //public event Action MarketOrder;
        //public event Action OrderCancellation;
        //public event Action TradeModification;
        //public event Action DifferentProductOrder;
        //public event Action OpenPositionAlertOnLogoff;
        //public event Action OutsideDPROrder;
        //public event Action PendingOrdersAlertOnLogoff;
        //public event Action OnValueAlert;
        //public event Action OnPriceAlert;
        //public event Action OnQuantityAlert;
        //public event Action OnSpreadIOCPriceAlert;
        //public event Action OnTradingCurrencyAlert;
    }
}