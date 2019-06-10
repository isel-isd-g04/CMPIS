using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using ValidationModels;
using Validator;

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


        private static void RefreshDataAsync(string serverPath, string iban, float value)
        {
            try
            {
                var httpRequest = HttpWebRequest.CreateHttp(serverPath);
                httpRequest.Method = "POST";
                httpRequest.ContentType = "application/octet-stream";
                var responseBody = httpRequest.GetRequestStream();
                Console.WriteLine("Requesting Transfer {0} for user {1}", serverPath, iban);

                var jsonMessage = JsonConvert.SerializeObject(new ValidationRequest()
                {
                    //UserFiscalNumber = Helper.UserNIF,
                    //UserIBAN = Helper.UserIBAN,
                }, new ProtoMessageConverter());

                var binaryData = Encoding.UTF8.GetBytes(jsonMessage);
                responseBody.Write(binaryData);


                IAsyncResult asyncResult = httpRequest.BeginGetResponse(new AsyncCallback(result =>
                {
                    WebResponse response = httpRequest.EndGetResponse(result);
                    Stream dataStream = response.GetResponseStream();

                    if (dataStream == null)
                    {
                        response.Dispose();
                        Console.WriteLine("No answer");
                        return;
                    }

                    foreach (string responseHeader in response.Headers)
                    {
                        Console.WriteLine(responseHeader);

                    }

                    Int32 messageSize = (Int32)dataStream.Length;
                    Console.WriteLine("answer size{0}", messageSize);
                    if (messageSize < 3)
                    {
                        dataStream.Dispose();
                        response.Dispose();
                        return;
                    }

                    byte[] dataArray = new byte[messageSize];
                    Int32 readBytes = dataStream.Read(dataArray, 0, messageSize);

                    dataStream.Dispose();
                    response.Dispose();

                }), new object());

                //Blocks the call until the request is processed.
                asyncResult.AsyncWaitHandle.WaitOne();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return;
            }

            return;
        }


    }
}
