using Newtonsoft.Json;
using NUnit.Framework;
using RestAPIAutomation.Base;
using RestAPIAutomation.DTO;
using RestSharp;

namespace RestAPIAutomation.Tests
{
    [TestFixture]
    public class ObjectTests : TestBase
    {

        [Test, Order(1)]
        public void GetSingleObjectWithValidIdTest() 
        {
            DataDto response = objectHelper.GetSingleObject("7");
            Assert.IsNotNull(response);
            Assert.AreEqual(response.Id, 7, "Respose should contained searched id");
            
        }

        [Test, Order(2)]
        public void GetSingleObjectWithInValidIdTest()
        {
            DataDto response = objectHelper.GetSingleObject("500");
            Assert.IsNotNull(response);
            Assert.AreNotEqual(response.Id, 500, "Respose should not contained searched id");

        }

        [Test, Order(3)]
        public void GetListOfAllObjectTest()
        {
            List<DataDto> response = objectHelper.GetListOfAllObjects();
            Assert.AreNotEqual(response.Count,0,"Response should contain more than one JSON object");
        }

        [Test, Order(4)]
        public void GetListOfObjectsByIdsTest()
        {
            List<DataDto> response = objectHelper.GetListOfObjectsByIds("3","5","7");
            Assert.AreNotEqual(response.Count, 0, "Response should contain more than one JSON object");
            Assert.AreEqual(response.Count, 3, "Response should contain three JSON object");
        }

     
        [Test, Order(5)]
        public void CreateObjectTest()
        {
            RestResponse response= objectHelper.CreateObjects();
            Assert.AreEqual((int)response.StatusCode,200,"Statues Code should be 200");

            CtreateObjectDto ctreateObjectDto = JsonConvert.DeserializeObject<CtreateObjectDto>(response.Content);
            Assert.AreEqual(ctreateObjectDto.Name
                , "Apple MacBook Pro 16" ,"Name value mentioned in request should be equals to name value in response");
            Assert.AreEqual(ctreateObjectDto.Data.CpuModel
                , "Intel Core i9", "CpuModel value mentioned in request should be equals to CpuModel value in response");
            Assert.AreEqual(ctreateObjectDto.Data.HardDiskSize
                , "1 TB", "Hard disk size value mentioned in request should be equals to Hard disk size value in response");

        }

        [Test, Order(6)]
        public void UpdateObjectTest()
        {
            RestResponse createResponse = objectHelper.CreateObjects();
            CtreateObjectDto ctreateObjectDto = JsonConvert.DeserializeObject<CtreateObjectDto>(createResponse.Content);
            
            RestResponse response = objectHelper.UpdateObjects(ctreateObjectDto.Id);
            Assert.AreEqual((int)response.StatusCode, 200, "Statues Code should be 200");
        }

        [Test, Order(7)]
        public void UpdateObjectInvalidIdTest()
        {
            RestResponse response = objectHelper.UpdateObjects("invalid");
            Assert.AreEqual((int)response.StatusCode, 404, "Statues Code should be 200");
        }

        [Test, Order(8)]
        public void DeleteObjectTest()
        {
            RestResponse createResponse = objectHelper.CreateObjects();
            CtreateObjectDto ctreateObjectDto = JsonConvert.DeserializeObject<CtreateObjectDto>(createResponse.Content);

            RestResponse response = objectHelper.DeleteObjects(ctreateObjectDto.Id);
            Assert.AreEqual((int)response.StatusCode, 200, "Statues Code should be 200");

        }

        [Test, Order(9)]
        public void DeleteObjectForInvalidIDTest()
        {

            RestResponse response = objectHelper.DeleteObjects("invalid");
            Assert.AreEqual((int)response.StatusCode, 404, "Statues Code should be 404");

        }
    }
}
