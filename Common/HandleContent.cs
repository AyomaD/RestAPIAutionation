using Newtonsoft.Json;
using RestSharp;

namespace RestAPIAutomation.Common
{
    public class HandleContent
    {
        public static T GetContent<T>(RestResponse response) 
        {
            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        public static T ParseJSON<T>(String file)
        {

            return JsonConvert.DeserializeObject<T>(File.ReadAllText(file));
        }

        public static string GetRequestFilePath(string fileName) 
        {
            return "RequestBodyTemplates//" + fileName;
        }
    }
}
