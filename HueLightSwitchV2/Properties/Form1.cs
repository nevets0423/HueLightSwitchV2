using System;
using System.Timers;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PhilipsHueLights;

namespace HueLightSwitch {
    public partial class Form1 : Form {
        private delegate void panelReturnDelegate();
        private List<bool> _OnOffButtonState = new List<bool>();
        private int[] _OnOffButtonSize = new int[] { 130, 60 };
        private bool _ShowGroupButtons = true;
        private string _HueProjectKey = "VM2f1BqFyBLS0FKNHVNgP5nkjFMqp7bPVhquiUtS";
        private HueApi _Hue;
        private System.Timers.Timer _Timer;

        public Form1() {
            try {
                InitializeComponent();
                ConnectToBridge();
                SetTimer();
            }
            catch (Exception ex) {
                DisplayError($"Unable to start error: {ex.Message}");
                Close();
            }
        }

        private void ConnectToBridge() {
            _Hue = new HueApi();
            _Hue.LocateBridgeIP();
            _Hue.SetIpAddress(_Hue.LocateBridgeIP());
            _Hue.SetProjectKey(_HueProjectKey);
        }

        private void UpdateButtons() {
            try {
                _Hue.Update();
                if (_ShowGroupButtons != _Hue.UseGroup) {
                    _Hue.UseGroup = _ShowGroupButtons;
                }

                UpdateLightButtons();
            }
            catch (Exception ex) {
                DisplayError($"An error occured updating the buttons: {ex.Message}");
            }
        }

        private void UpdateLightButtons() {
            try {
                if (this.ButtonPanel1.InvokeRequired) {
                    panelReturnDelegate d = new panelReturnDelegate(UpdateLightButtons);
                    this.Invoke(d);
                }
                else {
                    this.ButtonPanel1.SuspendLayout();
                    this.SuspendLayout();
                    _OnOffButtonState.Clear();
                    bool labelsNeedUpdate = false;
                    for (int i = 0; i < _Hue.Count; i++) {
                        _OnOffButtonState.Add(true);
                        if (i >= this.ButtonPanel1.Controls.Count) {
                            Point buttonLocation = new Point(3 + ((_OnOffButtonState.Count - 1) * _OnOffButtonSize[0]), 3);
                            Button button = CreateFormObjects.CreateButton(i + "Button", buttonLocation, _OnOffButtonSize, new EventHandler(button_Click));
                            button.BackgroundImage = MatchButtonState(button);
                            this.ButtonPanel1.Controls.Add(button);
                            this.LabelPanelForButtonPanel1.Controls.Add(CreateFormObjects.CreateLabel(_Hue.GetName((i + 1)), GetLabelLocation(button)));
                        }
                        else {
                            var button = this.ButtonPanel1.Controls[i];
                            button.BackgroundImage = MatchButtonState(button as Button);
                            this.LabelPanelForButtonPanel1.Controls[i].Location = GetLabelLocation(button as Button);
                            this.LabelPanelForButtonPanel1.Controls[i].Text = _Hue.GetName(i + 1);
                        }
                    }

                    for (int i = _Hue.Count; i < this.ButtonPanel1.Controls.Count; i++) {
                        this.ButtonPanel1.Controls.RemoveAt(i);
                        this.LabelPanelForButtonPanel1.Controls.RemoveAt(i);
                    }
                    SetpanelLocations();

                    this.ButtonPanel1.ResumeLayout(false);
                    this.ResumeLayout(false);
                    this.PerformLayout();
                }
            }
            catch (Exception ex) {
                DisplayError($"An error occured updating the buttons: {ex.Message}");
            }
        }

        private Point GetLabelLocation(Button button) {
            Point point = button.Location;
            point.X += button.Size.Width / 4;

            return point;
        }

        private void SetpanelLocations() {
            this.LabelPanelForButtonPanel1.Location = new Point(this.ButtonPanel1.Location.X, this.ButtonPanel1.Size.Height + 10);
            this.panel3.Location = new Point(this.LabelPanelForButtonPanel1.Location.X, this.LabelPanelForButtonPanel1.Location.Y + 20);
            this.panel4.Location = new Point(this.panel3.Location.X, this.panel3.Location.Y + 20);
        }

        private void SetTimer() {
            _Timer = new System.Timers.Timer(500);
            _Timer.Elapsed += Timer_Elapsed;
            _Timer.AutoReset = true;
            _Timer.Enabled = true;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e) {
            UpdateButtons();
        }

        private Bitmap MatchButtonState(Button button) {
            int ID = ButtonID(button);
            if (_Hue.GetOn(ID + 1)) {
                _OnOffButtonState[ID] = true;
                return global::HueLightSwitch.Properties.Resources.powerSwitchgreen;
            }
            else {
                _OnOffButtonState[ID] = false;
                return global::HueLightSwitch.Properties.Resources.powerSwitchred;
            }
        }

        private void SetLightState(Button button, bool state) {
            try {
                Console.WriteLine(_Hue.SetState(ButtonID(button) + 1, state));
            }
            catch (Exception ex) {
                DisplayError($"An error occured setting light states: {ex.Message}");
            }
        }

        private int ButtonID(Button button) {
            int loc = button.Name.IndexOf("Button");
            return Int32.Parse(button.Name.Substring(0, loc));
        }

        private void button_Click(object sender, EventArgs e) {
            Button button = sender as Button;

            ActivateButton(button);
        }

        private void ActivateButton(Button button) {
            if (_OnOffButtonState[ButtonID(button)]) {
                button.BackgroundImage = global::HueLightSwitch.Properties.Resources.powerSwitchred;
                SetLightState(button, false);

            }
            else {
                button.BackgroundImage = global::HueLightSwitch.Properties.Resources.powerSwitchgreen;
                SetLightState(button, true);
            }

            _OnOffButtonState[ButtonID(button)] = !_OnOffButtonState[ButtonID(button)];
        }

        private void radioButtonLight_Click(object sender, EventArgs e) {
            this.radioButtonLight.Checked = !this.radioButtonLight.Checked;
            this.radioButtonGroups.Checked = !this.radioButtonGroups.Checked;
            _ShowGroupButtons = this.radioButtonGroups.Checked;
        }

        private void DisplayError(string errorMessage) {
            MessageBox.Show(errorMessage);
        }
    }
}
