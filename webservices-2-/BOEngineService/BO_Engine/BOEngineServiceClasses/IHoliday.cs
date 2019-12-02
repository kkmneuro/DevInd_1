using System;

using System.ServiceModel;
using System.Collections.Generic;

namespace BOEngineServiceClasses
{
    /// <summary>
    /// Summary description for IHoliday
    /// </summary>
    [ServiceContract]
    public interface IHoliday
    {
        [OperationContract]
        List<clsHoliday> HandleHoliday(string userId, OperationTypes opType, clsHoliday holiday);
        //[OperationContract]
        //clsHoliday InsertIntoHoliday(string userId, clsHoliday holiday);
        //[OperationContract]
        //int DeleteHoliday(string userId, int deleteRecordID);
        //[OperationContract]
        //clsHoliday UpdateHoliday(string userId, clsHoliday holiday);
    }
}