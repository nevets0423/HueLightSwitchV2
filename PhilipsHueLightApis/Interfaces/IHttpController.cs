using PhilipsHueLightApis.Models;
using System;

namespace PhilipsHueLightApis.Interfaces{
    internal interface IHttpController {
        HttpResponse SendGetRequest(Uri uri);
        HttpResponse SendPutRequest(Uri url, string body);
    }
}