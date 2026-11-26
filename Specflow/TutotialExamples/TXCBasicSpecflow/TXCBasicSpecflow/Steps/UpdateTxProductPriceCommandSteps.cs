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
    public class UpdateTxProductPriceCommandSteps
    {
        private UpdateTxProductPriceCommand _updateTxProductPriceCommand;
        private Response<int> _updateProductPriceResponse;

        public UpdateTxProductPriceCommandSteps(UpdateTxProductPriceCommand updateTxProductPriceCommand)
        {
            _updateTxProductPriceCommand = updateTxProductPriceCommand;
        }

        /*[When(@"I send update product price value request")]
        public async Task Excute()
        {
            try
            {
                Uri uri = new Uri(DataManager.GetData().URL);

                HttpClient _httpClient = new HttpClient();
                _httpClient.DefaultRequestHeaders.Add("TenantName", DataManager.GetData().parameters["TenantName"]);
                _httpClient.DefaultRequestHeaders.Add("TenantBasicInfoId", DataManager.GetData().parameters["TenantBasicInfoId"].ToString());

                if (DataManager.GetData().parameters.ContainsKey("TX2UserName"))
                    _httpClient.DefaultRequestHeaders.Add("TX2UserName", DataManager.GetData().parameters["TX2UserName"].ToString());

                _updateTxProductPriceCommand.ProductId = int.Parse(DataManager.GetData().parameters["ProductId"]);
                _updateTxProductPriceCommand.FaceValue = int.Parse(DataManager.GetData().parameters["FaceValue"]);
                _updateTxProductPriceCommand.FaceValueWithTax = int.Parse(DataManager.GetData().parameters["FaceValueWithTax"]);
                _updateTxProductPriceCommand.SellingPricePrepaid = decimal.Parse(DataManager.GetData().parameters["SellingPricePrepaid"]);
                _updateTxProductPriceCommand.SellingPricePrepaidWithTax = decimal.Parse(DataManager.GetData().parameters["SellingPricePrepaidWithTax"]);

                // [FromBody] format
                var serializeData = JsonConvert.SerializeObject(_updateTxProductPriceCommand);
                StringContent jsonContent = new StringContent(serializeData, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync(uri, jsonContent);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                _updateProductPriceResponse = JsonConvert.DeserializeObject<Response<int>>(content);

                DataManager.GetData().ResponseSuccess = _updateProductPriceResponse.Success;
                DataManager.GetData().ResponseMessage = _updateProductPriceResponse.Message;

            }
            catch (Exception ex)
            {
                DataManager.GetData().ResponseSuccess = false;
                DataManager.GetData().ResponseMessage = ex.Message;
            }
        }*/
        [When(@"I send update product price value request")]
        public async Task Excute()
        {
            ApiSteps.ExecuteAPI<UpdateTxProductPriceCommand>(HttpMethod.Put);
        }
    }
}
