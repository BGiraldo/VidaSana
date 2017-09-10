using System;
using Xunit;

namespace XUnitTestClient
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            bool a = true;
            Assert.True(a);
        }
    }
}
