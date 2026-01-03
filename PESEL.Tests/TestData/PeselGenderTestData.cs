namespace PESEL.Tests.TestData
{
    public static class PeselGenderTestData
    {
        public static IEnumerable<object[]> Female =>
        [
            ["78010469227"],
        ["82062782227"],
        ["90082895388"],
        ["90010751823"],
        ["69100149787"]
        ];

        public static IEnumerable<object[]> Male =>
        [
            ["68060266493"],
        ["74040867518"],
        ["85092786133"],
        ["83032769796"],
        ["56090256131"]
        ];
    }
}