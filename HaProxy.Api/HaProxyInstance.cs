using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Clint.Network.HaProxy.Api
{
    public class HaProxyInstance : IDisposable
    {
        private StreamHelper _streamHelper;

        public HaProxyInstanceOptions Options { get; set; }
        public IPEndPoint EndPoint { get; set; }

        public HaProxyInstance()
        {
        }

        internal HaProxyInstance Setup()
        {
            _streamHelper = new StreamHelper(EndPoint);
            return this;
        }

        public string SendRaw(string rawData)
        {
            return SendCommands(rawData);
        }

        /// <summary>
        /// Report last request and response errors for each proxy
        /// </summary>
        /// <returns></returns>
        public string ShowErrors()
        {
            return SendCommands($"show errors");
        }

        /// <summary>
        /// Report counters for each proxy and server
        /// </summary>
        public string ShowStat()
        {
            return SendCommands($"show stat");
        }

        /// <summary>
        /// Temporarily disable specific frontend
        /// </summary>
        public string DisableFrontend(string frontend)
        {
            return SendCommands($"disable frontend {frontend}");
        }

        /// <summary>
        /// Re-enable specific frontend
        /// </summary>
        public string EnableFrontend(string frontend)
        {
            return SendCommands($"enable frontend {frontend}");
        }

        /// <summary>
        /// Get help
        /// </summary>
        public string Help()
        {
            return SendCommands($"help");
        }

        /// <summary>
        /// List backends in the current running config
        /// </summary>
        public IEnumerable<string> ShowBackend()
        {
            return SendCommands($"show backend").Replace("\u0000", "").Replace("\r", "").Split('\n').ToList().Where(x => !string.IsNullOrWhiteSpace(x) && !x.StartsWith("#"));
        }

        /// <summary>
        /// stop a specific frontend
        /// </summary>
        public string ShutdownFrontend()
        {
            return SendCommands($"shutdown frontend");
        }

        /// <summary>
        /// Disconnect
        /// </summary>
        /// <returns></returns>
        public string Quit()
        {
            return SendCommands($"quit");
        }

        private string SendCommands(string commands)
        {
            _streamHelper.Connect();
            _streamHelper.Send(commands);
            return _streamHelper.Receive();
        }

        public void Dispose()
        {
            _streamHelper?.Dispose();
        }
    }
}