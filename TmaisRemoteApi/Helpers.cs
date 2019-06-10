namespace TmaisRemoteApi
{


    public class Helpers
    {

        public static string  MsgConnection;

        public static void ReadConfigs()
        {
            MsgConnection = ConfigurationManager.AppSettings["msg-ip"];
            //UserIBAN = ConfigurationManager.AppSettings["user-iban"];
            //RemoteAPI = ConfigurationManager.AppSettings["remote-api"];

        }
    }
}