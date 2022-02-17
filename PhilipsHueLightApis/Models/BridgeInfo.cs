using Newtonsoft.Json;
using PhilipsHueLightApis.Interfaces;
using System.Collections.Generic;

namespace PhilipsHueLightApis.Models {
    public class BridgeInfo {
        [JsonProperty("id")]
        public string Id { get; internal set; }

        [JsonProperty("internalipaddress")]
        public string InternalIpAddress { get; internal set; }
        public IEnumerable<ILightInfo> Groups { get; internal set; }
        public IEnumerable<ILightInfo> Lights { get; internal set; }

        internal bool IsEmpty() {
            return string.IsNullOrEmpty(Id) || string.IsNullOrEmpty(InternalIpAddress);
        }
    }
}
