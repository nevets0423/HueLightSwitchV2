using PhilipsHueLightApis.Interfaces;
using PhilipsHueLightApis.Models;
using System.Collections.Generic;
using System.Linq;

namespace PhilipsHueLightApis {
    public class PhilipsHueLightManager {
        private IHueDataAccess _hueDataAccess;

        public PhilipsHueLightManager(string projectKey) : this(new HueDataAccess(projectKey)) { }

        internal PhilipsHueLightManager(IHueDataAccess hueDataAccess) {
            _hueDataAccess = hueDataAccess;
        }

        public IEnumerable<BridgeInfo> GetBridgeDetails() {
            var bridges = _hueDataAccess.DiscoverBridges();

            if (!bridges.Any()) {
                return bridges;
            }

            foreach(var bridge in bridges.Where(b => !b.IsEmpty())) {
                bridge.Groups = _hueDataAccess.GetGroups(bridge).ToList();
                bridge.Lights = _hueDataAccess.GetLights(bridge).ToList();
            }

            return bridges;
        }

        public bool SetState(BridgeInfo bridgeInfo, LightInfo lightinfo) {
            return _hueDataAccess.SetState(bridgeInfo, lightinfo);
        }

        public bool SetState(BridgeInfo bridgeInfo, GroupInfo groupInfo) {
            return _hueDataAccess.SetState(bridgeInfo, groupInfo);
        }

        public bool SetAlert(BridgeInfo bridgeInfo, LightInfo lightinfo) {
            return _hueDataAccess.BlinkLight(bridgeInfo, lightinfo);
        }

        public bool SetAlert(BridgeInfo bridgeInfo, GroupInfo groupInfo) {
            var currentState = true;

            foreach(var light in bridgeInfo.Lights.Where(l => groupInfo.Lights.Contains(l.GetId().ToString()))) {
                currentState &= SetAlert(bridgeInfo, light as LightInfo);
            }

            return currentState;
        }
    }
}
