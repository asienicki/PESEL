namespace PESEL.Tests.TestData
{
    public static class PeselBirthDateProjectionTestData
    {
        public static IEnumerable<object[]> Cases =>
        [
            ["77031167334", new DateTime(1977, 3, 11)],
        ["04242625931", new DateTime(2004, 4, 26)],
        ["92082683499", new DateTime(1992, 8, 26)],
        ["58883175997", new DateTime(1858, 8, 31)],
        ["58083175993", new DateTime(1958, 8, 31)],
        ["58283175999", new DateTime(2058, 8, 31)],
        ["58483175995", new DateTime(2158, 8, 31)],
        ["58683175991", new DateTime(2258, 8, 31)]
        ];
    }
}
