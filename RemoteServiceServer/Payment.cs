using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace RemoteServiceServer
{
    public class Payment
    {
        private static Payment instance;


        public static Payment Instance {
            get
            {
                if (instance != null)
                    return instance;

                instance = new Payment();
                return instance;
            }
        }


        private Payment()
        {
            //read configs from the file

            //initializes the connection to the remote service

        }

        public bool Debit(string userNIB, float value)
        {
            Debug.WriteLine("Money is being Debit from {0} value:{1}", userNIB, value);
            
            //Emulates the remote server
            Thread.Sleep(500);
            
            return true;
        }


        public bool Transfer(string cmoiIBAN, float value)
        {
            Debug.WriteLine("Money is being transfer to {0} value:{1}", cmoiIBAN, value);

            //Emulates the remote server
            Thread.Sleep(400);

            return true;
        }



    }
}
