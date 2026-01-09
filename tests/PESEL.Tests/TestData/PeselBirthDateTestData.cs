namespace PESEL.Tests.TestData
{
    public static class PeselBirthDateTestData
    {
        public static IEnumerable<object[]> InvalidBirthDates =>
            [
                ["02223112345", "31.02.2002 – invalid day"],
                ["02223012345", "30.02.2002 – invalid day"],
                ["01222912345", "29.02.2001 – non-leap year"],
                ["00422912345", "29.02.2100 – non-leap century"],
                ["02991312345", "month 99 – out of range"],
                ["02401312345", "month 40 – invalid encoding"]
            ];

        public static IEnumerable<object[]> ValidBirthDates =>
            [
                ["00222912349", "29.02.2000 – leap year"],
                ["02270803624", "08.07.2002 – 2000s encoding"],
                ["81923112342", "31.12.1881 – 1800s encoding"],
                ["48011809618", "18.01.1948 – 1900s encoding"]
            ];
    }
}
