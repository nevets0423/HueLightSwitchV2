using System;
using System.IO;

namespace HueLightSwitchV2 {
    public static class ErrorLogging {
        private const string FOLDERPATH = "PhilipsHueLightController\\LightSwitch";

        public static void UnableToConnectToBridge() {
            Log("Unable To connect to Bridge.");
        }


        private static void Log(string message) {
            var dateCode = DateTime.Now.ToString("yyyyMMdd");
            var fileName = $"Log-{dateCode}.txt";
            var applicationFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var filePath = Path.Combine(applicationFolderPath, FOLDERPATH);

            var errorTag = $"{DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss")} Error: ";

            Directory.CreateDirectory(filePath);
            File.AppendAllText(Path.Combine(filePath,fileName), errorTag + message);
        }
    }
}
