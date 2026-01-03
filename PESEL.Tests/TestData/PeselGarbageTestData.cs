namespace PESEL.Tests.TestData
{
    public static class PeselGarbageTestData
    {
        public static IEnumerable<object[]> Garbage =>
        [
            ["aaaaaaaaaaa", "letters only"],
            [";ierhf;iadr", "random symbols"],
            ["00000000000", "all zeros"],
            ["11111111111", "all ones"],
            ["99999999999", "all nines"],
            ["10101010101", "alternating pattern"],
            ["01010101010", "alternating pattern"]
        ];
    }
}
