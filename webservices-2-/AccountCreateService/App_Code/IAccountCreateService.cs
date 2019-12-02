using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IAccountCreateService
{
    [OperationContract]
	string GetData(int value);

	[OperationContract]
	string GetDataUsingDataContract();

    [OperationContract]
    List<BO_GetClientBankInformationResult> HandleBO_GetClientsBankInfo(int? clientID);

    [OperationContract]
    List<BO_GetLeverageListResult> HandleBO_GetLeverageList();

    [OperationContract]
    List<BO_GetCountryMasterInfoResult> HandleBO_GetCountryList();

    [OperationContract]
    int HandleBO_InsertBankDetails(string AccountHolderName, string BankAccountID, string BankName, int? BankCountryID,
                                            string BankCity, string BankZipCode, string BankAddress1,
                                            string BankAddress2, string BankPhone, string BankFax,
                                            string BankSwiftCode, int? ParticipantID, string BankAccountType,
                                            string BankIFSCode, ref int? BankId);
    [OperationContract]
    LoginCredential CreateAccount(string firstName, string middleName, string lastName, string primaryEmailAddress, string secondaryEmailAddress,
                                                 DateTime? DOB, string Gender, int? FK_NationalityID,
                                                 string Address1, string Address2, int? FKCountryID,
                                                 string City, string State, string Zip,
                                                 string PrimaryPhone, string secondaryPhone, string FaxNumber,
                                                 string Mobile, string PassportID, string SSN,
                                                 string Age, string PAN, int? FKParticipantType,
                                                 bool? status, bool? deleted, DateTime? registrationDate,
                                                 int? FKAccountTypeID, int? FKAccountGroupID, ref int? participantId,
                                                 decimal? MarkUpValue, ref int? ClientId, decimal? balanace,
                                                 decimal? equity, decimal? usedMargin, int? fkleverage, bool? isHeadgingAllowed
                                                 , bool? isTradeEnable, int? FK_Currency, decimal? buySideTurnOver, decimal? sellSideTurnOver,
                                                 int? bankID, ref int? PKAccountID, string IP_Name, string IPAccount_ID, bool? IsLive, int? hedgeTypeID, string WhiteLevelName);

    [OperationContract]
    int GetSize();
	// TODO: Add your service operations here
}

// Use a data contract as illustrated in the sample below to add composite types to service operations.
[DataContract]
public class CompositeType
{
	bool boolValue = true;
	string stringValue = "Hello ";
    int size = 0;    
	[DataMember]
	public bool BoolValue
	{
		get { return boolValue; }
		set { boolValue = value; }
	}

	[DataMember]
	public string StringValue
	{
		get { return stringValue; }
		set { stringValue = value; }
	}

    [DataMember]
    public int Size
    {
        get { return size; }
        set { size = value; }
    }

}

[DataContract]
public class LoginCredential
{
    [DataMember]
    public string loginId;
    [DataMember]
    public string password;
}
