using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JQueryDataTables.Models;

namespace JQueryDataTables.Models.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        public Company GetCompanyDetails(string id)
        {
            var c = DataRepository.GetCompanies().Where(i => i.Town == "Kent").OrderByDescending(o => o.ID).FirstOrDefault(); 
            c.ID = int.Parse(id.Trim());
            return c;
        }

        public IEnumerable<Company>  GetCompanies()
        {
            var companyData = new List<Company>();
            companyData.Add(new Company() { Name = "Emkay Entertainments", Address = "Nobel House, Regent Centre", Town = "Lothian" });
            companyData.Add(new Company() { Name = "The Empire", Address = "Milton Keynes Leisure Plaza", Town = "Buckinghamshire" });
            companyData.Add(new Company() { Name = "Asadul Ltd", Address = "Hophouse", Town = "Essex" });
            companyData.Add(new Company() { Name = "Gargamel ltd", Address = "", Town = "" });
            companyData.Add(new Company() { Name = "Ashley Mark Publishing Company", Address = "1-2 Vance Court", Town = "Tyne & Wear" });
            companyData.Add(new Company() { Name = "MuchMoreMusic Studios", Address = "Unit 29", Town = "London" });
            companyData.Add(new Company() { Name = "Victoria Music Ltd", Address = "Unit 215", Town = "London" });
            companyData.Add(new Company() { Name = "Abacus Agent", Address = "Regent Street", Town = "London" });
            companyData.Add(new Company() { Name = "Atomic", Address = "133 Longacre", Town = "London" });
            companyData.Add(new Company() { Name = "Pyramid Posters", Address = "The Works", Town = "Leicester" });
            companyData.Add(new Company() { Name = "Kingston Smith Financial Services Ltd", Address = "105 St Peter's Street", Town = "Herts" });
            companyData.Add(new Company() { Name = "Garrett Axford PR", Address = "Harbour House", Town = "West Sussex" });
            companyData.Add(new Company() { Name = "Derek Boulton Management", Address = "76 Carlisle Mansions", Town = "London" });
            companyData.Add(new Company() { Name = "Total Concept Management (TCM)", Address = "PO Box 128", Town = "West Yorks" });
            companyData.Add(new Company() { Name = "Billy Russell Management", Address = "Binny Estate", Town = "Edinburgh" });
            companyData.Add(new Company() { Name = "Stage Audio Services", Address = "Unit 2", Town = "Stourbridge" });
            companyData.Add(new Company() { Name = "Windsong International", Address = "Heather Court", Town = "Kent" });
            companyData.Add(new Company() { Name = "Vivante Music Ltd", Address = "32 The Netherlands", Town = "Surrey" });
            return companyData;
        }


        public IEnumerable<Company> DeleteCompanies(string id)
        {
            var companies = GetCompanies().ToList();
            var co = companies.Where(c => c.ID == int.Parse(id)).FirstOrDefault();
            companies.Remove(co);
            return companies;
        }
	
	public void FromtheOriginalCode()
	{}
    }

    public interface ICompanyRepository
    {
        Company GetCompanyDetails(string id);
        IEnumerable<Company> GetCompanies();
        IEnumerable<Company> DeleteCompanies(string id);
    }
}