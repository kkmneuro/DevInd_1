using System;

using System.Runtime.Serialization;

namespace BOEngineServiceClasses
{
    /// <summary>
    /// Summary description for clsParticipaintList
    /// </summary>
    [DataContract]
    public class clsParticipaintList
    {
        [DataMember]
        public Int32 PKParticipantTypeID { get; set; }
        [DataMember]
        public string ParticpantTypeName { get; set; }
        [DataMember]
        public int ServerResponseID { get; set; }
    }
}