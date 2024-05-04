using System.Net;
using Polly;
using Polly.Extensions.Http;
using SearchService.Data;
using SearchService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddHttpClient<AuctionSvcHttpClient>().AddPolicyHandler(GetPolicy());

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

// add hack for the resend sync (async in here) request again (3 seconds) if data is not accepted 
// (Auction Service is down or not available)
app.Lifetime.ApplicationStarted.Register(async () => {
    try
    {
        await DbInitializer.InitDbAsync(app);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }
});

app.Run();

// add hack for the resend sync (async in here) request again (3 seconds) if data is not accepted 
// (Auction Service is down or not available)
static IAsyncPolicy<HttpResponseMessage> GetPolicy() 
    => HttpPolicyExtensions
        .HandleTransientHttpError()
        .OrResult(msg => msg.StatusCode == HttpStatusCode.NotFound)
        .WaitAndRetryForeverAsync(_ => TimeSpan.FromSeconds(3));