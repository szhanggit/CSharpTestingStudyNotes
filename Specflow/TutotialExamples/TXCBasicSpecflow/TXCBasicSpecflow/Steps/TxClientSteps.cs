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
    public class TxClientSteps
    {
        private Response<int> _createTxClientResponse;
        private Response<ClientDto> _getTxClientListResponse;

        public TxClientSteps()
        {

        }

        [When(@"I send get client request")]
        public async Task WhenISendGetClientRequestAsync()
        {
            var input = new Dictionary<string, string>();

            #region optional params
            if (DataManager.GetData().parameters.ContainsKey("PageNumber"))
                input.Add("PageNumber", DataManager.GetData().parameters["PageNumber"]);

            if (DataManager.GetData().parameters.ContainsKey("RowCount"))
                input.Add("RowCount", DataManager.GetData().parameters["RowCount"]);

            if (DataManager.GetData().parameters.ContainsKey("SearchKey"))
                input.Add("SearchKeyword", DataManager.GetData().parameters["SearchKey"]);

            if (DataManager.GetData().parameters.ContainsKey("VoucherIssuer"))
                input.Add("VoucherIssuer", DataManager.GetData().parameters["VoucherIssuer"]);
            #endregion

            // [FromQuery] format
            Uri uri = new Uri(QueryHelpers.AddQueryString(DataManager.GetData().URL, input));

            HttpClient _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("TenantName", DataManager.GetData().parameters["TenantName"]);
            _httpClient.DefaultRequestHeaders.Add("TenantBasicInfoId", DataManager.GetData().parameters["TenantBasicInfoId"].ToString());

            if (DataManager.GetData().parameters.ContainsKey("TX2UserName"))
                _httpClient.DefaultRequestHeaders.Add("TX2UserName", DataManager.GetData().parameters["TX2UserName"].ToString());

            var response = await _httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            _getTxClientListResponse = JsonConvert.DeserializeObject<Response<ClientDto>>(content);

            DataManager.GetData().ResponseMessage = _getTxClientListResponse.Message;

        }

        [When(@"I send create client request")]
        public async Task WhenISendCreateClientRequestAsync()
        {

            Uri uri = new Uri(DataManager.GetData().URL);

            HttpClient _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("TenantName", DataManager.GetData().parameters["TenantName"]);
            _httpClient.DefaultRequestHeaders.Add("TenantBasicInfoId", DataManager.GetData().parameters["TenantBasicInfoId"].ToString());

            if (DataManager.GetData().parameters.ContainsKey("TX2UserName"))
                _httpClient.DefaultRequestHeaders.Add("TX2UserName", DataManager.GetData().parameters["TX2UserName"].ToString());

            // [FromForm] format
            var data = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("ClientName", DataManager.GetData().parameters["ClientName"]),
                new KeyValuePair<string, string>("InvoiceRegisterNumber", DataManager.GetData().parameters["InvoiceRegisterNumber"]),
                new KeyValuePair<string, string>("Status", DataManager.GetData().parameters["Status"]),
                new KeyValuePair<string, string>("SecurityAlgorithm", DataManager.GetData().parameters["SecurityAlgorithm"]),
                new KeyValuePair<string, string>("SecurityKey", DataManager.GetData().parameters["SecurityKey"]),
                new KeyValuePair<string, string>("NeedNotification", DataManager.GetData().parameters["NeedNotification"]),
                new KeyValuePair<string, string>("CanIssue", DataManager.GetData().parameters["CanIssue"]),
                new KeyValuePair<string, string>("DetailAddressLine", DataManager.GetData().parameters["DetailAddressLine"]),
                new KeyValuePair<string, string>("District", DataManager.GetData().parameters["District"]),
                new KeyValuePair<string, string>("CityId", DataManager.GetData().parameters["CityId"]),
                new KeyValuePair<string, string>("StateOrProvinceId", DataManager.GetData().parameters["StateOrProvinceId"]),
                new KeyValuePair<string, string>("Postcode", DataManager.GetData().parameters["Postcode"]),
                new KeyValuePair<string, string>("CountryId", DataManager.GetData().parameters["CountryId"]),
                new KeyValuePair<string, string>("AddressStatus", DataManager.GetData().parameters["AddressStatus"])
            };

            #region optional params
            if (DataManager.GetData().parameters.ContainsKey("VoucherIssuerId"))
                data.Add(new KeyValuePair<string, string>("VoucherIssuerId", DataManager.GetData().parameters["VoucherIssuerId"]));

            if (DataManager.GetData().parameters.ContainsKey("InvoiceTitle"))
                data.Add(new KeyValuePair<string, string>("InvoiceTitle", DataManager.GetData().parameters["InvoiceTitle"]));

            if (DataManager.GetData().parameters.ContainsKey("BusinessTypeId"))
                data.Add(new KeyValuePair<string, string>("BusinessTypeId", DataManager.GetData().parameters["BusinessTypeId"]));

            if (DataManager.GetData().parameters.ContainsKey("NotiNotificationProviderCodeId"))
                data.Add(new KeyValuePair<string, string>("NotiNotificationProviderCodeId", DataManager.GetData().parameters["NotiNotificationProviderCodeId"]));

            if (DataManager.GetData().parameters.ContainsKey("LogoMediaId"))
                data.Add(new KeyValuePair<string, string>("LogoMediaId", DataManager.GetData().parameters["LogoMediaId"]));

            if (DataManager.GetData().parameters.ContainsKey("BannerMediaId"))
                data.Add(new KeyValuePair<string, string>("BannerMediaId", DataManager.GetData().parameters["BannerMediaId"]));

            if (DataManager.GetData().parameters.ContainsKey("EmailHeaderMediaId"))
                data.Add(new KeyValuePair<string, string>("EmailHeaderMediaId", DataManager.GetData().parameters["EmailHeaderMediaId"]));

            if (DataManager.GetData().parameters.ContainsKey("EmailFooterMediaId"))
                data.Add(new KeyValuePair<string, string>("EmailFooterMediaId", DataManager.GetData().parameters["EmailFooterMediaId"]));

            if (DataManager.GetData().parameters.ContainsKey("MandatoryAutoBilling"))
                data.Add(new KeyValuePair<string, string>("MandatoryAutoBilling", DataManager.GetData().parameters["MandatoryAutoBilling"]));

            if (DataManager.GetData().parameters.ContainsKey("SubURL"))
                data.Add(new KeyValuePair<string, string>("SubURL", DataManager.GetData().parameters["SubURL"]));

            if (DataManager.GetData().parameters.ContainsKey("EmailProviderCode"))
                data.Add(new KeyValuePair<string, string>("EmailProviderCode", DataManager.GetData().parameters["EmailProviderCode"]));

            if (DataManager.GetData().parameters.ContainsKey("EmailSenderName"))
                data.Add(new KeyValuePair<string, string>("EmailSenderName", DataManager.GetData().parameters["EmailSenderName"]));

            if (DataManager.GetData().parameters.ContainsKey("EmailSenderAddress"))
                data.Add(new KeyValuePair<string, string>("EmailSenderAddress", DataManager.GetData().parameters["EmailSenderAddress"]));

            if (DataManager.GetData().parameters.ContainsKey("ApplyEmailSubject"))
                data.Add(new KeyValuePair<string, string>("ApplyEmailSubject", DataManager.GetData().parameters["ApplyEmailSubject"]));

            if (DataManager.GetData().parameters.ContainsKey("SMSProviderCode"))
                data.Add(new KeyValuePair<string, string>("SMSProviderCode", DataManager.GetData().parameters["SMSProviderCode"]));

            if (DataManager.GetData().parameters.ContainsKey("SMSSenderName"))
                data.Add(new KeyValuePair<string, string>("SMSSenderName", DataManager.GetData().parameters["SMSSenderName"]));

            if (DataManager.GetData().parameters.ContainsKey("SmsEntityId"))
                data.Add(new KeyValuePair<string, string>("SmsEntityId", DataManager.GetData().parameters["SmsEntityId"]));

            if (DataManager.GetData().parameters.ContainsKey("SalesEmail"))
                data.Add(new KeyValuePair<string, string>("SalesEmail", DataManager.GetData().parameters["SalesEmail"]));

            if (DataManager.GetData().parameters.ContainsKey("ContactName"))
                data.Add(new KeyValuePair<string, string>("ContactName", DataManager.GetData().parameters["ContactName"]));

            if (DataManager.GetData().parameters.ContainsKey("ContactEmail"))
                data.Add(new KeyValuePair<string, string>("ContactEmail", DataManager.GetData().parameters["ContactEmail"]));

            if (DataManager.GetData().parameters.ContainsKey("ContactPhone"))
                data.Add(new KeyValuePair<string, string>("ContactPhone", DataManager.GetData().parameters["ContactPhone"]));

            if (DataManager.GetData().parameters.ContainsKey("Memo"))
                data.Add(new KeyValuePair<string, string>("Memo", DataManager.GetData().parameters["Memo"]));

            if (DataManager.GetData().parameters.ContainsKey("Description"))
                data.Add(new KeyValuePair<string, string>("Description", DataManager.GetData().parameters["Description"]));

            if (DataManager.GetData().parameters.ContainsKey("Longitude"))
                data.Add(new KeyValuePair<string, string>("Longitude", DataManager.GetData().parameters["Longitude"]));

            if (DataManager.GetData().parameters.ContainsKey("Latitude"))
                data.Add(new KeyValuePair<string, string>("Latitude", DataManager.GetData().parameters["Latitude"]));
            #endregion

            var response = await _httpClient.PostAsync(uri, new FormUrlEncodedContent(data));
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            _createTxClientResponse = JsonConvert.DeserializeObject<Response<int>>(content);

            DataManager.GetData().ResponseMessage = _createTxClientResponse.Message;

        }
    }
}
