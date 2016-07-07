using OWINSelfHost.Client.Clients;
using OWINSelfHost.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OWINSelfHost.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Read all the companies...");
            var companyClient = new CompanyClient("http://localhost:8080");
            
            var companies = companyClient.Get();
            WriteCompaniesList(companies);

            //int nextId = (from c in companies select c.Id).Max() + 1;
            //Console.WriteLine(nextId);

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Add a new company...");
            Console.WriteLine("---------------------------------------------");
            var result = companyClient.Create(
                new Company()
                {
                    Name = string.Format("Howya Mary !!!")
                });
            WriteStatusCodeResult(result);

            Console.WriteLine("Updated List after Add:");
            companies = companyClient.Get();
            WriteCompaniesList(companies);

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Update a company...");
            Console.WriteLine("---------------------------------------------");
            var updateMe = companyClient.Get(3);
            updateMe.Name = "Howya Henry !!!";
            result = companyClient.Update(updateMe);
            WriteStatusCodeResult(result);

            Console.WriteLine("Updated List after Update:");
            companies = companyClient.Get();
            WriteCompaniesList(companies);


            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Delete a company...");
            Console.WriteLine("---------------------------------------------");
            result = companyClient.Delete(2);
            WriteStatusCodeResult(result);

            Console.WriteLine("Updated List after Delete:");
            companies = companyClient.Get();
            WriteCompaniesList(companies);

            Console.Read();
        }

        static void WriteCompaniesList(IEnumerable<Company> companies)
        {
            foreach (var company in companies)
            {
                Console.WriteLine($"Id: {company.Id} Name: {company.Name}");
            }
            Console.WriteLine("");
        }

        static void WriteStatusCodeResult(System.Net.HttpStatusCode statusCode)
        {
            if (statusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine($"Opreation Succeeded - status code {statusCode}");
            }
            else
            {
                Console.WriteLine($"Opreation Failed - status code {statusCode}");
            }
            Console.WriteLine("");
        }
    }
}
