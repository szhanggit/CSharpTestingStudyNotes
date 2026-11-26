using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using ProductServices.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TXCBasicSpecflow.Factory;

namespace TXCBasicSpecflow.Steps
{
    [Binding]
    public class GetBrandByProductIdSteps
    {
        private GetProductBrandQuery _getProductBrandQuery;
        private Response<BrandDto> _getProductBrandResponse;
        public GetBrandByProductIdSteps(GetProductBrandQuery getProductBrandQuery)
        {
            _getProductBrandQuery = getProductBrandQuery;
        }

        /*[When(@"I send get brand by product ID request")]
        public async Task WhenISendGetBrandByProductIDRequestAsync()
        {
            try
            {
                // [FromQuery] format
                var query = new Dictionary<string, string>
                {
                    ["ProductId"] = DataManager.GetData().parameters["ProductId"]
                };

                Uri uri = new Uri(QueryHelpers.AddQueryString(DataManager.GetData().URL, query));

                HttpClient _httpClient = new HttpClient();

                _httpClient.DefaultRequestHeaders.Add("TenantName", DataManager.GetData().parameters["TenantName"]);
                _httpClient.DefaultRequestHeaders.Add("TenantBasicInfoId", DataManager.GetData().parameters["TenantBasicInfoId"].ToString());

                if (DataManager.GetData().parameters.ContainsKey("TX2UserName"))
                    _httpClient.DefaultRequestHeaders.Add("TX2UserName", DataManager.GetData().parameters["TX2UserName"].ToString());

                var response = await _httpClient.GetAsync(uri);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                _getProductBrandResponse = JsonConvert.DeserializeObject<Response<BrandDto>>(content);

                DataManager.GetData().ResponseSuccess = _getProductBrandResponse.Success;
                DataManager.GetData().ResponseMessage = _getProductBrandResponse.Message;
            }
            catch (Exception ex)
            {
                DataManager.GetData().ResponseSuccess = false;
                DataManager.GetData().ResponseMessage = ex.Message;
            }
        }*/

        [When(@"I send get brand by product ID request")]
        public async Task WhenISendGetBrandByProductIDRequestAsync()
        {
            ApiSteps.ExecuteAPI<GetProductBrandQuery>(HttpMethod.Get);
        }
    }
}
