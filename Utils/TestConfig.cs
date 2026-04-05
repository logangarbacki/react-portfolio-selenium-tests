[assembly: NUnit.Framework.LevelOfParallelism(4)]

namespace SeleniumTestFramework
{
    public static class TestConfig
    {
        public const string BaseUrl = "https://www.logangarbacki.dev";
        public const int DefaultTimeoutSeconds = 2;
    }
}
