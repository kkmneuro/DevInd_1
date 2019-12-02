using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtocolStructs;
using System.Threading;

namespace DSSocket.Classes
{
    //public class clsPiggyBeg
    //{
    //    #region Variables4PiggyBegging
    //    public enum TOSR { Sender, Receiver }
    //    public Dictionary<int, IProtocolStruct> DDInbox;
    //    public Dictionary<int, IProtocolStruct> DDOutbox;
    //    private int SeqNoInbox = 111;
    //    private int SeqNoOutbox = 111;
    //    public int LastSeqNo = 111;
    //    public int LastAckID4mReceiver = 100001;
    //    public int LastAckID4mSender = 100001;

    //    public object lck4DDInbox = new object();
    //    public object lck4DDOutbox = new object();

    //    int PktCntr = 0;
    //    public delegate void Resending4OutBox(int LastAckNo);
    //    public event Resending4OutBox Reseding4OutBox = delegate { };
    //    Client ObjClient;
    //    //System.Timers.Timer tmrResending4Outbox = new System.Timers.Timer();

    //    public int SeqNumberIN
    //    {
    //        set
    //        {
    //            SeqNoInbox = value;
    //            Init(DDInbox, 10);
    //        }

    //    }

    //    #endregion

    //    public clsPiggyBeg(Client Clnt)
    //    {
    //        ObjClient = Clnt;
    //        DDInbox = new Dictionary<int, IProtocolStruct>();
    //        DDOutbox = new Dictionary<int, IProtocolStruct>();
    //        //Init(DDOutbox, 10);
    //        Reseding4OutBox += new Resending4OutBox(clsPiggyBeg_Reseding4OutBox);
    //    }

    //    void clsPiggyBeg_Reseding4OutBox(int LastAckNo)
    //    {
    //        if (Monitor.TryEnter(lck4DDOutbox, 500))
    //        {
    //            if (DDOutbox.ContainsKey(LastAckNo + 1))
    //            {
    //                IProtocolStruct tmp = DDOutbox[LastAckNo + 1];
    //                tmp.AckIDR = -1;
    //                ObjClient.SendStructWithoutPiggy(tmp, () => { });
    //            }
    //            Monitor.Exit(lck4DDOutbox);
    //        }
    //    }



    //    public bool AddPacket2Outbox(IProtocolStruct ProtocolStruct)
    //    {

    //        lock (lck4DDOutbox)
    //        {
    //            //if (ProtocolStruct.ID != ProtocolStructIDS.HeartBeat_ID)
    //            {
    //                ProtocolStruct.AckIDS = Interlocked.Increment(ref SeqNoOutbox);
    //                DDOutbox.Add(ProtocolStruct.AckIDS, ProtocolStruct);
    //            }
    //        }
    //        return true;

    //    }

    //    public int GetRS(IProtocolStruct ProtocolStruct, TOSR tosr)
    //    {
    //        switch (tosr)
    //        {
    //            case TOSR.Sender:
    //                return ProtocolStruct.AckIDR;
    //            case TOSR.Receiver:
    //                return ProtocolStruct.AckIDS;
    //            default:
    //                return -1;
    //        }

    //    }

    //    public bool AddPacket2Inbox(IProtocolStruct ProtocolStruct)
    //    {
    //        try
    //        {
    //            // if (ProtocolStruct.ID != ProtocolStructIDS.HeartBeat_ID)
    //            {
    //                lock (lck4DDInbox)
    //                {
    //                    DDInbox.Add(Interlocked.Increment(ref SeqNoInbox), ProtocolStruct);
    //                }
    //                RemovePacketInbox(ProtocolStruct);
    //                if (GetRS(ProtocolStruct, TOSR.Sender) != -1)
    //                {
    //                    RemovePacketOutbox(ProtocolStruct);
    //                }
    //                if (Reseding4OutBox != null)
    //                {
    //                    if (++PktCntr % 5 == 0)
    //                    {
    //                        Reseding4OutBox(ProtocolStruct.AckIDR);
    //                    }
    //                }
    //            }
    //        }
    //        catch (Exception)
    //        {

    //            throw;
    //        }
    //        return true;
    //    }

    //    private void RemovePacketInbox(IProtocolStruct ProtocolStruct)
    //    {

    //        try
    //        {
    //            if (Monitor.TryEnter(lck4DDInbox, 2000))
    //            {
    //                int RemAckId = GetRS(ProtocolStruct, TOSR.Sender);
    //                for (int i = LastAckID4mSender; i < RemAckId; i++)
    //                {
    //                    if (!DDInbox.ContainsKey(LastAckID4mSender))
    //                    {
    //                        DDInbox.Remove(LastAckID4mSender);
    //                    }
    //                }
    //                LastAckID4mSender = RemAckId;
    //                Monitor.Exit(lck4DDInbox);
    //            }
    //        }
    //        catch (Exception)
    //        {

    //            throw;
    //        }

    //    }

    //    private void RemovePacketOutbox(IProtocolStruct ProtocolStruct)
    //    {

    //        try
    //        {
    //            if (Monitor.TryEnter(lck4DDOutbox, 2000))
    //            {
    //                int RemAckId = GetRS(ProtocolStruct, TOSR.Sender);
    //                for (int i = LastAckID4mReceiver; i < RemAckId; i++)
    //                {
    //                    if (!DDOutbox.ContainsKey(LastAckID4mReceiver))
    //                    {
    //                        DDOutbox.Remove(LastAckID4mReceiver);
    //                    }
    //                }
    //                LastAckID4mReceiver = RemAckId;
    //                Monitor.Exit(lck4DDOutbox);
    //            }
    //        }
    //        catch (Exception)
    //        {

    //            throw;
    //        }

    //    }


    //    private void Init(Dictionary<int, IProtocolStruct> DD, int ContainerCapacity)
    //    {
    //        for (int i = 0; i < ContainerCapacity; i++)
    //        {
    //            DD.Add(SeqNoOutbox++, null);
    //        }
    //    }

    //}
}
