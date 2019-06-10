using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace RemoteServiceServer
{
    public class Helpers
    {

        public static string CMPISNIF = "2545165";

        public static string CMPISIBAN = "PT504262346326";

        public static string BKISConnection = "52.166.220.102:7070";

        public static string TMAISTopicUser = "cmpis.tmais.";

        public static string TMAISTopicCMOI = "cmpis.tmais.";

        public static string MessageIP = "13.80.133.138";

        public static int GrpcPort = 5000;
        
        public static float PlatformCut = (float)0.20;

        public static void ReadConfigs()
        {
            CMPISNIF = ConfigurationManager.AppSettings["cmpi-nif"];
            CMPISIBAN = ConfigurationManager.AppSettings["cmpi-iban"];
            TMAISTopicUser = ConfigurationManager.AppSettings["tmais-user"];
            TMAISTopicCMOI = ConfigurationManager.AppSettings["tmais-cmoi"];

            MessageIP = ConfigurationManager.AppSettings["message-ip"];
            BKISConnection = ConfigurationManager.AppSettings["bkis-ip"];

            GrpcPort = Int32.Parse(ConfigurationManager.AppSettings["grpc-port"]);

        }


    }
}
