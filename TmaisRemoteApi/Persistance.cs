using System.Collections.Generic;
using System.ComponentModel;

namespace TmaisRemoteApi
{
    public class Persistance
    {
        private static Persistance _instance;

        public static Persistance Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;

                _instance = new Persistance();

                return _instance;
            }
        }



        private Persistance()
        {

        }


        public void AddUserTransaction(string nif, float value)
        {

        }


        public void AddCMOITransaction(string nif, float value)
        {

        }

        public List<string> GetUserTransaction()
        {

            return null;
        }

        public List<string> GetCMOITransaction()
        {

            return null;
        }


    }
}