namespace RestAPIAutomation.Endpoints
{
    public class EndPoints
    {
        public const string GET_lIST_OF_ALL_OBJECTS = "/objects";
        public const string GET_lIST_OF_ALL_OBJECTS_BY_IDS = "/objects?id={id1}&id={id2}&id={id3}";
        public const string GET_SINGLE_OBJECTS = "/objects/{id}";
        public const string ADD_OBJECTS = "/objects";        
        public const string UPDATE_OBJECTS = "/objects/{id}";
        public const string DELETE_OBJECTS = "/objects/{id}";
    }
}
