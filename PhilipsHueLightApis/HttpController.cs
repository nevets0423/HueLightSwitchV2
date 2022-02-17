using PhilipsHueLightApis.Interfaces;
using PhilipsHueLightApis.Models;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace PhilipsHueLightApis {
    internal class HttpController : IHttpController {
        public HttpController() {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        public HttpResponse SendGetRequest(Uri uri) {
            var request = WebRequest.Create(uri);
            request.Credentials = CredentialCache.DefaultCredentials;

            return MakeRequest(request);
        }

        public HttpResponse SendPutRequest(Uri url, string body) {
            var request = WebRequest.Create(url);
            request.Method = "PUT";
            var byteArray = Encoding.UTF8.GetBytes(body);

            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;

            using (var dataStream = request.GetRequestStream()) {
                dataStream.Write(byteArray, 0, byteArray.Length);
                return MakeRequest(request);
            }
        }

        private HttpResponse MakeRequest(WebRequest request) {
            using (var response = (HttpWebResponse)request.GetResponse()) {
                return new HttpResponse {
                    StatusCode = response.StatusCode,
                    ResponseBody = ReadResponseBody(response)
                };
            }
        }

        private string ReadResponseBody(HttpWebResponse httpWebResponse) {
            using (var dataStream = httpWebResponse.GetResponseStream()) {
                using (var reader = new StreamReader(dataStream)) {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
