namespace TmaisRemoteApi
{
    public class CmoiData
    {

        public string IBAN { get; private set; }

        public string Nif { get; private set; }

        public float Value { get; private set; }


        public CmoiData(string iban, string nif, float value)
        {
            IBAN = iban;
            Nif = nif;
            Value = value;

        }
    }
}