using Newtonsoft.Json;
using PhilipsHueLightApis.Interfaces;
using System.Collections.Generic;

namespace PhilipsHueLightApis.Models {
    public class GroupInfo : ILightInfo{
        public int GroupId { get; internal set; }

        [JsonProperty("name")]
        public string Name { get; internal set; }
        [JsonProperty("lights")]
        public List<string> Lights { get; internal set; }
        [JsonProperty("type")]
        public string Type { get; internal set; }
        [JsonProperty("state")]
        public GroupState State { get; internal set; }
        [JsonProperty("action")]
        public Action Action { get; set; }
        [JsonProperty("class")]
        public string Class { get; internal set; }

        public bool GetState() {
            return Action.On;
        }

        public string GetName() {
            return Name;
        }

        public int GetBri() {
            return Action.Brightness;
        }

        public string GetAlert() {
            return Action.Alert;
        }

        public int GetId() {
            return GroupId;
        }
    }

    public class Action {
        [JsonProperty("on")]
        public bool On { get; set; }
        [JsonProperty("bri")]
        public int Brightness { get; set; }
        [JsonProperty("hue")]
        public int Hue { get; set; }
        [JsonProperty("sat")]
        public int Saturation { get; set; }
        [JsonProperty("effect")]
        public string Effect { get; set; }
        [JsonProperty("xy")]
        public List<double> Xy { get; set; }
        [JsonProperty("ct")]
        public int Ct { get; set; }
        [JsonProperty("alert")]
        public string Alert { get; set; }
        [JsonProperty("colormode")]
        public string Colormode { get; set; }
    }

    public class GroupState {
        [JsonProperty("all_on")]
        public bool AllOn { get; internal set; }
        [JsonProperty("any_on")]
        public bool AnyOn { get; internal set; }
    }
}
