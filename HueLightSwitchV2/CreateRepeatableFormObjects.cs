using System;
using System.Drawing;
using System.Windows.Forms;

namespace HueLightSwitchV2 {
    public static class CreateRepeatableFormObjects {
        public static Panel CreateButtonLabelPanel(Button button, Label label, Point location) {
            var panel = new Panel { 
                Location = location,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };

            panel.Controls.Add(button);
            panel.Controls.Add(label);

            return panel;
        }

        public static Button CreateButton(String name, EventHandler onButtonClick) {
            var defaultImage = Properties.Resources.powerSwitchgreen1;
            var size = new Size(defaultImage.Width, defaultImage.Height);
            var NewButton = new Button {
                BackgroundImageLayout = ImageLayout.Stretch,
                Location = new Point(0, 0),
                Name = name,
                Size = size,
                TabIndex = 0,
                UseVisualStyleBackColor = true,
                BackColor = SystemColors.WindowFrame,
                BackgroundImage = defaultImage
            };
            NewButton.Click += onButtonClick;

            return NewButton;
        }

        public static Label CreateLabel(String text, int buttonHeight) {
            return new Label {
                AutoSize = true,
                Location = new Point(0, buttonHeight + 5),
                Name = text,
                Size = new Size(35, 13),
                TabIndex = 4,
                Text = text,
                ForeColor = SystemColors.HighlightText
            };
        }
    }
}
