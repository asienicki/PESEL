namespace PESEL.Models
{
    public class Entity
    {
        public string Pesel { get; set; }

        public Gender Gender { get; set; }

        public Pesel PeselStruct;

        public Entity(string peselString)
        {
            Pesel = peselString;
        }
    }
}