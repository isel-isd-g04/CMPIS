using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;

namespace TmaisRemoteApi
{
    public class Persistance
    {
        private static Persistance _instance;

        private ConcurrentDictionary<string, User> dataUserDic;


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
            dataUserDic = new ConcurrentDictionary<string, User>();

        }


        public void AddUserTransaction(User userAction)
        {
            var res = dataUserDic.GetOrAdd(userAction.IBAN, userAction);
            //user added
            if (res == null)
                return;
            
            //increment the value
            userAction.Value += res.Value;
            //dataUserDic.AddOrUpdate(userAction.IBAN, userAction);
            bool result = dataUserDic.TryUpdate(userAction.IBAN, userAction, res);
        }


        public void AddCMOITransaction(CmoiData cmoiAction)
        {

        }

        public List<User> GetUserTransaction()
        {
            var filledList = new List<User>();
            if (dataUserDic.IsEmpty == true)
                return filledList;

            foreach (var user in dataUserDic)
            {
                filledList.Add(user.Value);
            }

            return filledList;
        }

        public List<CmoiData> GetCMOITransaction()
        {

            return null;
        }


    }
}