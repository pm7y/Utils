using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace Utils.Test;

public class WebTest
{
    [Fact]
    public async Task TestMiddleware_ExpectedResponse()
    {
        using var host = await new HostBuilder()
            .ConfigureWebHost(webBuilder =>
            {
                webBuilder
                    .UseTestServer()
                    .UseEnvironment(Environments.Staging)
                    .ConfigureServices(services =>
                    {
                        // services.AddMyServices();
                    })
                    .Configure(app =>
                    {
                        // app.UseMiddleware<MyMiddleware>();
                    });
            })
            .StartAsync();

        var c = host.Services.GetRequiredService<IConfiguration>();
        Assert.Equal(c.EnvironmentName(), Environments.Staging);

        // var server = host.GetTestServer();
        // server.BaseAddress = new Uri("https://example.com/A/Path/");
        //
        // var context = await server.SendAsync(c =>
        // {
        //     c.Request.Method = HttpMethods.Post;
        //     c.Request.Path = "/api/test";
        //     c.Request.QueryString = new QueryString("?id=12345");
        // });

        // Assert.True(context.RequestAborted.CanBeCanceled);
        // Assert.Equal(HttpProtocol.Http11, context.Request.Protocol);
        // Assert.Equal("POST", context.Request.Method);
        // Assert.Equal("https", context.Request.Scheme);
        // Assert.Equal("example.com", context.Request.Host.Value);
        // Assert.Equal("/A/Path", context.Request.PathBase.Value);
        // Assert.Equal("/and/file.txt", context.Request.Path.Value);
        // Assert.Equal("?and=query", context.Request.QueryString.Value);
        // Assert.NotNull(context.Request.Body);
        // Assert.NotNull(context.Request.Headers);
        // Assert.NotNull(context.Response.Headers);
        // Assert.NotNull(context.Response.Body);
        // Assert.Equal(404, context.Response.StatusCode);
        // Assert.Null(context.Features.Get<IHttpResponseFeature>().ReasonPhrase);
    }
}