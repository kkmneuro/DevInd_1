using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;

namespace PALSA.ClsAlerts
{
    enum PlaySound_Criteria
    {
        ConenctionCompleted,
        ConnectionFailure,
        NewChatMessage,
        NewNewsStory,
        SystemStatusChange,
        UserActionRequest,
        BuyPositionOpenedByStopOrder,
        SellPositionOpenedByMarketOrder,
        SellPositionOpenedbyStopOrder,
        SellPositionOpenedbyLimitOrder,
        SellPositionClosedbyMarketOrder,
        SellPositionClosedbyStopOrder,
        SellPositionOpenedwithMutualClose,
        BuyPositionClosedbyMarketOrder,
        SellPositionClosedbyLimitOrder,
        SellPositionrollbacked,
        SellPositionMutualClose,
        CreateSellSLOrder,
        SellPositionModified,
        CreateSellTPOrder,
        CreatePendingSelllimitOrder,
        CreatePendingSellStopOrder,
        Modifypendingsellstoporder,
        Modifypendingselllimitorder,
        ModifySELLSLorder,
        ModifySELLTPorder,
        DeleteSELLSLorder,
        DeleteSELLTPorder,
        DeletedelayedSELLstoporder,
        DeletependingSELLlimitorder,
        BuyPositionclosedbystoporder,
        BuyPositionclosedbylimitorder,
        BuyPositionopenedbylimitorder,
        CreateBUYSLorder,
        CreateBUYTPorder,
        CreatependingBUYstoporder,
        CreatependingBUYlimitorder,
        alertSound,
    }    

    public class WSounds
    {

        [DllImport("WinMM.dll")]

        public static extern bool PlaySound(string fname, int Mod, int flag);

        // these are the SoundFlags we are using here, check mmsystem.h for more

        public int SND_ASYNC = 0x0001; // play asynchronously

        public int SND_FILENAME = 0x00020000; // use file name

        public int SND_PURGE = 0x0040; // purge non-static events



        public void Play(string fname, int SoundFlags)
        {
            if(!File.Exists(fname))
                return;
            PlaySound(fname, 0, SoundFlags);

        }

        public void StopPlay()
        {

            PlaySound(null, 0, SND_PURGE);

        }

    }
}
