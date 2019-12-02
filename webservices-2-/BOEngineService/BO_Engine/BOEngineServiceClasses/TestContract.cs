using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace BOEngineServiceClasses
{
    [ServiceContract]
    public interface TestContract
    {
        [OperationContract]
        void GetInfo1();
        [OperationContract]
        void GetInfo2();
        [OperationContract]
        void GetInfo3();
        [OperationContract]
        void GetInfo4();
        [OperationContract]
        void GetInfo5();
        [OperationContract]
        void GetInfo1a();
        [OperationContract]
        void GetInfo2b();
        [OperationContract]
        void GetInfo3c();
        [OperationContract]
        void GetInfo4d();
        [OperationContract]
        void GetInfo5e();
    }
}
