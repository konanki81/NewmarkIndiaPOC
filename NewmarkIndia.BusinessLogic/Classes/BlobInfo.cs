using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NewmarkIndia.BusinessLogic.Interfaces;
using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace NewmarkIndia.BusinessLogic.Classes
{
    public class BlobInfo : IBlobInfo
    {
        private readonly HttpClient _httpClient;
        private readonly BlobUrlInfo _blobUrlInfo;
        private readonly ILogger<BlobInfo> _logger;
        public BlobInfo (HttpClient httpClient, IOptions<BlobUrlInfo> blobUrlInfo, ILogger<BlobInfo> logger)
        {
            _httpClient = httpClient;
            _blobUrlInfo = blobUrlInfo.Value;
            _logger= logger;
        }
        public async Task<IEnumerable<BlobReponse>?> GetBlobInfoAsync()
        {
            var baseUrl = _blobUrlInfo.BaseUrl;
            var sasToken = _blobUrlInfo.SasToken;
            var url = $"{baseUrl}{sasToken}";
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation("GetBlobInfoAsync Method ran suucessfully");
                var blobResponse = await response.Content.ReadFromJsonAsync<IEnumerable< BlobReponse>>();
                if(blobResponse != null)
                return blobResponse;
            }
            else
            {
                _logger.LogInformation($"GetBlobInfoAsync Method ran failed with status code:{response.StatusCode} ");
            }

                return default;
        }
    }
}
