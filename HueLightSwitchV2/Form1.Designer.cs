namespace HueLightSwitchV2 {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.LightRadioButton = new System.Windows.Forms.RadioButton();
            this.GroupRadioButton = new System.Windows.Forms.RadioButton();
            this._timer = new System.Windows.Forms.Timer(this.components);
            this.RadialButtonFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ButtonFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ErrorMessageLabel = new System.Windows.Forms.Label();
            this.RadialButtonFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LightRadioButton
            // 
            this.LightRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LightRadioButton.AutoCheck = false;
            this.LightRadioButton.AutoSize = true;
            this.LightRadioButton.Checked = true;
            this.LightRadioButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.LightRadioButton.Location = new System.Drawing.Point(3, 3);
            this.LightRadioButton.Name = "LightRadioButton";
            this.LightRadioButton.Size = new System.Drawing.Size(53, 17);
            this.LightRadioButton.TabIndex = 2;
            this.LightRadioButton.TabStop = true;
            this.LightRadioButton.Text = "Lights";
            this.LightRadioButton.UseVisualStyleBackColor = true;
            this.LightRadioButton.Click += new System.EventHandler(this.LightRadioButton_Click);
            // 
            // GroupRadioButton
            // 
            this.GroupRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.GroupRadioButton.AutoCheck = false;
            this.GroupRadioButton.AutoSize = true;
            this.GroupRadioButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.GroupRadioButton.Location = new System.Drawing.Point(62, 3);
            this.GroupRadioButton.Name = "GroupRadioButton";
            this.GroupRadioButton.Size = new System.Drawing.Size(59, 17);
            this.GroupRadioButton.TabIndex = 3;
            this.GroupRadioButton.TabStop = true;
            this.GroupRadioButton.Text = "Groups";
            this.GroupRadioButton.UseVisualStyleBackColor = true;
            this.GroupRadioButton.Click += new System.EventHandler(this.GroupRadioButton_Click);
            // 
            // _timer
            // 
            this._timer.Enabled = true;
            this._timer.Interval = 500;
            this._timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // RadialButtonFlowLayoutPanel
            // 
            this.RadialButtonFlowLayoutPanel.Controls.Add(this.LightRadioButton);
            this.RadialButtonFlowLayoutPanel.Controls.Add(this.GroupRadioButton);
            this.RadialButtonFlowLayoutPanel.Location = new System.Drawing.Point(0, 203);
            this.RadialButtonFlowLayoutPanel.Name = "RadialButtonFlowLayoutPanel";
            this.RadialButtonFlowLayoutPanel.Size = new System.Drawing.Size(131, 25);
            this.RadialButtonFlowLayoutPanel.TabIndex = 4;
            // 
            // ButtonFlowLayoutPanel
            // 
            this.ButtonFlowLayoutPanel.AutoScroll = true;
            this.ButtonFlowLayoutPanel.AutoSize = true;
            this.ButtonFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButtonFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.ButtonFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonFlowLayoutPanel.MaximumSize = new System.Drawing.Size(1000, 200);
            this.ButtonFlowLayoutPanel.MinimumSize = new System.Drawing.Size(300, 200);
            this.ButtonFlowLayoutPanel.Name = "ButtonFlowLayoutPanel";
            this.ButtonFlowLayoutPanel.Size = new System.Drawing.Size(300, 200);
            this.ButtonFlowLayoutPanel.TabIndex = 5;
            // 
            // ErrorMessageLabel
            // 
            this.ErrorMessageLabel.AutoSize = true;
            this.ErrorMessageLabel.Location = new System.Drawing.Point(137, 203);
            this.ErrorMessageLabel.Name = "ErrorMessageLabel";
            this.ErrorMessageLabel.Size = new System.Drawing.Size(43, 13);
            this.ErrorMessageLabel.TabIndex = 6;
            this.ErrorMessageLabel.Text = "NoError";
            this.ErrorMessageLabel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(305, 234);
            this.Controls.Add(this.ErrorMessageLabel);
            this.Controls.Add(this.ButtonFlowLayoutPanel);
            this.Controls.Add(this.RadialButtonFlowLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1010, 1000);
            this.MinimumSize = new System.Drawing.Size(300, 236);
            this.Name = "Form1";
            this.Text = "Philips Hue Light Switch";
            this.RadialButtonFlowLayoutPanel.ResumeLayout(false);
            this.RadialButtonFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton LightRadioButton;
        private System.Windows.Forms.RadioButton GroupRadioButton;
        private System.Windows.Forms.Timer _timer;
        private System.Windows.Forms.FlowLayoutPanel RadialButtonFlowLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel ButtonFlowLayoutPanel;
        private System.Windows.Forms.Label ErrorMessageLabel;
    }
}

