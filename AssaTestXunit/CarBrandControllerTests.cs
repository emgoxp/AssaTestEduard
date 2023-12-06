    using AssaTest.Application.Controllers;
    using AssaTest.Domain;
    using AssaTest.Infrastruture.Contexts;
    using Microsoft.EntityFrameworkCore;
    using Xunit;
    using Microsoft.EntityFrameworkCore.InMemory;
    namespace AssaTestXunit
    {
        public class CarBrandControllerTests
        {
            private DbContextOptions<AppAssaContext> CreateNewContextOptions()
            {
                return new DbContextOptionsBuilder<AppAssaContext>()
                    .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                    .Options;
            }

            [Fact]
            public void GetData_ReturnsExpectedData()
            {
                // Arrange
                var options = CreateNewContextOptions();
                using (var context = new AppAssaContext(options))
                {
                    // Add dummy data to in-memory database context
                    context.CarBrands.AddRange(new List<CarBrand>
                    {
                        new CarBrand { Id = 1, Name = "Toyota" ,Description = "Macar de auto Toyota",Year = 2022 },
                        new CarBrand { Id = 2, Name = "Ford", Description = "Macar de auto Ford",Year =2021},
                        new CarBrand { Id = 3, Name = "BMW", Description = "Macar de auto BMW",Year = 2020}
                    });
                    context.SaveChanges();
                }

                using (var context = new AppAssaContext(options))
                {
                    // Act
                    var controller = new CarBrandController(context);
                    var result = controller.Get();

                    // Assert
                    // Verify that the result is not null
                    Assert.NotNull(result);
                    Assert.IsType<List<CarBrand>>(result); // Verify that the result is a CarBrand list
                    var carBrands = result as List<CarBrand>;
                    Assert.Equal(3, carBrands.Count); // Check if all previously added car marks are returned

                }
            }
        }
    }
