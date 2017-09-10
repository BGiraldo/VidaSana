using System;
using VidaSana.API.Infrastructure.IRepository;
using Xunit;

namespace ClientService.Tests
{
    public class ClientTestService
    {

        private readonly ClientService _service;


        public ClientTestService()
        {
            _service = new ClientService();
        }


        [Fact (DisplayName ="Register Client")]
        public void TestRegisterClient()
        {
            bool res = _service.Register();
            Assert.True(res);
        }


        [Fact(DisplayName = "Delete Client")]
        public void TestDeleteClient()
        {
            bool res = _service.Delete();
            Assert.True(res);
        }

        [Fact(DisplayName = "Search Client")]
        public void TestSearchClient()
        {
            bool res = _service.Search();
            Assert.True(res);
        }

        [Fact(DisplayName = "Update Client")]
        public void TestUpdateClient()
        {
            bool res = _service.Update();
            Assert.True(res);
        }


    }
}
