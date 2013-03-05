using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JQueryDataTables.Models;
using JQueryDataTables.Models.Repository;

namespace JQueryDataTables.Services
{
    public class CompanyService : ICompanyService
    {
        private ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyrepository)
        {
            _companyRepository = companyrepository;
        }
        
        public Company GetCompanyDetails(string id)
        {
            return _companyRepository.GetCompanyDetails(id);
        }


        public IEnumerable<Company> GetCompanies()
        {
            return _companyRepository.GetCompanies();
        }


        public IEnumerable<Company> DeleteCompanies(string id)
        {
            return _companyRepository.DeleteCompanies(id);
        }
    }

    public interface ICompanyService
    {
        Company GetCompanyDetails(string id);
        IEnumerable<Company> GetCompanies();
        IEnumerable<Company> DeleteCompanies(string id);
    }
}