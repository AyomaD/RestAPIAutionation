using Newtonsoft.Json;
using RestAPIAutomation.Common;
using RestAPIAutomation.DTO;
using RestAPIAutomation.Endpoints;
using RestSharp;

namespace RestAPIAutomation.Helper
{
    public class ObjectHelper
    {
         const string BASEURL = "https://api.restful-api.dev";

        public DataDto GetSingleObject(string id)
        {
            RestResponse response = RequestExecutor.ExecuteRequest(BASEURL + EndPoints.GET_SINGLE_OBJECTS
                , "id", id, Method.Get);
            return JsonConvert.DeserializeObject<DataDto>(response.Content);
        }

        public List<DataDto> GetListOfAllObjects()
        {
            RestResponse response = RequestExecutor.ExecuteRequest(BASEURL + EndPoints.GET_lIST_OF_ALL_OBJECTS
                , Method.Get);
            return JsonConvert.DeserializeObject<List<DataDto>>(response.Content);
        }

        public List<DataDto> GetListOfObjectsByIds(String id1, String id2, String id3)
        {
            RestResponse response = RequestExecutor.ExecuteRequest(BASEURL + EndPoints.GET_lIST_OF_ALL_OBJECTS_BY_IDS
                , "id", id1, "id", id2,"id", id3, Method.Get);
            return JsonConvert.DeserializeObject<List<DataDto>>(response.Content);
        }

        public RestResponse CreateObjects()
        {
            return RequestExecutor.ExecuteRequest(BASEURL + EndPoints.ADD_OBJECTS
                , "CreateObject.json", Method.Post);
        }

        public RestResponse UpdateObjects(string id)
        {
            return RequestExecutor.ExecuteRequest(BASEURL + EndPoints.UPDATE_OBJECTS
                ,"id",id, "UpdateObject.json", Method.Put);
        }

        public RestResponse DeleteObjects(string id)
        {
            return RequestExecutor.ExecuteRequest(BASEURL + EndPoints.DELETE_OBJECTS
                        ,"id", id, Method.Delete);

        }
    }
}
