using System;

using System.Runtime.Serialization;

namespace BOEngineServiceClasses
{
    /// <summary>
    /// Summary description for clsCountryDetail
    /// </summary>
    [DataContract]
    public class clsCountryDetail
    {
        [DataMember]
        public Int32 CountryId { get; set; }
        [DataMember]
        public string CountryName { get; set; }
        [DataMember]
        public string Nationality { get; set; }
        [DataMember]
        public string CountryCode { get; set; }
        [DataMember]
        public int ServerResponseID { get; set; }
    }
}