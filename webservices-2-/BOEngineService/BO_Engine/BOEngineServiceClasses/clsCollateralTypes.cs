using System;

using System.Runtime.Serialization;

namespace BOEngineServiceClasses
{
    /// <summary>
    /// Summary description for clsCollateralTypes
    /// </summary>
    [DataContract]
    public class clsCollateralTypes
    {
        [DataMember]
        public int CollateralTypeID { get; set; }
        [DataMember]
        public string CollateralType { get; set; }
        [DataMember]
        public int ServerResponseID { get; set; }
    }
}
