namespace PESEL.Tests.TestData
{
    public static class PeselLengthTestData
    {
        public static IEnumerable<object[]> TooShort =>
        [
            ["7709171251", "10 digits – too short"],
            ["003223311", "9 digits – too short"],
            ["55061623", "8 digits – too short"],
            ["4709084", "7 digits – too short"],
            ["651028", "6 digits – too short"]
        ];

        public static IEnumerable<object[]> TooLong =>
        [
            ["770917125161", "12 digits – too long"],
            ["0032233115412", "13 digits – too long"],
            ["55061623457333", "14 digits – too long"]
        ];
    }
}
