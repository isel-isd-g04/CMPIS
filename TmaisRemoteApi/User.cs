namespace TmaisRemoteApi
{
    public class User
    {
        public string IBAN { get; private set; }

        public string Nif { get; private set; }

        public bool Result { get; private set; }
        public float Value { get; set; }


        public User(string iban, string nif, bool result, float value)
        {
            IBAN = iban;
            Nif = nif;
            Result = result;
            Value = value;

        }
    }
}