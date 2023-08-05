namespace RestAPIAutomation.Common
{
    public class HandleContent
    {
        public static string GetRequestFilePath(string fileName)
        {
            return "RequestBodyTemplates//" + fileName;
        }
    }
}
