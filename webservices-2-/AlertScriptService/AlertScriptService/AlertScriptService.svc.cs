using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Configuration;

namespace AlertScriptService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AlertScriptService" in code, svc and config file together.
    public class AlertScriptService : IAlertScriptService
    {
        List<AlertScripts> lstAlertScripts = new List<AlertScripts>();
        string[] scriptArray;

        public List<AlertScripts> GetAlertScripts()
        {
            foreach (var item in AlertScriptReader())
            {
                string[] scriptValues = item.Split('~');
                AlertScripts objAlertScripts = new AlertScripts();
                objAlertScripts.AlertName = scriptValues[1];
                objAlertScripts.Abbreviation = scriptValues[2];
                objAlertScripts.Bars = scriptValues[3];
                objAlertScripts.BuyScript = scriptValues[4];
                objAlertScripts.DayHours = Convert.ToBoolean(scriptValues[5].Trim());
                objAlertScripts.DefaultScript = scriptValues[6];
                objAlertScripts.Enabled = Convert.ToBoolean(scriptValues[7].Trim());
                objAlertScripts.EndOfDay = Convert.ToBoolean(scriptValues[8].Trim());
                objAlertScripts.Exchange = scriptValues[9];
                objAlertScripts.ExitLongScript = scriptValues[10];
                objAlertScripts.ExitShortScript = scriptValues[11];
                objAlertScripts.GTC = Convert.ToBoolean(scriptValues[12].Trim());
                objAlertScripts.GTCHours = Convert.ToBoolean(scriptValues[13].Trim());
                objAlertScripts.Interval = Convert.ToInt32(scriptValues[14].Trim());
                objAlertScripts.IsUserDefined = Convert.ToBoolean(scriptValues[15].Trim());
                objAlertScripts.Limit = Convert.ToBoolean(scriptValues[16].Trim());
                objAlertScripts.Market = Convert.ToBoolean(scriptValues[17].Trim());
                objAlertScripts.NumberOfLines = Convert.ToInt16(scriptValues[18].Trim());
                objAlertScripts.Period = scriptValues[19];
                objAlertScripts.Portfolio = scriptValues[20];
                objAlertScripts.Quantity = Convert.ToInt32(scriptValues[21].Trim());
                objAlertScripts.SellScript = scriptValues[22];
                objAlertScripts.StopLimit = Convert.ToBoolean(scriptValues[23].Trim());
                objAlertScripts.StopLimitValue = scriptValues[24];
                objAlertScripts.StopMarket = Convert.ToBoolean(scriptValues[25].Trim());
                objAlertScripts.Symbol = scriptValues[26];
                objAlertScripts.TradeSignalScript = scriptValues[27];
                objAlertScripts.UniqueIdField = new Guid(scriptValues[28].Trim());
                lstAlertScripts.Add(objAlertScripts);
            }
            return lstAlertScripts;
        }
                
        private string[] AlertScriptReader()
        {
            int counter = 0;
            string line;
            string scriptData = string.Empty;

            System.IO.StreamReader file = new System.IO.StreamReader(ConfigurationManager.AppSettings["AlertScriptsPath"].ToString().Trim());
             //new System.IO.StreamReader(@"C:\WebServices\AlertScriptService\AlertScript\AlertScripts.txt");
            while ((line = file.ReadLine()) != null)
            {
                scriptData = scriptData+'~'+ line;                
                counter++;
            }
            scriptArray = scriptData.Split('+');
            return scriptArray;
        }
    }
}
