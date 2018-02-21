using PESEL.Attributes;

namespace PESEL.NugetClientTests
{
    public class Model
    {
        [Pesel]
        public string Pesel { get; set; }
    }
}
