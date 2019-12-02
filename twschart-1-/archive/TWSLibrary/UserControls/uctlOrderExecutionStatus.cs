using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CommonLibrary.UserControls
{
    public partial class uctlOrderExecutionStatus : OrderChildControl
    { 
        public event Action<object, EventArgs> OnOrderExecutionFinal_OkClick= delegate { };
        public event Action<object, EventArgs> OnOrderExecutionFinal_PrintClick=delegate{};
        public string ExecutionInfo
        {
            get{return lblOrderExecutionInfo.Text;}
            set{lblOrderExecutionInfo.Text=value;}
        }
        public uctlOrderExecutionStatus()
        {
            InitializeComponent();
            //_Parent = _frmOrderEntry;
            this.Dock = DockStyle.Fill;
            
            //updateMessage(ER);
            initControls();

        }
        void initControls()
        {
            
        }
        public void updateMessage(string message)
        { 
        lblInfo.Text = message;
        }
        //void updateMessage(ProtocolStructs.ExecutionReport ER)
        //{
        //    //switch (ER.Status4UIDbg)
        //    //{
        //    //    case clsInterface4OME.OrderStatus.ACKNOWLEDGE:
        //    //        {
        //    //            if (_Parent.IsReverse == false)
        //    //            {
        //    //                if (_Parent.ReferenceOrderRow != null && _Parent.ReferenceOrderRow.QuantityFilled > 0)
        //    //                {
        //    //                    lblOrderExecutionInfo.Text = "Order Executed #" + ER.ClientOrderID + " " + ER.BuySell + " " + ER.quantity + " "
        //    //                                 + ER.Instrument + " at " + _Parent.ReferenceOrderRow.PriceFilled;
        //    //                }
        //    //                else
        //    //                {
        //    //                    lblOrderExecutionInfo.Text = "Order Executed #" + ER.ClientOrderID + " " + ER.BuySell + " " + ER.quantity + " "
        //    //                                + ER.Instrument + " at " + ER.Price;
        //    //                }
        //    //            }
        //    //            else
        //    //            {
        //    //                _Parent.IsReverse = true;
        //    //                lblOrderExecutionInfo.Text = "Order Reversed To #" + ER.ClientOrderID + " " + ER.BuySell + " " + ER.quantity + " "
        //    //                            + ER.Instrument + " at " + ER.Price;
        //    //            }
        //    //        }
        //    //        break;
        //    //    case clsInterface4OME.OrderStatus.CANCELED:
        //    //        lblOrderExecutionInfo.Text = "Order  #" + ER.ClientOrderID + " is cancelled.";
        //    //        break;
        //    //    case clsInterface4OME.OrderStatus.CANCEL_PENDING:
        //    //        break;
        //    //    case clsInterface4OME.OrderStatus.CLOSE_PROCESS:
        //    //        break;
        //    //    case clsInterface4OME.OrderStatus.CNCIP:
        //    //        break;
        //    //    case clsInterface4OME.OrderStatus.EXPIRED:
        //    //        break;
        //    //    case clsInterface4OME.OrderStatus.PARTIAL_FILLED:
        //    //    case clsInterface4OME.OrderStatus.FILLED:
        //    //        lblOrderExecutionInfo.Text = "Order Filled #" + ER.ClientOrderID + " " + ER.BuySell + " " + ER.quantity + " "
        //    //                     + ER.Instrument + " at " + ER.Price;
        //    //        break;
        //    //    case clsInterface4OME.OrderStatus.MODIFIED:
        //    //        if (_Parent.ReferenceOrderRow.QuantityFilled > 0)
        //    //        {
        //    //            lblOrderExecutionInfo.Text = "Order Modified #" + ER.ClientOrderID + " " + ER.BuySell + " " + ER.quantity + " "
        //    //                         + ER.Instrument + " at " + _Parent.ReferenceOrderRow.PriceFilled;
        //    //        }
        //    //        else
        //    //        {
        //    //            lblOrderExecutionInfo.Text = "Order Modified #" + ER.ClientOrderID + " " + ER.BuySell + " " + ER.quantity + " "
        //    //                         + ER.Instrument + " at " + ER.Price;
        //    //        }
        //    //        break;
        //    //    case clsInterface4OME.OrderStatus.MODIFY_PENDING:
        //    //        break;
        //    //    case clsInterface4OME.OrderStatus.MULTIPLE:
        //    //        break;
        //    //    case clsInterface4OME.OrderStatus.NEW:
        //    //        break;
        //    //    case clsInterface4OME.OrderStatus.NOTVALID:
        //    //        break;
        //    //    case clsInterface4OME.OrderStatus.PARTIAL_REJECTED:
        //    //        break;
        //    //    case clsInterface4OME.OrderStatus.PARTIAL_CANCELLED:
        //    //        break;
        //    //    case clsInterface4OME.OrderStatus.CLOSED:
        //    //    case clsInterface4OME.OrderStatus.PARTIAL_CLOSED:
        //    //        lblOrderExecutionInfo.Text = "Order Closed #" + ER.ClientOrderID + " " + ER.BuySell + " " + ER.quantity + " "
        //    //                    + ER.Instrument + " at " + ER.Price;
        //    //        break;
        //    //    case clsInterface4OME.OrderStatus.PENDING:
        //    //        break;
        //    //    case clsInterface4OME.OrderStatus.REJECTED:
        //    //        break;
        //    //    case clsInterface4OME.OrderStatus.SENT:
        //    //        break;
        //    //    case clsInterface4OME.OrderStatus.SLTP_URG_CLOSED_IN_PROCESS:
        //    //        break;
        //    //    case clsInterface4OME.OrderStatus.WORKING:
        //    //        break;
        //    //    default:
        //    //        break;
        //    //}
        //}
        

        private void btnOrderExecutionFinalOk_Click(object sender, EventArgs e)
        {
            OnOrderExecutionFinal_OkClick(sender,e);
            //if (IsOperationTerminated == true)
            //{
            //    _Parent.ReturnToPreviousState();
            //}
            //else
            //{
            //    _Parent.closeForm();
            //}
        }

        private void btnOrderExecutionFinalPrint_Click(object sender, EventArgs e)
        {
            OnOrderExecutionFinal_PrintClick(sender,e);
            //Print the order status in crystal report
        }
    }
}
