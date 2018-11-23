using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BasicBot.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace BasicBot.Services
{
    public class QnAService
    {
        private IConfiguration _configuration;
        private HttpClient _client = new HttpClient();

        public QnAService(IConfiguration config)
        {
            _configuration = config;
        }

        public async Task<QnAAnswer> GetQnAAnswer(string query)
        {
            var qnaUrl = _configuration.GetValue<string>("QnAPAth");
            var qnaAuthHeaderValue = _configuration.GetValue<string>("QnAAuthHeaderKeyValue");
            var body = new QnAQuery();
            body.question = query;

            var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            
            //_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("EndpointKey", qnaAuthHeaderValue);
            HttpRequestMessage msg = new HttpRequestMessage();
            msg.Content = content;
            msg.RequestUri = new System.Uri(qnaUrl);
            msg.Headers.Authorization = new AuthenticationHeaderValue("EndpointKey", qnaAuthHeaderValue);
            msg.Method = HttpMethod.Post;

            try { 
            HttpResponseMessage result = await _client.SendAsync(msg);
           
            QnAAnswer ret = JsonConvert.DeserializeObject<QnAAnswer>( await result.Content.ReadAsStringAsync());

            return ret;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }

    }
}
