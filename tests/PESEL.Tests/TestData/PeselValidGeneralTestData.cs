namespace PESEL.Tests.TestData
{
    public static class PeselValidGeneralTestData
    {
        public static IEnumerable<object[]> Valid =>
        [
            ["77091712516", "valid pesel – 1977"],
            ["55061623457", "valid pesel – 1955"],
            ["95011135953", "valid pesel – 1995"],
            ["82071567835", "valid pesel – 1982"]
        ];
    }
}
