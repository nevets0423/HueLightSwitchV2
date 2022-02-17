using Newtonsoft.Json;
using PhilipsHueLightApis.Interfaces;
using System;

namespace PhilipsHueLightApis.Models {
    public class LightInfo : ILightInfo{
        public int LightId { get; internal set; }
        [JsonProperty("state")]
        public State State { get; set; }
        [JsonProperty("swupdate")]
        public Swupdate Swupdate { get; internal set; }
        [JsonProperty("type")]
        public string Type { get; internal set; }
        [JsonProperty("name")]
        public string Name { get; internal set; }
        [JsonProperty("modelid")]
        public string ModelID { get; internal set; }
        [JsonProperty("manufacturername")]
        public string ManufacturerName { get; internal set; }
        [JsonProperty("productname")]
        public string ProductName { get; internal set; }
        [JsonProperty("capabilities")]
        public Capabilities Capabilities { get; internal set; }
        [JsonProperty("config")]
        public Config Config { get; internal set; }
        [JsonProperty("uniqueid")]
        public string UniqueID { get; internal set; }
        [JsonProperty("swversion")]
        public string SwVersion { get; internal set; }
        [JsonProperty("swconfigid")]
        public string SwConfigID { get; internal set; }
        [JsonProperty("productid")]
        public string ProductID { get; internal set; }

        public bool GetState() {
            return State.On;
        }

        public string GetName() {
            return Name;
        }

        public int GetBri() {
            return State.Brightness;
        }

        public string GetAlert() {
            return State.Alert;
        }

        public int GetId() {
            return LightId;
        }
    }

    public class State {
        [JsonProperty("on")]
        public bool On { get; set; }
        [JsonProperty("bri")]
        public int Brightness { get; set; }
        [JsonProperty("alert")]
        public string Alert { get; set; }
        [JsonProperty("mode")]
        public string Mode { get; set; }
        [JsonProperty("reachable")]
        public bool Reachable { get; internal set; }
    }

    public class Swupdate {
        [JsonProperty("state")]
        public string State { get; internal set; }
        [JsonProperty("lastinstall")]
        public DateTime Lastinstall { get; internal set; }
    }

    public class Control {
        [JsonProperty("mindimlevel")]
        public int Mindimlevel { get; internal set; }
        [JsonProperty("maxlumen")]
        public int Maxlumen { get; internal set; }
    }

    public class Streaming {
        [JsonProperty("renderer")]
        public bool Renderer { get; internal set; }
        [JsonProperty("proxy")]
        public bool Proxy { get; internal set; }
    }

    public class Capabilities {
        [JsonProperty("certified")]
        public bool Certified { get; internal set; }
        [JsonProperty("control")]
        public Control Control { get; internal set; }
        [JsonProperty("streaming")]
        public Streaming Streaming { get; set; }
    }

    public class Config {
        [JsonProperty("archetype")]
        public string Archetype { get; internal set; }
        [JsonProperty("function")]
        public string Function { get; internal set; }
        [JsonProperty("direction")]
        public string Direction { get; internal set; }
    }
}
