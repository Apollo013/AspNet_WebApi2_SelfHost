using OWINSelfHost.Models.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace OWINSelfHost.Client.Clients
{
    public class CompanyClient
    {

        private string hostUri;

        public CompanyClient(string hostUri)
        {
            this.hostUri = hostUri;
        }

        public HttpClient CreateClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(new Uri(hostUri), "api/company/");
            return client;
        }

        public IEnumerable<Company> Get()
        {
            HttpResponseMessage response;
            using (var client = CreateClient())
            {
                response = client.GetAsync(client.BaseAddress).Result;
            }
            var result = response.Content.ReadAsAsync<IEnumerable<Company>>().Result;
            return result;
        }

        public Company Get(int id)
        {
            HttpResponseMessage response;
            using (var client = CreateClient())
            {
                var uri = new Uri(client.BaseAddress, id.ToString());
                response = client.GetAsync(uri).Result;
            }
            var result = response.Content.ReadAsAsync<Company>().Result;
            return result;
        }


        public System.Net.HttpStatusCode Create(Company company)
        {
            HttpResponseMessage response;
            using (var client = CreateClient())
            {
                response = client.PostAsJsonAsync(client.BaseAddress, company).Result;
            }
            return response.StatusCode;
        }


        public System.Net.HttpStatusCode Update(Company company)
        {
            HttpResponseMessage response;
            using (var client = CreateClient())
            {
                response = client.PutAsJsonAsync(client.BaseAddress, company).Result;
            }
            return response.StatusCode;
        }


        public System.Net.HttpStatusCode Delete(int id)
        {
            HttpResponseMessage response;
            using (var client = CreateClient())
            {
                response = client.DeleteAsync(new Uri(client.BaseAddress, id.ToString())).Result;
            }
            return response.StatusCode;
        }
    }
}

