namespace PhilipsHueLightApis.Interfaces {
    public interface ILightInfo {
        bool GetState();
        string GetName();
        int GetBri();
        string GetAlert();
        int GetId();
    }
}
