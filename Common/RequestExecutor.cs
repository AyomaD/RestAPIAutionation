using RestSharp;

namespace RestAPIAutomation.Common
{
    public class RequestExecutor
    {
        public static RestResponse ExecuteRequest(String url 
            , String pathparamkey
            , String pathParamaValue
            , Method method) 
        {
            var client = new RestClient(url);
            var request = new RestRequest(url, method)
                .AddUrlSegment(pathparamkey, pathParamaValue);

            return client.Execute(request);
        }

        public static RestResponse ExecuteRequest(String url
            , String queryparamkey1
            , String queryParamaValue1
            , String queryparamkey2
            , String queryParamaValue2
            , String queryparamkey3
            , String queryParamaValue3
            , Method method)
        {
            var client = new RestClient(url);
            var request = new RestRequest(url, method)
                .AddQueryParameter(queryparamkey1, queryParamaValue1)
                .AddQueryParameter(queryparamkey2, queryParamaValue2)
                .AddQueryParameter(queryparamkey3, queryParamaValue3);

            return client.Execute(request);
        }

        public static RestResponse ExecuteRequest(String url
            , Method method)
        {
            var client = new RestClient(url);
            var request = new RestRequest(url, method);
            return client.Execute(request);
        }

        public static RestResponse ExecuteRequest(String url
            ,String requestTemplateFileName
            , Method method)
        {
            StreamReader reader = new(HandleContent.GetRequestFilePath(requestTemplateFileName));
            var json = reader.ReadToEnd();
            var client = new RestClient(url);
            var request = new RestRequest(url, method)
                .AddJsonBody(json);
            return client.Execute(request);
        }

        public static RestResponse ExecuteRequest(String url
           , String pathparamkey
           , String pathParamaValue
           , String requestTemplateFileName
           , Method method)
        {
            StreamReader reader = new(HandleContent.GetRequestFilePath(requestTemplateFileName));
            var json = reader.ReadToEnd();
            var client = new RestClient(url);
            var request = new RestRequest(url, method)
                .AddUrlSegment(pathparamkey, pathParamaValue)
                .AddJsonBody(json);
            return client.Execute(request);
        }
    }
}
