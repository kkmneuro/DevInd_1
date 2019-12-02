using System.Collections.Generic;
using PALSA.Cls;
namespace PALSA.ClsMatrix
{
    public interface IMatrixView
    {
        void AddGridRowItems(List<MatrixViewItem> items);
        void UpdateGridRowItems(List<MatrixViewItem> items);
        void UpdateGridWithInstrument(Instrument instrument);
        void ClearGrid();
        void UpdateTotalTradeVolume(long totalTradeVolume);
        void UpdateTotalBidSize(long totalBidSize);
        void UpdateTotalOfferSize(long totalOfferSize);
        //void UpdateTopGrid(List<QuoteItem> list);
        //Namo 21 March
        //void UpdateTopGridLAST(QuoteItem last);
        void HandleLTP(MatrixViewItem items);
    }
}
