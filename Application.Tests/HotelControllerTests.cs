using Application.Controllers;
using Application.DataAccess;
using Application.Infrastructure.Repository;
using Application.Models;
using Application.Services.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests
{
    public class HotelControllerTests
    {
        DbContextOptionsBuilder dbContextOptionsBuilder;
        BaseDbContext context;
        IRepository<Hotel> repository;
        IHotelRepository superRepository;

        public HotelControllerTests()
        {
            dbContextOptionsBuilder = new DbContextOptionsBuilder();
            dbContextOptionsBuilder.UseSqlServer("Server=DESKTOP-HKPJF0B\\SQLEXPRESS;Database=HotelDb;Trusted_Connection=True;");
            context = new BaseDbContext(dbContextOptionsBuilder.Options);

            repository = new Repository<Hotel>(context);
            superRepository = new HotelRepository(context);
        }

        [Fact]
        public void GetAdminViewResultNotNull()
        {
            // Arrange
            HotelController controller = new HotelController(superRepository, repository);
            // Act
            ViewResult result = controller.GetAdmin() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetAdminViewNameEqualNull()
        {
            // Arrange
            HotelController controller = new HotelController(superRepository, repository);
            // Act
            ViewResult result = controller.GetAdmin() as ViewResult;
            // Assert
            Assert.Equal(null, result?.ViewName);
        }
    }
}
