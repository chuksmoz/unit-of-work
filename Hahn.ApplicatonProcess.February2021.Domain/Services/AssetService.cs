using AutoMapper;
using Hahn.ApplicatonProcess.February2021.Domain.Entities;
using Hahn.ApplicatonProcess.February2021.Domain.Exceptions;
using Hahn.ApplicatonProcess.February2021.Domain.interfaces;
using Hahn.ApplicatonProcess.February2021.Domain.ViewModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Hahn.ApplicatonProcess.February2021.Domain.ViewModel.Dto;

namespace Hahn.ApplicatonProcess.February2021.Domain.Services
{
    public class AssetService : IAssetService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AssetService> _logger;
        public AssetService(IUnitOfWork unitOfWork, ILogger<AssetService> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }


        public async Task DeleteAsset(int id)
        {
            try
            {
                var asset = await _unitOfWork.Assets.GetById(id);
                if (asset is null)
                {

                }
                await _unitOfWork.Assets.Delete(asset);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Asset>> GetAllAsset()
        {
            try
            {
                _logger.LogInformation("Fetching asset ...");
                return await _unitOfWork.Assets.GetAll();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Asset> GetAssetById(int id)
        {
            ErrorResponse error = new();
            try
            {
                return await _unitOfWork.Assets.GetById(id);
            }
            catch (Exception ex)
            {

                //data = null;
                error.Errors.Add(ex.Message);
                _logger.LogError(ex.ToString());
                return null;
            }
        }


        public async Task<Tuple<ErrorResponse, Asset>> CreateAsset(CreateAssetDto assetDto)
        {
            Asset data = new();
            ErrorResponse error = new();
            try
            {
                _logger.LogInformation("Creating asset ...");

                //var asset = _mapper.Map<CreateAssetDto, Asset>(assetDto);
                Asset asset = new()
                {
                    AssetName = assetDto.AssetName,
                    PurchaseDate = assetDto.PurchaseDate,
                    Broken = assetDto.Broken,
                    CountryOfDepartment = assetDto.CountryOfDepartment,
                    Department = assetDto.Department,
                    EMailAdressOfDepartment = assetDto.EMailAdressOfDepartment
                };

                await _unitOfWork.Assets.Add(asset);
                await _unitOfWork.SaveAsync();
                data = asset;

                _logger.LogInformation("Created asset successfully");
            }
            catch (Exception ex)
            {
                data = null;
                error.Errors.Add(ex.Message);
                _logger.LogError(ex.ToString());
            }
            return new Tuple<ErrorResponse, Asset>(error, data);
        }

        public async Task<Tuple<ErrorResponse, Asset>> UpdateAsset(int id, UpdateAssetDto assetDto)
        {
            Asset data = new();
            ErrorResponse error = new();
            try
            {
                data = await _unitOfWork.Assets.GetById(id);
                if (data is null)
                {
                    _logger.LogInformation($"asset with id {id} not found ...");

                    throw new CustomException($"Invalid asset.");
                }

                _logger.LogInformation("Updating asset ...");


                

                data.CountryOfDepartment = assetDto.CountryOfDepartment;
                data.AssetName = assetDto.AssetName;
                data.Broken = assetDto.Broken;
                data.Department = assetDto.Department;
                data.PurchaseDate = assetDto.PurchaseDate;

                await _unitOfWork.Assets.Upsert(data);
                await _unitOfWork.SaveAsync();

                _logger.LogInformation("Updated Asset Successfully ...");

            }
            catch (Exception ex)
            {

                data = null;
                error.Errors.Add(ex.Message);
                _logger.LogError(ex.ToString());
            }

            return new Tuple<ErrorResponse, Asset>(error, data);
        }
    }

}