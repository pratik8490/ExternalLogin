using ExternalLogin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ExternalLogin.Services
{
    public class AuthenticationServices
    {
        private readonly string _baseUri;

        public AuthenticationServices(string baseUri)
        {
            _baseUri = baseUri;
        }

        public string BaseUri { get { return _baseUri; } }

        public string AccessToken { get; set; }

        public async Task<IEnumerable<ExternalLoginViewModel>> GetExternalLoginProviders()
        {
            List<ExternalLoginViewModel> models = new List<ExternalLoginViewModel>();

            using (HttpClient client = new HttpClient { BaseAddress = new Uri(_baseUri) })
            {
                try
                {
                    string requestUri = "/api/Account/ExternalLogins?returnUrl=%2F&generateState=true";
                    HttpResponseMessage httpResponse = await client.GetAsync(requestUri);

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        string result = await httpResponse.Content.ReadAsStringAsync();
                        models = JsonConvert.DeserializeObject<List<ExternalLoginViewModel>>(result);
                    }
                    return models;
                }
                catch (SecurityException)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("Unable to get login providers", ex);
                }
            }
        }

        public async Task RegisterExternal(string username)
        {
            string uri = String.Format("{0}/api/Account/RegisterExternal", BaseUri);

            RegisterExternalBindingModel model = new RegisterExternalBindingModel
            {
                UserName = username
            };

            string postJson = JsonConvert.SerializeObject(model);
            var content = new StringContent(postJson, Encoding.UTF8, "application/json");

            try
            {
                using (HttpClient client = new HttpClient { BaseAddress = new Uri(_baseUri) })
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", AccessToken);

                    HttpResponseMessage response = await client.PostAsync(uri, content).ConfigureAwait(true);

                    if (response.IsSuccessStatusCode)
                    {

                    }
                }
            }
            catch (SecurityException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Unable to register user", ex);
            }
        }
    }
}
