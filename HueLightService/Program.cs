using System.ServiceProcess;

namespace HueLightService {
    static class Program {
        static void Main() {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] {
                new HueLightService()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
