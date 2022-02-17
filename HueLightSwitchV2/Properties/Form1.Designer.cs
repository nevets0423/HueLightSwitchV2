namespace HueLightSwitch
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ButtonPanel1 = new System.Windows.Forms.Panel();
            this.radioButtonLight = new System.Windows.Forms.RadioButton();
            this.radioButtonGroups = new System.Windows.Forms.RadioButton();
            this.LabelPanelForButtonPanel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // ButtonPanel1
            // 
            this.ButtonPanel1.AutoSize = true;
            this.ButtonPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButtonPanel1.Location = new System.Drawing.Point(12, 12);
            this.ButtonPanel1.Name = "ButtonPanel1";
            this.ButtonPanel1.Size = new System.Drawing.Size(0, 0);
            this.ButtonPanel1.TabIndex = 0;
            // 
            // radioButtonLight
            // 
            this.radioButtonLight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonLight.AutoCheck = false;
            this.radioButtonLight.AutoSize = true;
            this.radioButtonLight.Checked = true;
            this.radioButtonLight.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.radioButtonLight.Location = new System.Drawing.Point(9, 168);
            this.radioButtonLight.Name = "radioButtonLight";
            this.radioButtonLight.Size = new System.Drawing.Size(53, 17);
            this.radioButtonLight.TabIndex = 1;
            this.radioButtonLight.TabStop = true;
            this.radioButtonLight.Text = "Lights";
            this.radioButtonLight.UseVisualStyleBackColor = true;
            this.radioButtonLight.Click += new System.EventHandler(this.radioButtonLight_Click);
            // 
            // radioButtonGroups
            // 
            this.radioButtonGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonGroups.AutoCheck = false;
            this.radioButtonGroups.AutoSize = true;
            this.radioButtonGroups.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.radioButtonGroups.Location = new System.Drawing.Point(86, 168);
            this.radioButtonGroups.Name = "radioButtonGroups";
            this.radioButtonGroups.Size = new System.Drawing.Size(59, 17);
            this.radioButtonGroups.TabIndex = 2;
            this.radioButtonGroups.TabStop = true;
            this.radioButtonGroups.Text = "Groups";
            this.radioButtonGroups.UseVisualStyleBackColor = true;
            this.radioButtonGroups.Click += new System.EventHandler(this.radioButtonLight_Click);
            // 
            // LabelPanelForButtonPanel1
            // 
            this.LabelPanelForButtonPanel1.AutoSize = true;
            this.LabelPanelForButtonPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.LabelPanelForButtonPanel1.Location = new System.Drawing.Point(13, 66);
            this.LabelPanelForButtonPanel1.Name = "LabelPanelForButtonPanel1";
            this.LabelPanelForButtonPanel1.Size = new System.Drawing.Size(0, 0);
            this.LabelPanelForButtonPanel1.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.Location = new System.Drawing.Point(9, 73);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(0, 0);
            this.panel3.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel4.Location = new System.Drawing.Point(13, 124);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(0, 0);
            this.panel4.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(284, 197);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.LabelPanelForButtonPanel1);
            this.Controls.Add(this.radioButtonLight);
            this.Controls.Add(this.radioButtonGroups);
            this.Controls.Add(this.ButtonPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.MinimumSize = new System.Drawing.Size(300, 236);
            this.Name = "Form1";
            this.Text = "Philips Hue Light Switch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel ButtonPanel1;
        private System.Windows.Forms.RadioButton radioButtonLight;
        private System.Windows.Forms.RadioButton radioButtonGroups;
        private System.Windows.Forms.Panel LabelPanelForButtonPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
    }
}

