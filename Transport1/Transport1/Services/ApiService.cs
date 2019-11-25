using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Transport1.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Transport1.Services
{
    public class ApiService
    {

        public async Task<bool> RegisterAsync(string email, string password, string confirmPassord)
        {
            var client = new HttpClient();
            var model = new RegisterBindingModel
            {
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassord,
        };
            var json = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("Application/json");
            var response = await client.PostAsync("http://localhost:5000/api/Account/Register", content);
            return response.IsSuccessStatusCode;
        }
    }
}
