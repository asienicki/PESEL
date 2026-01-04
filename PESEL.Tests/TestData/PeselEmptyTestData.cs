namespace PESEL.Tests.TestData
{
    public static class PeselEmptyTestData
    {
        public static IEnumerable<object[]> Empty =>
        [
            [(string?)null, "null value"],
            ["", "empty string"],
            ["           ", "whitespace only"]
        ];
    }
}
