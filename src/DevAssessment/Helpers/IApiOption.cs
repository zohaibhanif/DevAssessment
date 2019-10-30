namespace DevAssessment.Helpers
{
    public interface IApiOption
    {
        string Host { get; }
        string ApiKey { get; }
        int RetryCount { get; }
    }
}
