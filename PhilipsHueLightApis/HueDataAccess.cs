using Newtonsoft.Json;
using PhilipsHueLightApis.Interfaces;
using PhilipsHueLightApis.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhilipsHueLightApis {
    internal class HueDataAccess : IHueDataAccess {
        private const string _discoverHueUrl = "https://discovery.meethue.com";
        private readonly string _projectkey;
        private IHttpController _httpController;

        public HueDataAccess(string projectKey) : this(projectKey, new HttpController()) { }

        internal HueDataAccess(string projectKey, IHttpController httpController) {
            _projectkey = projectKey;
            _httpController = httpController;
        }

        public IEnumerable<BridgeInfo> DiscoverBridges() {
            var httpResponse = _httpController.SendGetRequest(new Uri(_discoverHueUrl));
            VerifyResponse(httpResponse);

            return JsonConvert.DeserializeObject<BridgeInfo[]>(httpResponse.ResponseBody);
        }

        public IEnumerable<GroupInfo> GetGroups(BridgeInfo bridgeInfo) {
            var httpResponse = _httpController.SendGetRequest(CreateUri(bridgeInfo, _projectkey, "groups"));
            VerifyResponse(httpResponse);

            var groups = JsonConvert.DeserializeObject<Dictionary<int, GroupInfo>>(httpResponse.ResponseBody);

            foreach (var key in groups.Keys) {
                groups[key].GroupId = key;
            }

            return groups.Values.ToArray();
        }

        public IEnumerable<LightInfo> GetLights(BridgeInfo bridgeInfo) {
            var httpResponse = _httpController.SendGetRequest(CreateUri(bridgeInfo, _projectkey, "lights"));
            VerifyResponse(httpResponse);

            var lights = JsonConvert.DeserializeObject<Dictionary<int, LightInfo>>(httpResponse.ResponseBody);

            foreach (var key in lights.Keys) {
                lights[key].LightId = key;
            }

            return lights.Values.ToArray();
        }

        public bool SetState(BridgeInfo bridgeInfo, GroupInfo groupInfo) {
            return SetState(CreateUri(bridgeInfo, _projectkey, $"groups/{groupInfo.GroupId}/action"), groupInfo.GetState(), groupInfo.GetBri());
        }

        public bool SetState(BridgeInfo bridgeInfo, LightInfo lightInfo) {
            return SetState(CreateUri(bridgeInfo, _projectkey, $"lights/{lightInfo.LightId}/state"), lightInfo.GetState(), lightInfo.GetBri());
        }

        private bool SetState(Uri uri, bool state, int brightness) {
            var results = _httpController.SendPutRequest(uri, "{\"on\":" + state.ToString().ToLower() + " , \"bri\":" + brightness + "}");
            VerifyResponse(results);

            return results.ResponseBody.Contains("success");
        }

        public bool BlinkLight(BridgeInfo bridgeInfo, LightInfo lightInfo) {
            var uri = CreateUri(bridgeInfo, _projectkey, $"lights/{lightInfo.LightId}/state");
            var results = _httpController.SendPutRequest(uri, "{\"alert\":\"lselect\"}");
            VerifyResponse(results);

            return results.ResponseBody.Contains("success");
        }

        private Uri CreateUri(BridgeInfo bridgeInfo, string key, string command) {
            return new Uri($"http://{bridgeInfo.InternalIpAddress}/api/{key}/{command}");
        }

        private void VerifyResponse(HttpResponse httpResponse) {
            if (httpResponse.StatusCode != System.Net.HttpStatusCode.OK) {
                ErrorLogging.UnableToConnectToBridge(httpResponse.StatusCode.ToString(), httpResponse.ResponseBody);
                throw new Exception($"Error connecting to Bridge. Status: {httpResponse.StatusCode} Message: {httpResponse.ResponseBody}");
            }

            try {
                var errorMessage = JsonConvert.DeserializeObject<BridgeErrorResponse>(httpResponse.ResponseBody)?.Error;
                if (errorMessage != null) {
                    ErrorLogging.ErrorReturnedFromBridge(errorMessage.Type.ToString(), errorMessage.Address, errorMessage.Description);
                    throw new Exception($"Error from Bridge - Type: {errorMessage.Type} Address: {errorMessage.Address} Description: {errorMessage.Description}");
                }
            }
            catch { }
        }
    }
}
