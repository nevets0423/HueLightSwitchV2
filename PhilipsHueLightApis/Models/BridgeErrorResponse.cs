namespace PhilipsHueLightApis.Models {
    internal class BridgeErrorResponse {
        public Error Error { get; set; }
    }

    internal class Error {
        public int Type { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
    }
}
