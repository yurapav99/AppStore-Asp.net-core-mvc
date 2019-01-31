using System;
using Xunit;
using AppStore.Models;
using AppStore.Controllers;


namespace AppStore.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

        }

        [Fact]
        public void CreateProductsControllerInstanceTest()
        {
            var controller = new AppStore.Controllers.HomeController();
            Assert.NotNull(controller);
        }

    }
}
