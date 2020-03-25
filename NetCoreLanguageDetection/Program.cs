using System;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;

namespace NetCoreLanguageDetection
{
    class Program
    {
        private static readonly string apiKey = "c3aff62d4fb345e498575d4c997f5260";
        private static readonly string apiEndpoint = "https://azuretextanalyitcstest.cognitiveservices.azure.com/";
        
        static void Main(string[] args)
        {
            var client =  AuthenticateClient();

            Console.Write("Write something : ");

            var userInput = Console.ReadLine();
            
            var result = client.DetectLanguage(userInput,"tr");
            Console.WriteLine($"Detected Language: {result.DetectedLanguages[0].Name}");

            Console.ReadLine();
        }
        
        
        static TextAnalyticsClient AuthenticateClient()
        {
            var credentials = new ApiKeyCredential(apiKey);
            var client = new TextAnalyticsClient(credentials)
            {
                Endpoint = apiEndpoint
            };
            return client;
        }
    }
}