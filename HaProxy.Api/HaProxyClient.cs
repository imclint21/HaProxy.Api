using System;
using System.Net;

namespace Clint.Network.HaProxy.Api
{
    public class HaProxyClient : IDisposable
    {
        private readonly IPEndPoint _endpoint;
        private HaProxyInstance _instance;

        /// <summary>
        /// Setup a Connection Endpoint to HAProxy
        /// </summary>
        public HaProxyClient(string hostname, int port)
        {
            var addresses = Dns.GetHostAddresses(hostname);
            if(addresses.Length == 0)
            {
                throw new Exception("Unable to get the associated IP address.");
            }
            _endpoint = new IPEndPoint(addresses[0], port);
        }

        /// <summary>
        /// Return an handle of the Current HaProxyInstance
        /// </summary>
        public HaProxyInstance GetInstance(HaProxyInstanceOptions instanceOptions = null)
        {
            return _instance = new HaProxyInstance()
            {
                EndPoint = _endpoint,
                Options = instanceOptions
            }.Setup();
        }

        public void Dispose()
        {
            _instance?.Dispose();
        }
    }
}
