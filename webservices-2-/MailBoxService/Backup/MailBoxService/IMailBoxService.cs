using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MailBoxService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMailBoxService" in both code and config file together.
    [ServiceContract]
    public interface IMailBoxService
    {
        [OperationContract]
        List<MailBoxData> GetMailBoxData(string userID, string password, int participantID, DateTime fromDate, DateTime toDate);
    }

       [DataContract]
    public class MailBoxData
    {
        private DateTime _msgTime;
        private string _sender;
        private string _recipient;
        private string _subject;
        private string _discription;


        public MailBoxData()
        {
            _sender = string.Empty;
            _recipient = string.Empty;
            _subject = string.Empty;
            _discription = string.Empty;          
        }

       [DataMember]
        public DateTime MsgTime
        {
            get { return _msgTime; }
            set { _msgTime = value; }
        }

       [DataMember]
       public string Sender
        {
            get { return _sender; }
            set { _sender = value; }
        }
       [DataMember]
       public string Recipient
       {
           get { return _recipient; }
           set { _recipient = value; }
       }
       [DataMember]
       public string Subject
       {
           get { return _subject; }
           set { _subject = value; }
       }
       [DataMember]
       public string Discription
        {
            get { return _discription; }
            set { _discription = value; }
        }
    
    }

}
