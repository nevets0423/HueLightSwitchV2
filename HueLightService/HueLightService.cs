using PhilipsHueLightApis;
using PhilipsHueLightApis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Timers;

namespace HueLightService {
    public partial class HueLightService : ServiceBase {
        private const string HUEPROJECTKEY = "";
        public const int POWEROUTAGECODE = 174;
        public const int POWERRESTOREDCODE = 61455;
        private PhilipsHueLightManager _philipsHueLightManager;
        private EventReader _eventReader;
        private IEnumerable<BridgeInfo> _bridges;
        private int _lastAmountOfPowerOutNotifications = int.MaxValue;
        private bool _powerIsOut = false;
        private bool _powerWasOut = false;
        private Timer _timer;

        public HueLightService() {
            InitializeComponent();
            _timer = new Timer(20000);
            _timer.Elapsed += Timer_Tick;

            _philipsHueLightManager = new PhilipsHueLightManager(HUEPROJECTKEY);
            _eventReader = new EventReader();
            _bridges = new List<BridgeInfo>();
        }

        protected override void OnStart(string[] args) {
            _timer.Start();
        }

        protected override void OnStop() {
            _timer.Stop();
        }

        private void Timer_Tick(object sender, System.EventArgs e) {
            _powerIsOut = IsPowerOut();
            if (_powerIsOut) {
                if (!_powerWasOut) {
                    ErrorLogging.PowerHasBeenLost();
                }
                _powerWasOut = true;
                return;
            }

            if (_powerWasOut) {
                if (RestoreBridgeInfo()) {
                    _powerWasOut = false;
                }
                return;
            }

            UpdateBridgeInfo();
        }

        private bool IsPowerOut() {
            var events = _eventReader.GetReleventEvents();
            if (!events.Any()) {
                events = null;
                return false;
            }

            var reportedOutages = events.Count(e => e.InstanceId == POWEROUTAGECODE);
            var reportedRestores = events.Count(e => e.InstanceId == POWERRESTOREDCODE);

            var value = reportedOutages > reportedRestores || reportedOutages > _lastAmountOfPowerOutNotifications;
            _lastAmountOfPowerOutNotifications = reportedOutages;

            return value;
        }

        private void UpdateBridgeInfo() {
            if (_powerIsOut) {
                return;
            }
            try {
                _bridges = _philipsHueLightManager.GetBridgeDetails();
            }
            catch (Exception ex){
                ErrorLogging.ErrorUpdatingBridgeInfo(ex.Message);
            }
        }

        private bool RestoreBridgeInfo() {
            try {
                foreach (var bridge in _bridges) {
                    foreach (var light in bridge.Lights) {
                        var updatedSuccesful = _philipsHueLightManager.SetState(bridge, light as LightInfo);
                        if (!updatedSuccesful) {
                            throw new Exception($"Failed to update light {light.GetName()}.");
                        }
                    }
                }

                ErrorLogging.PowerHasBeenRestored();
                return true;
            }
            catch (Exception ex) {
                ErrorLogging.PowerRestoredNoConnection(ex.Message);
                return false;
            }
        }
    }
}
