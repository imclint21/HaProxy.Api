using Xunit;
using Xunit.Abstractions;
using Clint.Network.HaProxy.Api;

namespace HaProxy.Api.Tests
{
    public class MainTests
    {
        private readonly ITestOutputHelper output;

        [Fact]
        public void Connecting()
        {
            using (var haproxy = new HaProxyClient("127.0.0.1", 8080))
            using (var instance = haproxy.GetInstance())
            {
                Assert.NotNull(instance);
            }
        }

        [Fact]
        public void ShowErrors()
        {
            using (var haproxy = new HaProxyClient("127.0.0.1", 8080))
            using (var instance = haproxy.GetInstance())
            {
                var errors = instance.ShowErrors();
                Assert.NotEmpty(errors);
            }
        }

        [Fact]
        public void ShowBackend()
        {
            using (var haproxy = new HaProxyClient("127.0.0.1", 8080))
            using (var instance = haproxy.GetInstance())
            {
                var backends = instance.ShowBackend();
                Assert.NotEmpty(backends);
            }
        }

        [Fact]
        public void SendRaw()
        {
            using (var haproxy = new HaProxyClient("127.0.0.1", 8080))
            using (var instance = haproxy.GetInstance())
            {
                var response = instance.SendRaw("show errors");
                Assert.NotEmpty(response);
            }
        }
    }
}
