using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BOEngineServiceClasses
{
    [DataContract]
    public class clsAccountTransaction
    {
        [DataMember]
        public int AccountId { get; set; }
        [DataMember]
        public decimal PaymentAmount { get; set; }
        [DataMember]
        public string PaymentType { get; set; }
        [DataMember]
        public string PaymentMode { get; set; }
        [DataMember]
        public DateTime PaymentDate { get; set; }
        [DataMember]
        public string ChequeFdNo { get; set; }
        [DataMember]
        public string Remark { get; set; }
        [DataMember]
        public int ServerResponseID { get; set; }
    }
}
