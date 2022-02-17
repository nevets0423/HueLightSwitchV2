using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HueLightSwitch{
    public static class CreateFormObjects{
        public static Button CreateButton(String name, Point location, int[] size, EventHandler onButtonClick){
            Button NewButton = new Button();

            NewButton.BackgroundImageLayout = ImageLayout.Stretch;
            NewButton.Location = location;
            NewButton.Name = name;
            NewButton.Size = new Size(size[0], size[1]);
            NewButton.TabIndex = 0;
            NewButton.UseVisualStyleBackColor = true;
            NewButton.Click += onButtonClick;
            NewButton.BackColor = SystemColors.WindowFrame;

            return NewButton;
        }

        public static Label CreateLabel(String text, Point point){
            Label label = new Label();
            label.AutoSize = true;
            label.Location = point;
            label.Name = text;
            label.Size = new Size(35, 13);
            label.TabIndex = 4;
            label.Text = text;
            label.ForeColor = SystemColors.HighlightText;

            return label;
        }

        public static VScrollBar CreateScrollBar(String name, Point point){
            VScrollBar scrollBar = new VScrollBar();
            scrollBar.Location = point;
            scrollBar.Maximum = 255;
            scrollBar.Minimum = 0;
            scrollBar.Name = name;
            scrollBar.Size = new System.Drawing.Size(17, 80);
            scrollBar.TabIndex = 4;

            return scrollBar;
        }
    }
}
