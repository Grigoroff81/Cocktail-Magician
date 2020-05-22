﻿using CocktailMagician.Data;
using CocktailMagician.Models;
using CocktailMagician.Services;
using CocktailMagician.Services.DTOs;
using CocktailMagician.Services.Mappers.Contracts;
using CocktailMagician.Services.Providers.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.ServiceTests.CityServiceTests
{
    [TestClass]
    public class DeleteCityAsync_Should
    {
        [TestMethod]
        public async Task ReturnFalse_CityDoesNotExistOrDeleted()
        {
            //Arrange
            var mockIDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockICityMapper = new Mock<ICityMapper>();

            var options = Utils.GetOptions(nameof(ReturnFalse_CityDoesNotExistOrDeleted));

            var city = Utils.ReturnOneCity(options);

            using (var arrangeContext = new CocktailMagicianContext(options))
            {
                arrangeContext.Cities.Add(city);
                await arrangeContext.SaveChangesAsync();
            }
            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new CityService(mockIDateTimeProvider.Object, assertContext, mockICityMapper.Object);

                var result = await sut.DeleteCityAsync(2);

                Assert.IsFalse(result);
            }
        }

        [TestMethod]
        public async Task ReturnTrue_WhenDeletedSuccessfully()
        {
            //Arrange
            var mockIDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockICityMapper = new Mock<ICityMapper>();

            var options = Utils.GetOptions(nameof(ReturnTrue_WhenDeletedSuccessfully));

            var city = Utils.ReturnOneCity(options);

            using (var arrangeContext = new CocktailMagicianContext(options))
            {
                arrangeContext.Cities.Add(city);
                await arrangeContext.SaveChangesAsync();
            }
            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new CityService(mockIDateTimeProvider.Object, assertContext, mockICityMapper.Object);

                var result = await sut.DeleteCityAsync(1);
                var deletedCity = await assertContext.Cities.FirstOrDefaultAsync(c => c.Id == 1);

                Assert.IsTrue(result);
                Assert.AreEqual(true, deletedCity.IsDeleted);
            }
        }
    }
}