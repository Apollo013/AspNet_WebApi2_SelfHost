using OWINSelfHost.Models.Models;
using OWINSelfHost.Server.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace OWINSelfHost.Server.Repository
{
    public class CompanyRepository
    {
        private static List<Company> CompanyList = new List<Company>
        {
            new Company { Name = "Microsoft" },
            new Company { Name = "Google" },
            new Company { Name = "Apple" },
            new Company { Name = "Mozilla" },
            new Company { Name = "Xamarin" },
            new Company { Name = "LinkedIn" }
        };

        /// <summary>
        /// Gets a single Company object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>        
        public Company Get(int id)
        {
            // Make sure company already exists
            var existingCompany = CompanyList.FirstOrDefault(c => c.Id == id);            

            if (existingCompany == null)
            {
                throw new ObjectNotFoundException("Company not found");
            }

            return existingCompany;
        }

        /// <summary>
        /// Gets all Company objects
        /// </summary>
        /// <returns></returns>
        public List<Company> Get()
        {
            return CompanyList;
        }

        /// <summary>
        /// Creates a Company object
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Create(Company model)
        {
            // Make sure we were not passed null
            if(model == null)
            {
                throw new NullReferenceException("Arguement Null");
            }

            // Check if company already exists
            var companyExists = CompanyList.Any(c => c.Id == model.Id);

            if (companyExists)
            {
                throw new ObjectExistsException("Company already Exists");
            }

            // We're good to go
            CompanyList.Add(model);
            return true;
        }

        /// <summary>
        /// Updates a Company object
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Company model)
        {
            // Make sure we were not passed null
            if (model == null)
            {
                throw new NullReferenceException("Arguement Null");
            }

            // Make sure company already exists
            var existingCompany = CompanyList.FirstOrDefault(c => c.Id == model.Id);

            if (existingCompany == null)
            {
                throw new ObjectNotFoundException("Company not found");
            }

            // We're good to go
            existingCompany.Name = model.Name;
            return true;
        }

        /// <summary>
        /// Deletes a Company object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            // Make sure company already exists
            var existingCompany = CompanyList.FirstOrDefault(c => c.Id == id);
            
            if (existingCompany == null)
            {
                throw new ObjectNotFoundException("Company not found");
            }

            // We're good to go
            CompanyList.Remove(existingCompany);
            return true;
        }
    }
}
