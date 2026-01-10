using PESEL.System.ComponentModel.DataAnnotations.Attributes;

namespace PESEL.Tests.IntegrationTests.DataAnnotations
{
    public class ModelWithPeselAttributeOnProperty
    {
        [Pesel]
        public string? Pesel { get; set; }
    }
}
