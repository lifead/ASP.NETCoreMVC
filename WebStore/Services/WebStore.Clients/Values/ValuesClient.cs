using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebStore.Clients.Base;
using WebStore.Interfaces.Api;

namespace WebStore.Clients.Values
{
    class ValuesClient :BaseClient, IValuesService
    {
        public ValuesClient(IConfiguration Configuration) : base(Configuration, "api/values"){}

        public HttpStatusCode Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<HttpStatusCode> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> Get()
        {
            throw new NotImplementedException();
        }

        public string Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Uri Post(string value)
        {
            throw new NotImplementedException();
        }

        public Task<Uri> PostAsync(string value)
        {
            throw new NotImplementedException();
        }

        public HttpStatusCode Put(int id, string value)
        {
            throw new NotImplementedException();
        }

        public Task<HttpStatusCode> PutAsync(int id, string value)
        {
            throw new NotImplementedException();
        }
    }
}
