using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace ReportServiceClasses
{
    [DataContract]
    public class clsAccountTrans
    {
        [DataMember]
        public int AccountID { get; set; }
        [DataMember]
        public decimal Amount { get; set; }
        [DataMember]
        public string PaymentMode { get; set; }
        [DataMember]
        public string PaymentType { get; set; }
        [DataMember]
        public DateTime PaymentDate { get; set; }
        [DataMember]
        public string ChequeNo { get; set; }
        [DataMember]
        public string Remark { get; set; }
        [DataMember]
        public int ServerResponseID { get; set; }
    }
}
