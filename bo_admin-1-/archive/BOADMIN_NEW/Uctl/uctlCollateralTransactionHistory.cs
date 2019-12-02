using System.Windows.Forms;

using BOADMIN_NEW.BOEngineServiceTCP;

namespace BOADMIN_NEW.Uctl
{
    /// <summary>
    /// Displays the collateral transaction history
    /// </summary>
    public partial class uctlCollateralTransactionHistory : UserControl
    {
        public uctlCollateralTransactionHistory()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load history of given accountid and collateral type
        /// </summary>
        /// <param name="accountGroupId"></param>
        /// <param name="collateralType"></param>
        public void LoadHistory(int accountGroupId,string collateralType)
        {
            foreach (clsCollateralTransInfo item in Cls.clsProxyClassManager.INSTANCE.GetCollateralTransHistoryRecords(accountGroupId,
                Cls.clsCollateralManager.INSTANCE.GetCollateralTypeID(collateralType)))
            {
                ui_ndgvCollateralHistory.Rows.Add(collateralType, item.Amount, item.TransactionType, item.TransactionDate);
            }
        }
    }
}
