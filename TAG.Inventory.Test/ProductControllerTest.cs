using Moq;
using TAG.Inventory.API.Controllers;
using TAG.Inventory.Entities;
using TAG.Inventory.Repository.Interface;

namespace TAG.Inventory.Test
{
    public class ProductControllerTest
    {
        private readonly Mock<IRepository<Product>> _repository;

        public ProductControllerTest(Mock<IRepository<Product>> repository)
        {
            _repository = repository;
        }

        [Fact]
        public async Task GetProductList_ProductList()
        {
            //arrange
            var productList = GetProductsData();
            _repository.Setup(x => x.GetAll());
                //.Returns(productList);
            var productController = new ProductController(_repository.Object);

            //act
            var productResult = await productController.Get();

            //assert
            Assert.NotNull(productResult);
            Assert.Equal(GetProductsData().ToString(), productResult.ToString());
            Assert.True(productList.Equals(productResult));
        }

        private List<Product> GetProductsData()
        {
            List<Product> productsData = new List<Product> {
                new Product{
                    Id=1,
                    Name="Computer",
                    Price=100,
                    IsActive=true
                },
                new Product{
                    Id=2,
                    Name="A",
                    Price=100,
                    IsActive=true
                },
                new Product{
                    Id=3,
                    Name="B",
                    Price=100,
                    IsActive=true
                },

            };

            return productsData;
        }


    }
}