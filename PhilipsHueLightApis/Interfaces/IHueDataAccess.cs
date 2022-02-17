using PhilipsHueLightApis.Models;
using System.Collections.Generic;

namespace PhilipsHueLightApis.Interfaces {
    internal interface IHueDataAccess {
        bool BlinkLight(BridgeInfo bridgeInfo, LightInfo lightInfo);
        IEnumerable<BridgeInfo> DiscoverBridges();
        IEnumerable<GroupInfo> GetGroups(BridgeInfo bridgeInfo);
        IEnumerable<LightInfo> GetLights(BridgeInfo bridgeInfo);
        bool SetState(BridgeInfo bridgeInfo, GroupInfo groupInfo);
        bool SetState(BridgeInfo bridgeInfo, LightInfo lightInfo);
    }
}