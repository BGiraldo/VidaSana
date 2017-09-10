using Xunit;

namespace XUnitTestClient
{
    public class ClientServiceTest
    {

        private readonly ClientService _service;

        public ClientServiceTest()
        {
            _service = new ClientService();
        }


        [Fact(DisplayName = "Register Client")]
        public void TestRegisterClient()
        {
            var res = _service.Register();
            Assert.True(res);
        }


        [Fact(DisplayName = "Delete Client")]
        public void TestDeleteClient()
        {
            var res = _service.Delete();
            Assert.True(res);
        }

        [Fact(DisplayName = "Search Client")]
        public void TestSearchClient()
        {
            var res = _service.Search();
            Assert.True(res);
        }

        [Fact(DisplayName = "Update Client")]
        public void TestUpdateClient()
        {
            var res = _service.Update();
            Assert.True(res);
        }


    }

}