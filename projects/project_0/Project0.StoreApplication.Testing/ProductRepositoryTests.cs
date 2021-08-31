using Xunit;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Adapters;
using Project0.StoreApplication.Storage.Repositories;
using Project0.StoreApplication.Client.Singletons;
using System.Collections.Generic;

namespace Project0.StoreApplication.Testing
{
    public class ProductRepositoryTests
    {
        [Fact]
        public void Test_ProductCollection()
        {
            var sut = ProductSingleton.Instance;

            var actual = sut.Products;

            Assert.NotNull(actual);
            Assert.NotEmpty(actual);
        }
    }
}