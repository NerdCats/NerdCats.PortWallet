namespace NerdCats.PortWallet
{
    using System;
    using System.Net.Http;
    using NerdCats.PortWallet.Request;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Linq;
    using System.Text;
    using Newtonsoft.Json;
    using System.Security.Cryptography;
    using System.Linq;
    using System.Collections.Generic;

    public class WalletClient : IDisposable
    {
        private bool disposed = false;
        private HttpClient httpClient;
        private string appKey;
        private string secretKey;
        private Uri apiBase;

        private Func<Int32> getUnixTimestamp = () => (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

        public WalletClient(string apiBase, string appKey, string secretKey)
        {
            if (string.IsNullOrWhiteSpace(apiBase))
                throw new ArgumentException("Null, empty or whitespace parameter", nameof(apiBase));

            if (!TryParseUri(apiBase, out Uri uri))
            {
                throw new ArgumentException("Malformed/Invalid api base url provided", nameof(apiBase));
            }

            this.apiBase = uri;

            if (string.IsNullOrWhiteSpace(appKey))
                throw new ArgumentException("Null, empty or whitespace parameter", nameof(appKey));

            if (string.IsNullOrWhiteSpace(secretKey))
                throw new ArgumentException("Null, empty or whitespace parameter", nameof(secretKey));

            this.appKey = appKey;
            this.secretKey = secretKey;

            this.httpClient = new HttpClient();
        }

        public async Task<WalletResponse<WalletInvoice>> GenerateInvoice(InvoiceRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var jsonReq = JObject.FromObject(request);
            jsonReq["app_key"] = this.appKey;

            var timestamp = getUnixTimestamp();
            jsonReq["timestamp"] = timestamp;
            jsonReq["token"] = CalculateMD5Hash(this.secretKey + timestamp.ToString());

            var postContent = new Dictionary<string, string>();
            foreach (var prop in jsonReq)
            {
                if (!string.IsNullOrWhiteSpace(prop.Value.ToString()))
                    postContent[prop.Key] = prop.Value.ToString();
            }

            var result = await httpClient.PostAsync(this.apiBase, new FormUrlEncodedContent(postContent));

            result.EnsureSuccessStatusCode();
            var responseAsString = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<WalletResponse<WalletInvoice>>(responseAsString);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                if (httpClient != null) httpClient.Dispose();
            }
            disposed = true;
        }

        private string CalculateMD5Hash(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException(nameof(input));
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);

            using (var md5 = MD5.Create())
            {
                byte[] hash = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }

        private bool TryParseUri(string uriString, out Uri uri)
        {
            if (!Uri.TryCreate(uriString, UriKind.Absolute, out uri))
            {
                return false;
            }
            return uri.Scheme == "http" || uri.Scheme == "https";
        }
    }
}
