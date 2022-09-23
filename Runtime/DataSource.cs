namespace Tradelite.SDK
{

    public class DataSource
    {
        private static string apiUrl = "https://gqh7jc24pf.execute-api.eu-central-1.amazonaws.com/develop";
        private static string cdnUrl = "https://d1y3u9tahjcxy5.cloudfront.net";
        private static string websiteUrl = "https://develop.mogaland.io";

        // User related services
        public static readonly string User = apiUrl + "/api/v1/user/user";
        public static readonly string Feedback = apiUrl + "/api/v1/user/feedback";
        public static readonly string Wallet = apiUrl + "/api/v1/user/wallet";
        // Mogaland knowledge base
        public static readonly string Instrument = cdnUrl + "/data/instrument";
        public static readonly string QuizQuestion = apiUrl + "/api/v1/kb/question";
        public static readonly string QuizAnswer = apiUrl + "/api/v1/kb/answer";
        public static readonly string QuizSolution = apiUrl + "/api/v1/kb/solution";
    }
}