
using FluentAssertions;
using Hahn.ApplicatonProcess.February2021.Domain.Entities;
using Hahn.ApplicatonProcess.February2021.Domain.Enums;
using Hahn.ApplicatonProcess.February2021.Domain.Extension;
using Hahn.ApplicatonProcess.February2021.Domain.interfaces;
using Hahn.ApplicatonProcess.February2021.Domain.ViewModel;
using Hahn.ApplicatonProcess.February2021.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static Hahn.ApplicatonProcess.February2021.Domain.ViewModel.Dto;

namespace Hahn.ApplicationProcess.Application.Test.IntegrationTest
{
    public class AssetControllerTest
    {

        private readonly Mock<IAssetService> assetService = new();
        [Fact]
        public async Task GetAssetAsync_WithUnExistingAsset_ReturnsNotFound()
        {
            //Arrange

            assetService.Setup(x => x.GetAssetById(It.IsAny<int>())).ReturnsAsync((Asset)null);

            var assetControllerSub = new AssetsController(assetService.Object);


            //Action

            var result = await assetControllerSub.GetAssetById(1);


            //Assert
            result.Result.Should().BeOfType(typeof(NotFoundResult));
        }


        [Fact]
        public async Task GetAssetAsync_WithExistingAsset_ReturnsExpectedItem()
        {
            //Arrange
            var expectedAsset = CreateRandomAsset();
            assetService.Setup(x => x.GetAssetById(It.IsAny<int>())).ReturnsAsync(expectedAsset);

            var assetControllerSub = new AssetsController(assetService.Object);


            //Action

            var result = await assetControllerSub.GetAssetById(1);


            //Assert
            var asset = (result.Result as OkObjectResult).Value as Asset;
            result.Result.Should().BeOfType(typeof(OkObjectResult));
            asset.Should().BeEquivalentTo(expectedAsset);
        }


        [Fact]
        public async Task CreatAssetAsync_WithAssetToCreate_ReturnsCreatedAsset()
        {
            //Arrange
            var assetToCreate = CreateRandomAssetDto();
            assetService.Setup(x => x.CreateAsset(It.IsAny<CreateAssetDto>())).ReturnsAsync(new Tuple<ErrorResponse, Asset>(null, assetToCreate.ToAsset()));
            
            var assetControllerSub = new AssetsController(assetService.Object);


            //Action

            var result = await assetControllerSub.CreateAsset(assetToCreate);


            //Assert
            var asset = (result.Result as CreatedAtActionResult).Value as Asset;
            result.Result.Should().BeOfType(typeof(CreatedAtActionResult));
            asset.Should().BeEquivalentTo(assetToCreate.ToAsset());
        }

        private CreateAssetDto CreateRandomAssetDto()
        {
            return new CreateAssetDto(Guid.NewGuid().ToString(), "test@test.com", Department.HQ, "Germany", DateTimeOffset.UtcNow, true);
            
        }

        private Asset CreateRandomAsset()
        {
            return new Asset()
            {
                ID= new Random().Next(99),
                AssetName = Guid.NewGuid().ToString(),
                Broken = true,
                CountryOfDepartment = "Germany",
                Department = Department.HQ,
                EMailAdressOfDepartment = "test@test.com",
                PurchaseDate = DateTimeOffset.UtcNow

            };
        }
    }
}
