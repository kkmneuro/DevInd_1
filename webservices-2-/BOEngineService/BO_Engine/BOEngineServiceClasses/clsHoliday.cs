using System;

using System.Runtime.Serialization;

namespace BOEngineServiceClasses
{
    /// <summary>
    /// Summary description for clsHoliday
    /// </summary>
    [DataContract]
    public class clsHoliday
    {
        [DataMember]
        public DateTime Day { get; set; }
        [DataMember]
        public string FromTime { get; set; }
        [DataMember]
        public string ToTime { get; set; }
        [DataMember]
        public string Symbol { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public bool IsEnable { get; set; }
        [DataMember]
        public bool IsEveryYear { get; set; }
        [DataMember]
        public int ServerResponseID { get; set; }
    }
}
