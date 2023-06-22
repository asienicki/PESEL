using PESEL.System.ComponentModel.DataAnnotations;

namespace PESEL.Tests
{
    public class Model
    {
        [Pesel]
        public string Pesel { get; set; }
    }
}
