using FluentValidation;
using Hahn.ApplicatonProcess.February2021.Domain.Entities;
using Hahn.ApplicatonProcess.February2021.Domain.interfaces;
using Hahn.ApplicatonProcess.February2021.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Hahn.ApplicatonProcess.February2021.Domain.ViewModel.Dto;

namespace Hahn.ApplicatonProcess.February2021.Domain.Validations
{
    public class AssetValidator: AbstractValidator<CreateAssetDto>
    {
        private readonly ICountryValidatorService _countryValidatorService;
        public AssetValidator(ICountryValidatorService countryValidatorService)
        {
            _countryValidatorService = countryValidatorService;

            RuleFor(a => a.AssetName)
                .NotEmpty()
                .MinimumLength(5);

            RuleFor(a => a.Department)
                .IsInEnum();

            RuleFor(a => a.EMailAdressOfDepartment)
                .NotEmpty()
                .EmailAddress();

            RuleFor(a => a.PurchaseDate)
                .GreaterThanOrEqualTo(DateTime.Now.AddYears(-1));

            RuleFor(a => a.Broken)
                .NotNull();

            RuleFor(a => a.CountryOfDepartment)
                .NotEmpty()
                .MustAsync(async (countryName, cancellation) =>
                {
                    return await _countryValidatorService.ValidateCountryByName(countryName);
                });
        }
    }
}
