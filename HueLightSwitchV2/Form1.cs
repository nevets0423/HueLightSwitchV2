using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HueLightSwitchV2.Extentions;
using PhilipsHueLightApis;
using PhilipsHueLightApis.Interfaces;
using PhilipsHueLightApis.Models;

namespace HueLightSwitchV2 {
    public partial class Form1 : Form {
        private const string HUEPROJECTKEY = "";
        private delegate void panelReturnDelegate();
        private PhilipsHueLightManager _philipsHueLightManager;
        private IEnumerable<BridgeInfo> _bridges;

        public Form1() {
            InitializeComponent();
            _philipsHueLightManager = new PhilipsHueLightManager(HUEPROJECTKEY);

            UpdateButtons();
        }

        private void UpdateButtons() {
            if (ButtonFlowLayoutPanel.InvokeRequired) {
                var panelReturnDelegate = new panelReturnDelegate(UpdateButtons);
                Invoke(panelReturnDelegate);
                return;
            }

            try {
                _bridges = _philipsHueLightManager.GetBridgeDetails();
                ErrorMessageLabel.Visible = false;
            }
            catch(Exception ex) {
                ErrorConnectingToBridge(ex);
                return;
            }

            var startingIndex = 0;
            foreach(var bridge in _bridges) {
                var numberOfButtons = (GroupRadioButton.Checked) ? bridge.Groups.Count() : bridge.Lights.Count();
                AdjustOnScreenButtonCount(numberOfButtons);
                AddBridgeToScreen(bridge, startingIndex);
                startingIndex += numberOfButtons;
            }
        }

        private void AddBridgeToScreen(BridgeInfo bridgeInfo, int startingIndex) {
            if (GroupRadioButton.Checked) {
                AddLightsToScreen(bridgeInfo.Groups.ToList(), bridgeInfo.Id, startingIndex);
                return;
            }

            AddLightsToScreen(bridgeInfo.Lights.ToList(), bridgeInfo.Id, startingIndex);
        }

        private void AddLightsToScreen(List<ILightInfo> lights, string bridgeId, int index) {
            foreach(var light in lights) {
                var buttonPanel = ButtonFlowLayoutPanel.Controls[index++];
                var button = buttonPanel.Controls.Find<Button>();
                var label = buttonPanel.Controls.Find<Label>();

                button.BackgroundImage = GetButtonImage(light.GetState());
                button.Name = $"{light.GetId()},{bridgeId}";
                label.Text = light.GetName();
            }
        }

        private void AdjustOnScreenButtonCount(int desiredNumberOfButtons) {
            while(ButtonFlowLayoutPanel.Controls.Count > desiredNumberOfButtons) {
                ButtonFlowLayoutPanel.Controls.RemoveLast();
            }

            while(ButtonFlowLayoutPanel.Controls.Count < desiredNumberOfButtons) {
                var lastButtonPanel = ButtonFlowLayoutPanel.Controls.Last();
                var newButton = CreateRepeatableFormObjects.CreateButton((ButtonFlowLayoutPanel.Controls.Count + 1).ToString(), new EventHandler(ButtonClick));
                var newLabel = CreateRepeatableFormObjects.CreateLabel("default", newButton.Height);

                var newPanelLocation = new Point((lastButtonPanel?.Width) ?? 0 + 5, 0);
                newPanelLocation.X += (lastButtonPanel?.Location.X) ?? 0;
                var newPanel = CreateRepeatableFormObjects.CreateButtonLabelPanel(newButton, newLabel, newPanelLocation);

                ButtonFlowLayoutPanel.Controls.Add(newPanel);
            }
        }

        private Bitmap GetButtonImage(bool state) {
            if (state) {
                return Properties.Resources.powerSwitchgreen1;
            }

            return Properties.Resources.powerSwitchred;
        }

        private void AdjustRadioButtonStates() {
            LightRadioButton.Checked = !LightRadioButton.Checked;
            GroupRadioButton.Checked = !GroupRadioButton.Checked;
        }

        private void LightRadioButton_Click(object sender, EventArgs e) {
            AdjustRadioButtonStates();
            UpdateButtons();
        }

        private void GroupRadioButton_Click(object sender, EventArgs e) {
            AdjustRadioButtonStates();
            UpdateButtons();
        }

        private void Timer_Tick(object sender, EventArgs e) {
            UpdateButtons();
        }

        private void ButtonClick(object sender, EventArgs e) {
            var button = sender as Button;
            var buttonInfo = button.Name.Split(',');

            if (GroupRadioButton.Checked) {
                ChangeGroupState(int.Parse(buttonInfo[0]), buttonInfo[1]);
                return;
            }

            ChangeLightState(int.Parse(buttonInfo[0]), buttonInfo[1]);
        }

        private void ChangeLightState(int lightId, string bridgeId) {
            var bridge = _bridges.First(b => b.Id == bridgeId);
            var light = (LightInfo)bridge.Lights.First(l => l.GetId() == lightId);
            light.State.On = !light.State.On;

            try {
                _philipsHueLightManager.SetState(bridge, light);
            }
            catch (Exception ex) {
                ErrorConnectingToBridge(ex);
                return;
            }
        }

        private void ChangeGroupState(int groupId, string bridgeId) {
            var bridge = _bridges.First(b => b.Id == bridgeId);
            var group = (GroupInfo)bridge.Groups.First(g => g.GetId() == groupId);
            group.Action.On = !group.Action.On;

            try {
                _philipsHueLightManager.SetState(bridge, group);
            }
            catch (Exception ex) {
                ErrorConnectingToBridge(ex);
                return;
            }
        }

        private void ErrorConnectingToBridge(Exception ex) {
            ErrorMessageLabel.Text = "Unable to Connect to Bridge.";
            ErrorMessageLabel.Visible = true;
            if (ButtonFlowLayoutPanel.Controls.Count > 0) {
                ButtonFlowLayoutPanel.Controls.Clear();
            }
            ErrorLogging.UnableToConnectToBridge();
        }
    }
}
