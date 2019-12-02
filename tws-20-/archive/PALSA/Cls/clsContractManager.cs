using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientDLL_NET.Manager.Interfaces;
using ClientDLL_NET.Manager;
using ClientDLL_Model.Cls;

namespace PALSA.Cls
{
    public class clsContractManager : IContractManager
    {
        public ContractManager Manager = new ContractManager();
        public clsContractManager()
        {
            Manager.RegisterForEvents(this);
            Manager.Start();
            Manager.Login("ashut", "pwd", "192.168.1.170", "", 2009);
        }
      
        public event Action<ClientDLL_Model.Cls.Contract.InstrumentSpec> OnContractChanged = delegate { };
        public event Action<ClientDLL_Model.Cls.Contract.InstrumentSpec> OnContractRemoved = delegate { };
        public event Action<ClientDLL_Model.Cls.Contract.InstrumentSpec> OnNewContractSpec=delegate { };
        public event Action<string> OnError = delegate { };
        public event Action<ClientDLL_Model.Cls.eManagerStatus> OnManagerStatus=delegate { }; 

        public void onContractChanged(ClientDLL_Model.Cls.Contract.InstrumentSpec contractList)
        {
            OnContractChanged(contractList);
        }

        public void onContractRemoved(ClientDLL_Model.Cls.Contract.InstrumentSpec contractList)
        {
            OnContractRemoved(contractList);
        }

        public void onError(string error)
        {
            OnError(error);
        }

        public void onManagerStatus(ClientDLL_Model.Cls.eManagerStatus status)
        {
            OnManagerStatus(status);        
        }

        public void onNewContractSpec(ClientDLL_Model.Cls.Contract.InstrumentSpec contractList)
        {
            OnNewContractSpec(contractList);
        }
    }
}
