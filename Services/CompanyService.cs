using EmplooyeesAPI.Dtos;
using EmplooyeesAPI.Entities;
using EmplooyeesAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmplooyeesAPI.Services
{
    public class CompanyService
    {
        private readonly CompanyRepository _companyRepository;
        public CompanyService(CompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<List<Company>> GetAllAsync()
        {
            return await _companyRepository.GetAllAsync();
        }

        public async Task<Company> GetByIdAsync(int id)
        {
            var company = await _companyRepository.GetByIdAsync(id);
            if (company == null)
            {
                throw new ArgumentException("Company does not exist");
            }
            return company;
        }

        public async Task CreateAsync(CompanyCreationDto company)
        {
            var entity = new Company()
            {
                Name = company.Name
            };
            await _companyRepository.CreateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var company = await GetByIdAsync(id);
            await _companyRepository.DeleteAsync(company);
        }

        public async Task UpdateCompanyAsync(CompanyEditDto company)
        {
            var existingCompany = await GetByIdAsync(company.Id);
            existingCompany.Id = company.Id;
            existingCompany.Name = company.Name;
            await _companyRepository.UpdateCompanyAsync(existingCompany);
        }
    }
}

