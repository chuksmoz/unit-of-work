using Hahn.ApplicatonProcess.February2021.Domain.Entities;
using Hahn.ApplicatonProcess.February2021.Domain.interfaces;
using Hahn.ApplicatonProcess.February2021.Domain.ViewModel;
using Hahn.ApplicatonProcess.February2021.Web.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Hahn.ApplicatonProcess.February2021.Domain.ViewModel.Dto;

namespace Hahn.ApplicatonProcess.February2021.Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    //[ServiceFilter(typeof(ValidationActionFilter))]
    public class AssetsController : ControllerBase
    {
        private readonly IAssetService _assetService;
        public AssetsController(IAssetService assetService)
        {
            _assetService = assetService;
        }

        [HttpGet]
        public async Task<IEnumerable<Asset>> GetAllAssets()
        {
            return await _assetService.GetAllAsset();
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Asset), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<ActionResult<Asset>> GetAssetById(int id)
        {
            var asset =  await _assetService.GetAssetById(id);
            if (asset is null)
            {
                return NotFound();
            }
            return Ok(asset);
        }

        /// <summary>
        /// Creates an Asset.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     
        ///     { 
        ///        "AssetName": "pictures",
        ///        "Broken": true,
        ///        "CountryOfDepartment": "Nigeria",
        ///        "Department": 1
        ///        "PurchaseDate": "07/04/2021"
        ///     }
        /// </remarks>
        /// <param name="asset"></param> 
        [HttpPost]
        [ProducesResponseType(typeof(Asset), 201)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<ActionResult<Asset>> CreateAsset(CreateAssetDto asset)
        {
            var (error, data) = await _assetService.CreateAsset(asset);
            if (error != null && error.Errors.Count > 0)
            {
                return BadRequest(error);
            }
            return CreatedAtAction(nameof(GetAssetById), new { id = data.ID }, data);
        }


        /// <summary>
        /// Update an Asset.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     
        ///     { 
        ///        "assetName": "pictures",
        ///        "broken": true,
        ///        "CountryOfDepartment": "Nigeria",
        ///        "department": 1,
        ///        "eMailAdressOfDepartment": "test@test.com"
        ///        "purchaseDate": "07/04/2021"
        ///     }
        /// </remarks>
        /// <param name="id"></param> 
        /// <param name="asset"></param> 
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Asset), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<ActionResult<Asset>> UpdateAsset(int id, UpdateAssetDto asset)
        {
            var (error, data) = await _assetService.UpdateAsset(id, asset);
            if (error != null && error.Errors.Count > 0)
            {
                return BadRequest(error);
            }
            return Ok(data);
        }

        /// <param name="id"></param> 
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> DeleteAsset(int id)
        {
            await _assetService.DeleteAsset(id);

            return Ok();
        }

    }
}
