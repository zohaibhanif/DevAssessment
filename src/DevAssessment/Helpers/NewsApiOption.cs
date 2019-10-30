namespace DevAssessment.Helpers
{
    public class NewsApiOption : IApiOption
    {
        public string Host => "https://newsapi.org/v2";

        public string ApiKey => Secrets.ApiKey;

        public int RetryCount => 3;
    }
}
