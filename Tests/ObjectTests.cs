using Newtonsoft.Json;
using NUnit.Framework;
using RestAPIAutomation.DTO;
using RestAPIAutomation.Helper;
using RestSharp;

namespace RestAPIAutomation.Tests
{
    [TestFixture]
    public class ObjectTests
    {
        ObjectHelper helper = new ObjectHelper();

        [SetUp]
        public void Setup()
        {
            helper = new ObjectHelper();
        }
        [Test, Order(1)]
        public void GetSingleObjectWithValidIdTest() 
        {
            DataDto response = helper.GetSingleObject("7");
            Assert.IsNotNull(response);
            Assert.AreEqual(response.Id, 7, "Respose should contained searched id");
            
        }

        [Test, Order(2)]
        public void GetSingleObjectWithInValidIdTest()
        {
            DataDto response = helper.GetSingleObject("500");
            Assert.IsNotNull(response);
            Assert.AreNotEqual(response.Id, 500, "Respose should not contained searched id");

        }

        [Test, Order(3)]
        public void GetListOfAllObjectTest()
        {
            List<DataDto> response = helper.GetListOfAllObjects();
            Assert.AreNotEqual(response.Count,0,"Response should contain more than one JSON object");
        }

        [Test, Order(4)]
        public void GetListOfObjectsByIdsTest()
        {
            List<DataDto> response = helper.GetListOfObjectsByIds("3","5","7");
            Assert.AreNotEqual(response.Count, 0, "Response should contain more than one JSON object");
            Assert.AreEqual(response.Count, 3, "Response should contain three JSON object");
        }

     
        [Test, Order(5)]
        public void CreateObjectTest()
        {
            RestResponse response= helper.CreateObjects();
            Assert.AreEqual((int)response.StatusCode,200,"Statues Code should be 200");

            CtreateObjectDto ctreateObjectDto = JsonConvert.DeserializeObject<CtreateObjectDto>(response.Content);
            
        }

        [Test, Order(6)]
        public void UpdateObjectTest()
        {
            RestResponse createResponse = helper.CreateObjects();
            CtreateObjectDto ctreateObjectDto = JsonConvert.DeserializeObject<CtreateObjectDto>(createResponse.Content);
            String createdId = ctreateObjectDto.Id;

            RestResponse response = helper.UpdateObjects(createdId);
            Assert.AreEqual((int)response.StatusCode, 200, "Statues Code should be 200");
        }

        [Test, Order(7)]
        public void UpdateObjectInvalidIdTest()
        {
            RestResponse response = helper.UpdateObjects("invalid");
            Assert.AreEqual((int)response.StatusCode, 404, "Statues Code should be 200");
        }

        [Test, Order(8)]
        public void DeleteObjectTest()
        {
            RestResponse createResponse = helper.CreateObjects();
            CtreateObjectDto ctreateObjectDto = JsonConvert.DeserializeObject<CtreateObjectDto>(createResponse.Content);
            String createdId = ctreateObjectDto.Id;

            RestResponse response = helper.DeleteObjects(createdId);
            Assert.AreEqual((int)response.StatusCode, 200, "Statues Code should be 200");

        }

        [Test, Order(9)]
        public void DeleteObjectForInvalidIDTest()
        {

            RestResponse response = helper.DeleteObjects("invalid");
            Assert.AreEqual((int)response.StatusCode, 404, "Statues Code should be 404");

        }
    }
}
