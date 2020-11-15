namespace FamousQuoteQuiz.API
{
    public class AppSettings
    {
        public string SqlServerHostName { get; set; }
        public string SqlServerPost { get; set; }
        public string SqlServerCatalog { get; set; }
        public string SqlServerUser { get; set; }
        public string SqlServerPassword { get; set; }
        public bool EnableSSL { get; set; }
        public int LanguageId { get; set; }

    }
}