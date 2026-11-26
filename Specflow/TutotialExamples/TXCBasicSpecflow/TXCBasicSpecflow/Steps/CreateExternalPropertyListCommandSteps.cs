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
    public class CreateExternalPropertyListCommandSteps
    {
        private CreateExternalPropertyListCommand _createExternalPropertyListCommand;
        private Response<int> _createExternalPropertyResponse;

        public CreateExternalPropertyListCommandSteps(CreateExternalPropertyListCommand createExternalPropertyListCommand)
        {
            _createExternalPropertyListCommand = createExternalPropertyListCommand;
        }

        /*[When(@"I send update product external property value request")]
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

                _createExternalPropertyListCommand.ProductId = int.Parse(DataManager.GetData().parameters["ProductId"]);
                _createExternalPropertyListCommand.ProductExternalPropertyList = new List<ProductExternalPropertyModel>();
                var data = new ProductExternalPropertyModel();
                data.PropertyName = DataManager.GetData().parameters["PropertyName"];
                data.PropertyValue = DataManager.GetData().parameters["PropertyValue"];
                data.Description = DataManager.GetData().parameters["Description"];
                _createExternalPropertyListCommand.ProductExternalPropertyList.Add(data);

                // [FromBody] format
                var serializeData = JsonConvert.SerializeObject(_createExternalPropertyListCommand);
                StringContent jsonContent = new StringContent(serializeData, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(uri, jsonContent);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                _createExternalPropertyResponse = JsonConvert.DeserializeObject<Response<int>>(content);

                DataManager.GetData().ResponseSuccess = _createExternalPropertyResponse.Success;
                DataManager.GetData().ResponseMessage = _createExternalPropertyResponse.Message;

            }
            catch (Exception ex)
            {
                DataManager.GetData().ResponseSuccess = false;
                DataManager.GetData().ResponseMessage = ex.Message;
            }
        }*/

        [When(@"I send update product external property value request")]
        public async Task Excute()
        {
            ApiSteps.ExecuteAPI<UpdateTxProductPriceCommand>(HttpMethod.Post);
        }
    }
}
