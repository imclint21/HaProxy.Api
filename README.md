# HaProxy.Api

Provides a C # library for easily manage an HAProxy server through his Socket API.

```csharp
using (var haproxy = new HaProxyClient("127.0.0.1", 8080))
using (var instance = haproxy.GetInstance())
{
    // Get the help message
    Console.WriteLine(instance.Help());

    string errors = instance.ShowErrors();
    Console.WriteLine(errors);

    // Disable the "http-in" frontend
    instance.DisableFrontend("http-in");

    // Re-enable it
    instance.EnableFrontend("http-in");

    // Get all the backends
    var backends = instance.ShowBackend();	
    foreach(var backend in backends)
    {
        Console.WriteLine(backend);
    }
}
```

## About the Author

HaProxy.Api is powered by [Clint.Network](https://twitter.com/clint_network) and published under the [MIT License](LICENSE.md).

If you want to make a little donation (or bigger), use this Bitcoin address: 3NhdjiGrpzH5geVrDHa173EuXxnAVhghtZ
