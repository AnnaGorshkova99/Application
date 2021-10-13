using Application.Controllers;
using Application.DataAccess;
using Application.Infrastructure.Repository;
using Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;

namespace Application.Tests
{
    public class SpecializationControllerTests
    {
        DbContextOptionsBuilder dbContextOptionsBuilder;
        BaseDbContext context;
        IRepository<Specialization> repository;

        public SpecializationControllerTests()
        {
            dbContextOptionsBuilder = new DbContextOptionsBuilder();
            dbContextOptionsBuilder.UseSqlServer("Server=DESKTOP-HKPJF0B\\SQLEXPRESS;Database=HotelDb;Trusted_Connection=True;");
            context = new BaseDbContext(dbContextOptionsBuilder.Options);

            repository = new Repository<Specialization>(context);
        }

        [Fact]
        public async void GetAdminViewResultNotNull()
        {
            // Arrange
            SpecializationController controller = new SpecializationController(repository);
            // Act
            ViewResult result = await controller.GetAdmin() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async void GetAdminViewNameEqualNull()
        {
            // Arrange
            SpecializationController controller = new SpecializationController(repository);
            // Act
            ViewResult result = await controller.GetAdmin() as ViewResult;
            // Assert
            Assert.Equal(null, result?.ViewName);
        }
    }
}
