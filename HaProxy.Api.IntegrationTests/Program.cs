using Clint.Network.HaProxy.Api;
using Newtonsoft.Json;
using System;

namespace HaProxy.Api.IntegrationTests
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var haproxy = new HaProxyClient("167.71.74.160", 7777))
            using (var instance = haproxy.GetInstance())
            {
                /*instance.DisableFrontend("prox0");
                instance.EnableFrontend("prox0");*/
                Console.WriteLine(instance.Help());
                /*var backends = instance.ShowBackend();
                Console.WriteLine(JsonConvert.SerializeObject(backends, Formatting.Indented));*/
            }
        }
    }
}
