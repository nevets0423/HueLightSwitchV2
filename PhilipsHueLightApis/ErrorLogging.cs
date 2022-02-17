using System;
using System.IO;

namespace PhilipsHueLightApis {
    public static class ErrorLogging {
        private const string FOLDERPATH = "PhilipsHueLightController\\Api";

        public static void UnableToConnectToBridge(string statusCode, string message) {
            Log($"Error connecting to Bridge. Status: {statusCode} Message: {message}");
        }

        public static void ErrorReturnedFromBridge(string type, string address, string description) {
            Log($"Error from Bridge - Type: {type} Address: {address} Description: {description}");
        }


        private static void Log(string message) {
            var dateCode = DateTime.Now.ToString("yyyyMMdd");
            var fileName = $"Log-{dateCode}.txt";
            var applicationFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var filePath = Path.Combine(applicationFolderPath, FOLDERPATH);

            var errorTag = $"{DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss")} Error: ";

            Directory.CreateDirectory(filePath);
            File.AppendAllText(Path.Combine(filePath, fileName), errorTag + message);
        }
    }
}
