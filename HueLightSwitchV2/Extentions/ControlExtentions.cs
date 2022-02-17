using System;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace HueLightSwitchV2.Extentions {
    public static class ControlExtentions {
        public static Control Last(this ControlCollection controlCollection) {
            if(controlCollection.Count == 0) {
                return default;
            }
            return controlCollection[controlCollection.Count - 1];
        }

        public static void RemoveLast(this ControlCollection controlCollection) {
            controlCollection.RemoveAt(controlCollection.Count - 1);
        }

        public static T Find<T>(this ControlCollection controlCollection) {
            foreach(var control in controlCollection) {
                if(control is T) {
                    return (T)control;
                }
            }

            return default;
        }
    }
}
