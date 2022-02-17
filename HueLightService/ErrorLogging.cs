using System.Diagnostics;

namespace HueLightService {
    public static class ErrorLogging {
        public static void PowerHasBeenRestored() {
            LogInformation("Power Has Been Restored and lights updated.");
        }

        public static void PowerRestoredNoConnection(string error) {
            LogInformation($"Power Has Been Restored but there is no available connection to bridge. Message:{error}");
        }

        public static void PowerHasBeenLost() {
            LogInformation("Power Has Been Lost.");
        }

        public static void ErrorUpdatingBridgeInfo(string error) {
            LogError($"Error Updating Bridge Info. Error:{error}");
        }

        private static void LogInformation(string message) {
            EventLog.WriteEntry("HueLight", message, EventLogEntryType.Information);
        }

        private static void LogError(string message) {
            EventLog.WriteEntry("HueLight", message, EventLogEntryType.Error);
        }
    }
}
