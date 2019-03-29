using PESEL.Attributes;

namespace PESEL.Tests
{
    public class Model
    {
        [Pesel]
        public string Pesel { get; set; }
    }
}
