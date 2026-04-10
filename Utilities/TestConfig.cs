[assembly: NUnit.Framework.LevelOfParallelism(2)]

namespace SeleniumTestFramework
{
    public static class TestConfig
    {
        public const string BaseUrl = "https://www.logangarbacki.dev";
        public const int ElementTimeoutSeconds = 6;
        public const int UrlTimeoutSeconds = 5;
    }
}
