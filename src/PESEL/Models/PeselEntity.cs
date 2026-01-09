namespace PESEL.Models
{
    public class PeselEntity
    {
        public string Pesel { get; set; }

        public Gender Gender { get; set; }

        public Pesel PeselStruct;

        public PeselEntity(string peselString)
        {
            Pesel = peselString;
        }
    }
}