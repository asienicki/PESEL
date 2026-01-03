namespace PESEL.Tests.TestData
{
    public static class PeselEmptyTestData
    {
        public static IEnumerable<object[]> Empty =>
        [
            [null, "null value"],
            ["", "empty string"],
            ["           ", "whitespace only"]
        ];
    }
}
