using System.Configuration;

namespace TmaisRemoteApi
{


    public class Helpers
    {

        public static string  MsgConnection;
        public static string TMAISTopicUser ;//= "cmpis.tmais.*";

        public static string TMAISTopicCMOI;// = "cmpis.tmais.*";

        public static void ReadConfigs()
        {
            MsgConnection = ConfigurationManager.AppSettings["message-ip"];
            TMAISTopicUser = ConfigurationManager.AppSettings["tmais-user"];
            TMAISTopicCMOI = ConfigurationManager.AppSettings["tmais-cmoi"];

        }
    }
}